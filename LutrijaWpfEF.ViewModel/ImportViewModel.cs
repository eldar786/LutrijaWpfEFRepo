using LutrijaWpfEF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LutrijaWpfEF.ViewModel
{
   public class ImportViewModel : ObservableObject
    {

        private ApplicationViewModel _avm;
        private string sFileName;
        private string dc = @"Server=DB-SRV-01;Database=Lutrija;MultipleActiveResultSets=true;User ID=sa;Password=Lutrija1;
                        TrustServerCertificate=True;";
        string output = "\\\\192.168.1.213\\Users\\Share Import\\Import EOP UPLATE\\Arhiva\\import" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".csv";
        private string query = @"INSERT INTO PROVJERA_KLADIONICA VALUES (@ime)";
        private List<string> lista;
        private string brojListica;
        private double sumaIsplata;
        private readonly object _lock = new object();

        public ICommand EopAnaCommand { get; set; }
        public ICommand EopSinCommand { get; set; }
        public ICommand KladUplIsplCommand { get; set; }
        public ICommand IsplataCommand { get; set; }

        public ImportViewModel(ApplicationViewModel avm)
        {
            _avm = avm;
            this.EopAnaCommand = new RelayCommand(EOP_Analitika);
            this.EopSinCommand = new RelayCommand(EOP_Sintetika);
            this.KladUplIsplCommand = new RelayCommand(Kladionica);
            this.IsplataCommand = new RelayCommand(Isplata);
        }

        private void EOP_Analitika()
        {

            double suma = 0;
            int red = 0;
            double iznos = 0;
            int rezultat = 0;
            DateTime dat = DateTime.Now.Date;


            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                sFileName = openFileDialog.FileName;
                var linesRead = File.ReadAllLines(sFileName);
                string druga = linesRead[1];
                string[] dr = druga.Split('$');
                dat = DateTime.Parse(dr[4]);


                foreach (var line in linesRead)
                {

                    red++;
                    string[] razdvojeno = line.Split('$');
                    if (red > 1)
                    {
                        double broj = Double.Parse(razdvojeno[16], CultureInfo.InvariantCulture);
                        iznos = broj / 100;
                    }

                    suma = suma + iznos;
                }


                using (SqlConnection con = new SqlConnection(dc))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("dbo.provjera_datum_ana", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@datum", SqlDbType.Date).Value = dat;

                        rezultat = (int)cmd.ExecuteScalar();

                    }

                    if (rezultat == 1)
                    {
                        System.Windows.MessageBox.Show("Taj datum već postoji u bazi. Molimo probajte odabrati drugi file");
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("dynamic_import", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = sFileName;
                            cmd.ExecuteNonQuery();

                            System.IO.File.Move(sFileName, output);
                        }

                        MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Unijeli ste " + red + "redova. Ukupan iznos je: " + suma, "Želite li nastaviti?", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.analitika_copy", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = sFileName;
                                cmd.ExecuteNonQuery();


                            }
                        }
                        else if (dialogResult == MessageBoxResult.No)
                        {
                            System.Windows.MessageBox.Show("Import otkazan");
                        }
                        con.Close();
                    }
                }
            }
        }

        private void EOP_Sintetika()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "DAT files (*.dat)|*.dat";

            if (openFileDialog.ShowDialog() == true)
            {

                try
                {
                    sFileName = openFileDialog.FileName;
                    double suma = 0;
                    int i = 0;
                    int rezultat = 0;

                    StreamWriter file = new System.IO.StreamWriter(@output);

                    var linesRead = File.ReadAllLines(sFileName);
                    string dat = linesRead[0];

                    char[] date = new char[8];
                    date[0] = dat[74];
                    date[1] = dat[75];
                    date[2] = dat[76];
                    date[3] = dat[77];
                    date[4] = dat[78];
                    date[5] = dat[79];
                    date[6] = dat[80];
                    date[7] = dat[81];

                    string d = new string(date);
                    DateTime datum = DateTime.ParseExact(d, "yyyyMMdd", CultureInfo.InvariantCulture).Date;

                    foreach (var line in linesRead)
                    {
                        string red = line.Insert(5, "$").Insert(28, "$").Insert(33, "$").Insert(37, "$").Insert(42, "$").Insert(46, "$")
                       .Insert(51, "$").Insert(56, "$").Insert(70, "$").Insert(77, "$").Insert(81, "$").Insert(84, "$").Insert(94, "$").Insert(102, "$").Replace(",", ".");

                        char[] array = new char[7];
                        array[0] = line[55];
                        array[1] = line[56];
                        array[2] = line[57];
                        array[3] = line[58];
                        array[4] = line[59];
                        array[5] = line[60];
                        array[6] = line[61];

                        string uplata = new string(array).Trim(' ').Replace(",", ".");

                        double iznos = Double.Parse(uplata, CultureInfo.InvariantCulture);

                        suma = suma + iznos;

                        red = Regex.Replace(red, @"\s+", String.Empty);
                        i++;
                        file.WriteLine(red);
                    }

                    file.Close();

                    using (SqlConnection con = new SqlConnection(dc))
                    {

                        using (SqlCommand cmd = new SqlCommand("dbo.provjera_datum_sin", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@datum", SqlDbType.Date).Value = datum;
                            con.Open();

                            rezultat = (int)cmd.ExecuteScalar();

                        }

                        if (rezultat == 1)
                        {
                            System.Windows.MessageBox.Show("Taj datum već postoji u bazi. Molimo probajte odabrati drugi file");
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.sintetika_import", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                                cmd.ExecuteNonQuery();

                                System.IO.File.Delete(sFileName);
                            }

                            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Unijeli ste " + i + "redova. Ukupan iznos je: " + suma, "Želite li nastaviti?", MessageBoxButton.YesNo);

                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                using (SqlCommand cmd = new SqlCommand("dbo.sintetika_copy", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else if (dialogResult == MessageBoxResult.No)
                            {
                                System.Windows.MessageBox.Show("Import otkazan");
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception greska)
                {
                    System.Windows.MessageBox.Show("Greška: " + greska.Message);
                }

            }
        }

        private void Kladionica()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            // openFileDialog.Filter = "XLSX files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {

                sFileName = openFileDialog.FileName;
                string ime = openFileDialog.SafeFileName;
                StreamWriter file = new System.IO.StreamWriter(@output);

                Match match = Regex.Match(ime, @"\d{2}\.\d{2}\.\d{4}");
                string date = match.Value;
                var datumUplate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                double sumaUplata = 0;
                double sumaIsplata = 0;
                double sumaRaz = 0;
                int i = 0;
                int rezultat = 0;
                List<string> neka = new List<string>();

                //  StreamWriter file = new System.IO.StreamWriter(@output);

                var linesRead = File.ReadAllLines(sFileName);

                foreach (var line in linesRead)
                {

                    i++;
                    if (i > 1)
                    {

                        var result = Regex.Split(line, (",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))"));

                        if (result.Count() == 19)
                        {

                            string proba4 = result[0].Replace("\"", "").Replace(@"\", "");
                            int proba1 = Convert.ToInt16(proba4);
                            string proba3 = proba1.ToString("D5");
                            result[0] = proba3;
                            string proba2 = result[4].Replace("/", "$");
                            result[4] = proba2;


                            double.TryParse(result[6], NumberStyles.Any, CultureInfo.CurrentCulture, out double uplata);
                            result[6] = uplata.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[7], NumberStyles.Any, CultureInfo.CurrentCulture, out double naknada);
                            result[7] = naknada.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[8], NumberStyles.Any, CultureInfo.CurrentCulture, out double isplata);
                            result[8] = isplata.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[9], NumberStyles.Any, CultureInfo.CurrentCulture, out double porez);
                            result[9] = porez.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[11], NumberStyles.Any, CultureInfo.CurrentCulture, out double iznosPorSis);
                            result[11] = iznosPorSis.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[13], NumberStyles.Any, CultureInfo.CurrentCulture, out double iznosPorNor);
                            result[13] = iznosPorNor.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[15], NumberStyles.Any, CultureInfo.CurrentCulture, out double iznosPorSpec);
                            result[15] = iznosPorSpec.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[17], NumberStyles.Any, CultureInfo.CurrentCulture, out double razlika);
                            result[17] = razlika.ToString(CultureInfo.InvariantCulture);

                            neka = result.ToList<string>();
                            neka.RemoveAt(neka.Count - 1);




                            string combindedString = string.Join("$", neka);
                            combindedString = combindedString.Replace("\"", "");

                            file.WriteLine(combindedString);

                            sumaUplata = sumaUplata + uplata;
                            sumaIsplata = sumaIsplata + isplata;
                            sumaRaz = sumaRaz + razlika;
                        }

                        if (result.Count() == 12)
                        {
                            //double uplata;
                            string output = result[4].Substring(result[4].IndexOf('/') + 1);
                            result[4] = output;
                            string brObj = result[0].Replace("\"", "").Replace(@"\", "");
                            int broj = Convert.ToInt16(brObj);
                            string brojObj = broj.ToString("D5");
                            result[0] = brojObj;

                            string up = result[6].Replace("\"", "").Replace(",", ".");
                            Console.WriteLine(up);

                            double uplata = double.Parse(up, NumberStyles.Any, CultureInfo.InvariantCulture);

                            result[6] = uplata.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[7], NumberStyles.Any, CultureInfo.CurrentCulture, out double naknada);
                            result[7] = naknada.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[8], NumberStyles.Any, CultureInfo.CurrentCulture, out double isplata);
                            result[8] = isplata.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[9], NumberStyles.Any, CultureInfo.CurrentCulture, out double porez);
                            result[9] = porez.ToString(CultureInfo.InvariantCulture);
                            double.TryParse(result[10], NumberStyles.Any, CultureInfo.CurrentCulture, out double razlika);
                            result[10] = razlika.ToString(CultureInfo.InvariantCulture);

                            neka = result.ToList<string>();
                            neka.RemoveAt(neka.Count - 1);

                            string combindedString = string.Join("$", neka);
                            combindedString = combindedString.Replace("\"", "");

                            file.WriteLine(combindedString);

                            sumaUplata = sumaUplata + uplata;
                            sumaIsplata = sumaIsplata + isplata;
                            sumaRaz = sumaRaz + razlika;


                        }


                    }

                }

                file.Close();

                using (SqlConnection con = new SqlConnection(dc))
                {

                    using (SqlCommand cmd = new SqlCommand("dbo.provjera_datum_klad", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ime", SqlDbType.VarChar).Value = ime;
                        con.Open();

                        rezultat = (int)cmd.ExecuteScalar();

                    }

                    if (rezultat == 1)
                    {
                        System.Windows.MessageBox.Show("Taj file već postoji u bazi. Molimo probajte odabrati drugi file");
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@ime", SqlDbType.VarChar).Value = ime;
                            cmd.ExecuteNonQuery();
                        }

                        if (neka.Count < 13)
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.kladionica_import2", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                                cmd.ExecuteNonQuery();

                                //   System.IO.File.Delete(sFileName);
                            }
                        }
                        else
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.kladionica_import", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                                cmd.ExecuteNonQuery();

                                //   System.IO.File.Delete(sFileName);
                            }
                        }

                        MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Unijeli ste " + i + " redova. Datum je " + datumUplate + " Ukupan iznos je: " + sumaUplata, " Želite li nastaviti?", MessageBoxButton.YesNo);

                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.klad_copy", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (dialogResult == MessageBoxResult.No)
                        {
                            System.Windows.MessageBox.Show("Import otkazan");
                        }
                        con.Close();
                    }
                }
            }
        }

        private void Isplata()
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            // openFileDialog.Filter = "XLSX files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {

                sFileName = openFileDialog.FileName;
                string ime = openFileDialog.SafeFileName;
                StreamWriter file = new System.IO.StreamWriter(@output);
                int i = 0;

                string[] linesRead = File.ReadAllLines(sFileName);

                int rezultat = 0;

                List<string> neka = new List<string>();


                Parallel.ForEach(linesRead, (line) =>
                {


                    string godina = line.Substring(0, 2) + '$';

                    string lis_kolo = line.Substring(2, 4) + '$';


                    string lis_igra = line.Substring(6, 3) + '$';


                    string igraNaziv = line.Substring(9, 15) + '$';
                            //                    listicTemp.IgraNaziv = t.Trim();

                            string listicIsplatio = line.Substring(24, 6) + '$';


                            //Provjeri prodavače u bazi
                            //if (!prodavaciUValuti.Contains(listicTemp.ListicIsplatio))
                            //    prodavaciUValuti.Add(listicTemp.ListicIsplatio);

                            string listicUplatio = line.Substring(30, 6) + '$';


                    brojListica = line.Substring(36, 9) + '$';


                    string dobitak = line.Substring(45, 4) + '$';


                    string brojDobitaka = line.Substring(49, 11) + '$';


                    string iznosDobitka = line.Substring(60, 13);
                    double iznDob = double.Parse(iznosDobitka);
                    iznosDobitka = iznDob.ToString(CultureInfo.InvariantCulture) + '$';

                    string iznos = line.Substring(73, 13);
                    double izn = double.Parse(iznos);
                    sumaIsplata = sumaIsplata + izn;
                    iznos = izn.ToString(CultureInfo.InvariantCulture) + '$';

                    string porez = line.Substring(86, 13);
                    double por = double.Parse(porez);
                    porez = por.ToString(CultureInfo.InvariantCulture) + '$';

                    string t1 = line.Substring(99, 9).Trim();
                    int god, mj, dan, sat, min, sec;
                    god = Convert.ToInt16(t1.Substring(0, 4));
                    mj = Convert.ToInt16(t1.Substring(4, 2));
                    dan = Convert.ToInt16(t1.Substring(6, 2));

                    string t2 = line.Substring(108, 7).Trim();
                    sat = Convert.ToInt16(t2.Substring(0, 2));
                    min = Convert.ToInt16(t2.Substring(2, 2));
                    sec = Convert.ToInt16(t2.Substring(4, 2));
                    DateTime VrijemeUplate = new DateTime(god, mj, dan, sat, min, sec);

                    string vrUpl = VrijemeUplate.ToString("yyyyMMdd HH:mm:ss") + '$';

                    t1 = line.Substring(115, 9).Trim();
                    god = Convert.ToInt16(t1.Substring(0, 4));
                    mj = Convert.ToInt16(t1.Substring(4, 2));
                    dan = Convert.ToInt16(t1.Substring(6, 2));

                    t2 = line.Substring(124, 7).Trim();
                    sat = Convert.ToInt16(t2.Substring(0, 2));
                    min = Convert.ToInt16(t2.Substring(2, 2));
                    sec = Convert.ToInt16(t2.Substring(4, 2));
                    DateTime VrijemeIsplate = new DateTime(god, mj, dan, sat, min, sec);

                    string vrIsp = VrijemeIsplate.ToString("yyyyMMdd HH:mm:ss") + '$';

                    string priprema = godina + lis_kolo + lis_igra + igraNaziv + listicIsplatio + listicUplatio + brojListica + dobitak + brojDobitaka + iznosDobitka + iznos + porez;

                    string red = Regex.Replace(priprema, @"\s+", "") + vrUpl + vrIsp + "0";
                    lock (_lock)
                    {
                        file.WriteLine(red);
                    }

                });

                file.Close();

                using (SqlConnection con = new SqlConnection(dc))
                {

                    using (SqlCommand cmd = new SqlCommand("dbo.provjera_broj_list", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@broj", SqlDbType.VarChar).Value = brojListica;
                        con.Open();

                        rezultat = (int)cmd.ExecuteScalar();

                    }

                    if (rezultat == 1)
                    {
                        System.Windows.MessageBox.Show("Taj file već postoji u bazi. Molimo probajte odabrati drugi file");
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.isplata_import", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                            cmd.ExecuteNonQuery();

                            //   System.IO.File.Delete(sFileName);
                        }
                    }



                    MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Unijeli ste " + i + " redova. Datum je " + " Ukupan iznos je: " + sumaIsplata, " Želite li nastaviti?", MessageBoxButton.YesNo);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.isplata_copy", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = output;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (dialogResult == MessageBoxResult.No)
                    {
                        System.Windows.MessageBox.Show("Import otkazan");
                    }
                    con.Close();
                }
            }
        }

    }
}
