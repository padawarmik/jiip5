namespace WpfApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class wwsi : DbContext
    {
        public wwsi()
            : base("name=wwsi")
        {
        }

        public virtual DbSet<CONVERSION_LOG> CONVERSION_LOG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CONVERSION_LOG>()
                .Property(e => e.CL_UnitFrom)
                .IsFixedLength();

            modelBuilder.Entity<CONVERSION_LOG>()
                .Property(e => e.CL_ValueFrom)
                .HasPrecision(18, 5);

            modelBuilder.Entity<CONVERSION_LOG>()
                .Property(e => e.CL_UnitTo)
                .IsFixedLength();

            modelBuilder.Entity<CONVERSION_LOG>()
                .Property(e => e.CL_ValueTo)
                .HasPrecision(18, 5);

            modelBuilder.Entity<CONVERSION_LOG>()
                .Property(e => e.CL_UnitType)
                .IsFixedLength();
        }
    }
}
