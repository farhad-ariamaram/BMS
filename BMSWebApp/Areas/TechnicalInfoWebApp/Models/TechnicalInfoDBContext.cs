using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TechnicalInfoWebApp.Models
{
    public partial class TechnicalInfoDBContext : DbContext
    {
        public TechnicalInfoDBContext()
        {
        }

        public TechnicalInfoDBContext(DbContextOptions<TechnicalInfoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDataDisplayType> TblDataDisplayTypes { get; set; }
        public virtual DbSet<TblParameter> TblParameters { get; set; }
        public virtual DbSet<TblParametersUnit> TblParametersUnits { get; set; }
        public virtual DbSet<TblPhysicalQuantity> TblPhysicalQuantities { get; set; }
        public virtual DbSet<TblPhysicalQuantityUnit> TblPhysicalQuantityUnits { get; set; }
        public virtual DbSet<TblReference> TblReferences { get; set; }
        public virtual DbSet<TblReferenceTechnicalInfoGroup> TblReferenceTechnicalInfoGroups { get; set; }
        public virtual DbSet<TblReferenceValue> TblReferenceValues { get; set; }
        public virtual DbSet<TblTechnicalInfo> TblTechnicalInfos { get; set; }
        public virtual DbSet<TblTechnicalInfoDataType> TblTechnicalInfoDataTypes { get; set; }
        public virtual DbSet<TblTechnicalInfoDataTypesValue> TblTechnicalInfoDataTypesValues { get; set; }
        public virtual DbSet<TblTechnicalInfoGroup> TblTechnicalInfoGroups { get; set; }
        public virtual DbSet<TblTypeOfPhysicalQuantity> TblTypeOfPhysicalQuantities { get; set; }
        public virtual DbSet<TblUnit> TblUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.10.250;database=TechnicalInfoDB;User Id=TechnicalInfoUser;Password=T3ch!Nf0@Aba1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS");

            modelBuilder.Entity<TblDataDisplayType>(entity =>
            {
                entity.HasKey(e => e.FldDataDisplayTypeId);

                entity.ToTable("Tbl_DataDisplayType");

                entity.Property(e => e.FldDataDisplayTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_DataDisplayType_ID");

                entity.Property(e => e.FldDataDisplayTypeTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_DataDisplayType_txt");
            });

            modelBuilder.Entity<TblParameter>(entity =>
            {
                entity.HasKey(e => e.FldParametersId);

                entity.ToTable("Tbl_parameters");

                entity.Property(e => e.FldParametersId)
                    .HasColumnName("Fld_parameters_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldParametersText)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_parameters_Text");

                entity.Property(e => e.FldPhysicalQuantityId).HasColumnName("Fld_PhysicalQuantity_ID");

                entity.HasOne(d => d.FldPhysicalQuantity)
                    .WithMany(p => p.TblParameters)
                    .HasForeignKey(d => d.FldPhysicalQuantityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_parameters_Tbl_PhysicalQuantity");
            });

            modelBuilder.Entity<TblParametersUnit>(entity =>
            {
                entity.HasKey(e => e.FldParametersUnitsId);

                entity.ToTable("Tbl_parametersUnits");

                entity.Property(e => e.FldParametersUnitsId)
                    .HasColumnName("Fld_parametersUnits_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldParametersId).HasColumnName("Fld_parameters_ID");

                entity.Property(e => e.FldUnitId).HasColumnName("Fld_Unit_ID");

                entity.HasOne(d => d.FldParameters)
                    .WithMany(p => p.TblParametersUnits)
                    .HasForeignKey(d => d.FldParametersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_parametersUnits_Tbl_parameters");

                entity.HasOne(d => d.FldUnit)
                    .WithMany(p => p.TblParametersUnits)
                    .HasForeignKey(d => d.FldUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_parametersUnits_Tbl_Unit");
            });

            modelBuilder.Entity<TblPhysicalQuantity>(entity =>
            {
                entity.HasKey(e => e.FldPhysicalQuantityId);

                entity.ToTable("Tbl_PhysicalQuantity");

                entity.Property(e => e.FldPhysicalQuantityId)
                    .HasColumnName("Fld_PhysicalQuantity_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldPhysicalQuantityHasDirection).HasColumnName("Fld_PhysicalQuantity_HasDirection");

                entity.Property(e => e.FldPhysicalQuantityMax)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_PhysicalQuantity_max");

                entity.Property(e => e.FldPhysicalQuantityMin)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_PhysicalQuantity_min");

                entity.Property(e => e.FldPhysicalQuantityTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_PhysicalQuantity_txt");

                entity.Property(e => e.FldTypeOfPhysicalQuantityId).HasColumnName("Fld_TypeOfPhysicalQuantity_ID");

                entity.HasOne(d => d.FldTypeOfPhysicalQuantity)
                    .WithMany(p => p.TblPhysicalQuantities)
                    .HasForeignKey(d => d.FldTypeOfPhysicalQuantityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PhysicalQuantity_Tbl_TypeOfPhysicalQuantity");
            });

            modelBuilder.Entity<TblPhysicalQuantityUnit>(entity =>
            {
                entity.HasKey(e => e.FldPhysicalQuantityUnitsId);

                entity.ToTable("Tbl_PhysicalQuantityUnits");

                entity.Property(e => e.FldPhysicalQuantityUnitsId)
                    .HasColumnName("Fld_PhysicalQuantityUnits_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldPhysicalQuantityId).HasColumnName("Fld_PhysicalQuantity_ID");

                entity.Property(e => e.FldUnitId).HasColumnName("Fld_Unit_ID");

                entity.HasOne(d => d.FldPhysicalQuantity)
                    .WithMany(p => p.TblPhysicalQuantityUnits)
                    .HasForeignKey(d => d.FldPhysicalQuantityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PhysicalQuantityUnits_Tbl_PhysicalQuantity");

                entity.HasOne(d => d.FldUnit)
                    .WithMany(p => p.TblPhysicalQuantityUnits)
                    .HasForeignKey(d => d.FldUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PhysicalQuantityUnits_Tbl_Unit");
            });

            modelBuilder.Entity<TblReference>(entity =>
            {
                entity.HasKey(e => e.FldReferenceId);

                entity.ToTable("Tbl_Reference");

                entity.Property(e => e.FldReferenceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_Reference_ID");

                entity.Property(e => e.FldReferenceTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_Reference_txt");
            });

            modelBuilder.Entity<TblReferenceTechnicalInfoGroup>(entity =>
            {
                entity.HasKey(e => e.FldReferenceTechnicalInfoGroupId);

                entity.ToTable("Tbl_ReferenceTechnicalInfoGroup");

                entity.Property(e => e.FldReferenceTechnicalInfoGroupId)
                    .HasColumnName("Fld_ReferenceTechnicalInfoGroup_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldReferenceId).HasColumnName("Fld_Reference_ID");

                entity.Property(e => e.FldReferenceTechnicalInfoGroupReferenceId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Fld_ReferenceTechnicalInfoGroup_ReferenceID");

                entity.Property(e => e.FldTechnicalInfoGroupId).HasColumnName("Fld_TechnicalInfoGroup_ID");

                entity.HasOne(d => d.FldReference)
                    .WithMany(p => p.TblReferenceTechnicalInfoGroups)
                    .HasForeignKey(d => d.FldReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ReferenceTechnicalInfoGroup_Tbl_Reference");

                entity.HasOne(d => d.FldTechnicalInfoGroup)
                    .WithMany(p => p.TblReferenceTechnicalInfoGroups)
                    .HasForeignKey(d => d.FldTechnicalInfoGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ReferenceTechnicalInfoGroup_Tbl_TechnicalInfoGroup");
            });

            modelBuilder.Entity<TblReferenceValue>(entity =>
            {
                entity.HasKey(e => e.FldReferenceValuesId);

                entity.ToTable("Tbl_ReferenceValues");

                entity.Property(e => e.FldReferenceValuesId)
                    .HasColumnName("Fld_ReferenceValues_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldReferenceTechnicalInfoGroupId).HasColumnName("Fld_ReferenceTechnicalInfoGroup_ID");

                entity.Property(e => e.FldReferenceValuesDirection)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_ReferenceValues_Direction");

                entity.Property(e => e.FldReferenceValuesValue)
                    .IsRequired()
                    .HasColumnName("Fld_ReferenceValues_Value");

                entity.Property(e => e.FldTechnicalInfoId).HasColumnName("Fld_TechnicalInfo_ID");

                entity.HasOne(d => d.FldReferenceTechnicalInfoGroup)
                    .WithMany(p => p.TblReferenceValues)
                    .HasForeignKey(d => d.FldReferenceTechnicalInfoGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ReferenceValues_Tbl_ReferenceTechnicalInfoGroup");

                entity.HasOne(d => d.FldTechnicalInfo)
                    .WithMany(p => p.TblReferenceValues)
                    .HasForeignKey(d => d.FldTechnicalInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ReferenceValues_Tbl_TechnicalInfo");
            });

            modelBuilder.Entity<TblTechnicalInfo>(entity =>
            {
                entity.HasKey(e => e.FldTechnicalInfoId);

                entity.ToTable("Tbl_TechnicalInfo");

                entity.Property(e => e.FldTechnicalInfoId)
                    .HasColumnName("Fld_TechnicalInfo_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldTechnicalInfoDataTypesId).HasColumnName("Fld_TechnicalInfoDataTypes_ID");

                entity.Property(e => e.FldTechnicalInfoDecimalLength)
                    .HasColumnName("Fld_TechnicalInfo_DecimalLength")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldTechnicalInfoGroupId).HasColumnName("Fld_TechnicalInfoGroup_ID");

                entity.Property(e => e.FldTechnicalInfoMax)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_TechnicalInfo_Max");

                entity.Property(e => e.FldTechnicalInfoMin)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_TechnicalInfo_Min");

                entity.Property(e => e.FldTechnicalInfoTextLength).HasColumnName("Fld_TechnicalInfo_TextLength");

                entity.Property(e => e.FldTechnicalInfoTxt)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Fld_TechnicalInfo_txt");

                entity.HasOne(d => d.FldTechnicalInfoDataTypes)
                    .WithMany(p => p.TblTechnicalInfos)
                    .HasForeignKey(d => d.FldTechnicalInfoDataTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfo_Tbl_TechnicalInfoDataTypes");

                entity.HasOne(d => d.FldTechnicalInfoGroup)
                    .WithMany(p => p.TblTechnicalInfos)
                    .HasForeignKey(d => d.FldTechnicalInfoGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfo_Tbl_TechnicalInfoGroup");
            });

            modelBuilder.Entity<TblTechnicalInfoDataType>(entity =>
            {
                entity.HasKey(e => e.FldTechnicalInfoDataTypesId);

                entity.ToTable("Tbl_TechnicalInfoDataTypes");

                entity.Property(e => e.FldTechnicalInfoDataTypesId)
                    .HasColumnName("Fld_TechnicalInfoDataTypes_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldDataDisplayTypeId).HasColumnName("Fld_DataDisplayType_ID");

                entity.Property(e => e.FldParametersId).HasColumnName("Fld_parameters_ID");

                entity.Property(e => e.FldTechnicalInfoDataTypesDecimalLength)
                    .HasColumnName("Fld_TechnicalInfoDataTypes_DecimalLength")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldTechnicalInfoDataTypesHasDirection)
                    .HasColumnName("Fld_TechnicalInfoDataTypes_HasDirection")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldTechnicalInfoDataTypesHasValues).HasColumnName("Fld_TechnicalInfoDataTypes_HasValues");

                entity.Property(e => e.FldTechnicalInfoDataTypesMax)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_TechnicalInfoDataTypes_Max");

                entity.Property(e => e.FldTechnicalInfoDataTypesMin)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_TechnicalInfoDataTypes_Min");

                entity.Property(e => e.FldTechnicalInfoDataTypesTextLength).HasColumnName("Fld_TechnicalInfoDataTypes_TextLength");

                entity.Property(e => e.FldTechnicalInfoDataTypesTxt)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Fld_TechnicalInfoDataTypes_txt");

                entity.HasOne(d => d.FldDataDisplayType)
                    .WithMany(p => p.TblTechnicalInfoDataTypes)
                    .HasForeignKey(d => d.FldDataDisplayTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfoDataTypes_Tbl_DataDisplayType");

                entity.HasOne(d => d.FldParameters)
                    .WithMany(p => p.TblTechnicalInfoDataTypes)
                    .HasForeignKey(d => d.FldParametersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfoDataTypes_Tbl_TechnicalInfoDataTypes");
            });

            modelBuilder.Entity<TblTechnicalInfoDataTypesValue>(entity =>
            {
                entity.HasKey(e => e.FldTechnicalInfoDataTypesValuesId);

                entity.ToTable("Tbl_TechnicalInfoDataTypesValues");

                entity.Property(e => e.FldTechnicalInfoDataTypesValuesId)
                    .HasColumnName("Fld_TechnicalInfoDataTypesValues_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldTechnicalInfoDataTypesId).HasColumnName("Fld_TechnicalInfoDataTypes_ID");

                entity.Property(e => e.FldTechnicalInfoDataTypesValuesTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_TechnicalInfoDataTypesValues_txt");

                entity.HasOne(d => d.FldTechnicalInfoDataTypes)
                    .WithMany(p => p.TblTechnicalInfoDataTypesValues)
                    .HasForeignKey(d => d.FldTechnicalInfoDataTypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfoDataTypesValues_Tbl_TechnicalInfoDataTypes");
            });

            modelBuilder.Entity<TblTechnicalInfoGroup>(entity =>
            {
                entity.HasKey(e => e.FldTechnicalInfoGroupId);

                entity.ToTable("Tbl_TechnicalInfoGroup");

                entity.Property(e => e.FldTechnicalInfoGroupId)
                    .HasColumnName("Fld_TechnicalInfoGroup_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldReferenceId).HasColumnName("Fld_Reference_ID");

                entity.Property(e => e.FldTechnicalInfoGroupTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_TechnicalInfoGroup_txt");

                entity.HasOne(d => d.FldReference)
                    .WithMany(p => p.TblTechnicalInfoGroups)
                    .HasForeignKey(d => d.FldReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TechnicalInfoGroup_Tbl_Reference");
            });

            modelBuilder.Entity<TblTypeOfPhysicalQuantity>(entity =>
            {
                entity.HasKey(e => e.FldTypeOfPhysicalQuantityId);

                entity.ToTable("Tbl_TypeOfPhysicalQuantity");

                entity.Property(e => e.FldTypeOfPhysicalQuantityId)
                    .HasColumnName("Fld_TypeOfPhysicalQuantity_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldTypeOfPhysicalQuantityTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_TypeOfPhysicalQuantity_txt");
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.HasKey(e => e.FldUnitId);

                entity.ToTable("Tbl_Unit");

                entity.Property(e => e.FldUnitId)
                    .HasColumnName("Fld_Unit_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldUnitDes).HasColumnName("Fld_Unit_Des");

                entity.Property(e => e.FldUnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Fld_Unit_Name");

                entity.Property(e => e.FldUnitSimbol)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_Unit_Simbol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
