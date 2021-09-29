using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LoggerWebApp.Models
{
    public partial class ILogDBContext : DbContext
    {
        public ILogDBContext()
        {
        }

        public ILogDBContext(DbContextOptions<ILogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblIlogDbIp> TblIlogDbIps { get; set; }
        public virtual DbSet<TblIlogDbLog> TblIlogDbLogs { get; set; }
        public virtual DbSet<TblIlogDbType> TblIlogDbTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ILogDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_100_CI_AS");

            modelBuilder.Entity<TblIlogDbIp>(entity =>
            {
                entity.HasKey(e => e.FldIlogDbIpId);

                entity.ToTable("Tbl_ILogDB_Ip");

                entity.Property(e => e.FldIlogDbIpId).HasColumnName("Fld_ILogDB_Ip_Id");

                entity.Property(e => e.FldIlogDbIpAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_ILogDB_Ip_Address");

                entity.Property(e => e.FldIlogDbIpTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_ILogDB_Ip_Title");

                entity.Property(e => e.FldIlogDbLogTypeId).HasColumnName("Fld_ILogDB_Log_TypeId");

                entity.HasOne(d => d.FldIlogDbLogType)
                    .WithMany(p => p.TblIlogDbIps)
                    .HasForeignKey(d => d.FldIlogDbLogTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ILogDB_Ip_Tbl_ILogDB_Type");
            });

            modelBuilder.Entity<TblIlogDbLog>(entity =>
            {
                entity.HasKey(e => e.FldIlogDbLogId);

                entity.ToTable("Tbl_ILogDB_Log");

                entity.Property(e => e.FldIlogDbLogId).HasColumnName("Fld_ILogDB_Log_Id");

                entity.Property(e => e.FldIlogDbIpId).HasColumnName("Fld_ILogDB_Ip_Id");

                entity.Property(e => e.FldIlogDbLogDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_ILogDB_Log_DateTime");

                entity.HasOne(d => d.FldIlogDbIp)
                    .WithMany(p => p.TblIlogDbLogs)
                    .HasForeignKey(d => d.FldIlogDbIpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ILogDB_Log_Tbl_ILogDB_Ip");
            });

            modelBuilder.Entity<TblIlogDbType>(entity =>
            {
                entity.HasKey(e => e.FldIlogDbTypeId);

                entity.ToTable("Tbl_ILogDB_Type");

                entity.Property(e => e.FldIlogDbTypeId).HasColumnName("Fld_ILogDB_Type_Id");

                entity.Property(e => e.FldIlogDbTypeTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_ILogDB_Type_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
