namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<COMMONDITY> COMMONDITY { get; set; }
        public virtual DbSet<COMMONDITY_TYPE_REF> COMMONDITY_TYPE_REF { get; set; }
        public virtual DbSet<PROVIDER> PROVIDER { get; set; }
        public virtual DbSet<PROVIDER_SUPPLY_STOCK> PROVIDER_SUPPLY_STOCK { get; set; }
        public virtual DbSet<SUPPLY> SUPPLY { get; set; }
        public virtual DbSet<SUPPLY_LINE> SUPPLY_LINE { get; set; }
        public virtual DbSet<SUPPLY_STATUS_REF> SUPPLY_STATUS_REF { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<WAREHOUSE> WAREHOUSE { get; set; }
        public virtual DbSet<WAREHOUSE_LINE> WAREHOUSE_LINE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COMMONDITY>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<COMMONDITY>()
                .HasMany(e => e.PROVIDER_SUPPLY_STOCK)
                .WithRequired(e => e.COMMONDITY)
                .HasForeignKey(e => e.COMMONDITY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMMONDITY>()
                .HasMany(e => e.SUPPLY_LINE)
                .WithRequired(e => e.COMMONDITY)
                .HasForeignKey(e => e.COMMONDITY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMMONDITY>()
                .HasMany(e => e.WAREHOUSE_LINE)
                .WithRequired(e => e.COMMONDITY)
                .HasForeignKey(e => e.COMMONDITY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMMONDITY_TYPE_REF>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<COMMONDITY_TYPE_REF>()
                .HasMany(e => e.COMMONDITY)
                .WithRequired(e => e.COMMONDITY_TYPE_REF)
                .HasForeignKey(e => e.COMMONDITY_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVIDER>()
                .Property(e => e.FAMILY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PROVIDER>()
                .Property(e => e.INITIALS)
                .IsUnicode(false);

            modelBuilder.Entity<PROVIDER>()
                .Property(e => e.COMPANY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<PROVIDER>()
                .HasMany(e => e.PROVIDER_SUPPLY_STOCK)
                .WithRequired(e => e.PROVIDER)
                .HasForeignKey(e => e.PROVIDER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVIDER>()
                .HasMany(e => e.SUPPLY)
                .WithRequired(e => e.PROVIDER)
                .HasForeignKey(e => e.PROVIDER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVIDER_SUPPLY_STOCK>()
                .Property(e => e.COST)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPLY>()
                .Property(e => e.COST)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPLY>()
                .HasMany(e => e.SUPPLY_LINE)
                .WithRequired(e => e.SUPPLY)
                .HasForeignKey(e => e.SUPPLY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUPPLY_LINE>()
                .Property(e => e.COST)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUPPLY_STATUS_REF>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<SUPPLY_STATUS_REF>()
                .HasMany(e => e.SUPPLY)
                .WithRequired(e => e.SUPPLY_STATUS_REF)
                .HasForeignKey(e => e.STATUS_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FIR_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.FAM_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SUPPLY)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.APPLICANT_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WAREHOUSE>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<WAREHOUSE>()
                .HasMany(e => e.SUPPLY)
                .WithRequired(e => e.WAREHOUSE)
                .HasForeignKey(e => e.WAREHOUSE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WAREHOUSE>()
                .HasMany(e => e.WAREHOUSE_LINE)
                .WithRequired(e => e.WAREHOUSE)
                .HasForeignKey(e => e.WAREHOUSE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WAREHOUSE_LINE>()
                .Property(e => e.PER_UNIT_COST)
                .HasPrecision(18, 0);
        }
    }
}
