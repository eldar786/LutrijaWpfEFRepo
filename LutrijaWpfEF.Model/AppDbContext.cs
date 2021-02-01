namespace LutrijaWpfEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<EopAna> EOP_ANA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EopAna>()
                .Property(e => e.OPERATIVNI_BROJ)
                .IsUnicode(false);

            modelBuilder.Entity<EopAna>()
                .Property(e => e.SEDMICA)
                .IsUnicode(false);

            modelBuilder.Entity<EopAna>()
                .Property(e => e.PRODAJNO_MJESTO)
                .IsUnicode(false);

            modelBuilder.Entity<EopAna>()
                .Property(e => e.VRIJEME_UPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<EopAna>()
                .Property(e => e.DATUM_UPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<EopAna>()
                .Property(e => e.KOLO)
                .IsUnicode(false);
        }
    }
}
