using System.Data.Entity;

namespace WpfApp1
{

    public partial class WwsiModel : DbContext
    {
        public WwsiModel()
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
