using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentalWorkOrders.Models
{
    public partial class RentalWorkOrdersDbContext : DbContext
    {
        public RentalWorkOrdersDbContext()
        {
        }

        public RentalWorkOrdersDbContext(DbContextOptions<RentalWorkOrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Residents> Residents { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<WorkOrders> WorkOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=RentalWorkOrders;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__781134817004FA4E");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Residents>(entity =>
            {
                entity.HasKey(e => e.ResidentId)
                    .HasName("PK__Resident__F300572915A86501");

                entity.Property(e => e.Address)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.State)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitNumber)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zip)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__Statuses__519009ACCBBFB78B");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<WorkOrders>(entity =>
            {
                entity.HasKey(e => e.WorkOrderId)
                    .HasName("PK__Work_Ord__9D5C12C7D6E94542");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Work_Orders_Employees");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK_Work_Orders_Residents");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Work_Orders_Statuses");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
