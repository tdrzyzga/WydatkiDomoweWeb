namespace WydatkiDomoweWeb.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HouseholdExpense : DbContext
    {
        public HouseholdExpense()
            : base("name=HouseholdExpense")
        {
        }

        public virtual DbSet<BillName> BillNames { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PostCode> PostCodes { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<MainView> MainViews { get; set; }
        public virtual DbSet<RecipientView> RecipientViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillName>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BillName>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.BillName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostCode>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PostCode>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.PostCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Recipient>()
                .Property(e => e.BuildingNR)
                .IsUnicode(false);

            modelBuilder.Entity<Recipient>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Recipient>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Recipient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Street>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Street>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.Street)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MainView>()
                .Property(e => e.Bill)
                .IsUnicode(false);

            modelBuilder.Entity<MainView>()
                .Property(e => e.Recipient)
                .IsUnicode(false);

            modelBuilder.Entity<MainView>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.BuildingNR)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<RecipientView>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
    }
}
