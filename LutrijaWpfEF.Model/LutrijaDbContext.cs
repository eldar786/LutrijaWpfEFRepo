namespace LutrijaWpfEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LutrijaDbContext : DbContext
    {
        public LutrijaDbContext()
            : base("name=Lutrija")
        {
        }

        public virtual DbSet<EOP_ANA> EOP_ANA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.OPERATIVNI_BROJ)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.SEDMICA)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.PRODAJNO_MJESTO)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.VRIJEME_UPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.DATUM_UPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.KOLO)
                .IsUnicode(false);

            modelBuilder.Entity<EOP_ANA>()
                .Property(e => e.IZNOS_UPLATE)
                .HasPrecision(19, 4);
        }
    }
}
