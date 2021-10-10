using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProjectManagementWebApp.Models
{
    public partial class ProjectManagementDBContext : DbContext
    {
        public ProjectManagementDBContext()
        {
        }

        public ProjectManagementDBContext(DbContextOptions<ProjectManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCommunicationStep> TblCommunicationSteps { get; set; }
        public virtual DbSet<TblExecutionStrategy> TblExecutionStrategies { get; set; }
        public virtual DbSet<TblImplementationStep> TblImplementationSteps { get; set; }
        public virtual DbSet<TblMold> TblMolds { get; set; }
        public virtual DbSet<TblMoldWorkpiece> TblMoldWorkpieces { get; set; }
        public virtual DbSet<TblProject> TblProjects { get; set; }
        public virtual DbSet<TblProjectFile> TblProjectFiles { get; set; }
        public virtual DbSet<TblProjectFileType> TblProjectFileTypes { get; set; }
        public virtual DbSet<TblProjectMold> TblProjectMolds { get; set; }
        public virtual DbSet<TblProjectMoldWorkpiece> TblProjectMoldWorkpieces { get; set; }
        public virtual DbSet<TblProjectMoldWorkpieceCheckpoint> TblProjectMoldWorkpieceCheckpoints { get; set; }
        public virtual DbSet<TblProjectType> TblProjectTypes { get; set; }
        public virtual DbSet<TblSoftwareUsed> TblSoftwareUseds { get; set; }
        public virtual DbSet<TblSoftwareUsedProjectFileType> TblSoftwareUsedProjectFileTypes { get; set; }
        public virtual DbSet<TblTypeOfCommunicationStep> TblTypeOfCommunicationSteps { get; set; }
        public virtual DbSet<TblWorkType> TblWorkTypes { get; set; }
        public virtual DbSet<TblWorkpiece> TblWorkpieces { get; set; }
        public virtual DbSet<TblWorkpieceDtl> TblWorkpieceDtls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=192.168.10.250;database=ProjectManagementDB;User Id=prjMUser;Password=hmd@B@1prjM;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS");

            modelBuilder.Entity<TblCommunicationStep>(entity =>
            {
                entity.HasKey(e => e.FldCommunicationStepId);

                entity.ToTable("Tbl_CommunicationStep");

                entity.Property(e => e.FldCommunicationStepId)
                    .HasColumnName("Fld_CommunicationStep_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldImplementationStepsId).HasColumnName("Fld_ImplementationSteps_ID");

                entity.Property(e => e.FldImplementationStepsRelatedId).HasColumnName("Fld_ImplementationSteps_RelatedID");

                entity.Property(e => e.FldTypeOfCommunicationStepId).HasColumnName("Fld_TypeOfCommunicationStep_ID");

                entity.HasOne(d => d.FldImplementationSteps)
                    .WithMany(p => p.TblCommunicationStepFldImplementationSteps)
                    .HasForeignKey(d => d.FldImplementationStepsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CommunicationStep_Tbl_ImplementationSteps");

                entity.HasOne(d => d.FldImplementationStepsRelated)
                    .WithMany(p => p.TblCommunicationStepFldImplementationStepsRelateds)
                    .HasForeignKey(d => d.FldImplementationStepsRelatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CommunicationStep_Tbl_ImplementationSteps1");

                entity.HasOne(d => d.FldTypeOfCommunicationStep)
                    .WithMany(p => p.TblCommunicationSteps)
                    .HasForeignKey(d => d.FldTypeOfCommunicationStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CommunicationStep_Tbl_TypeOfCommunicationStep");
            });

            modelBuilder.Entity<TblExecutionStrategy>(entity =>
            {
                entity.HasKey(e => e.FldExecutionStrategyId);

                entity.ToTable("Tbl_ExecutionStrategy");

                entity.Property(e => e.FldExecutionStrategyId)
                    .HasColumnName("Fld_ExecutionStrategy_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldExecutionStrategyTxt)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_ExecutionStrategy_txt");

                entity.Property(e => e.FldWorkTypeId).HasColumnName("Fld_WorkType_ID");

                entity.HasOne(d => d.FldWorkType)
                    .WithMany(p => p.TblExecutionStrategies)
                    .HasForeignKey(d => d.FldWorkTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ExecutionStrategy_Tbl_WorkType");
            });

            modelBuilder.Entity<TblImplementationStep>(entity =>
            {
                entity.HasKey(e => e.FldImplementationStepsId);

                entity.ToTable("Tbl_ImplementationSteps");

                entity.Property(e => e.FldImplementationStepsId)
                    .HasColumnName("Fld_ImplementationSteps_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldExecutionStrategyId).HasColumnName("Fld_ExecutionStrategy_ID");

                entity.Property(e => e.FldImplementationStepsTxt)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("Fld_ImplementationSteps_txt")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectId).HasColumnName("Fld_Project_ID");

                entity.HasOne(d => d.FldExecutionStrategy)
                    .WithMany(p => p.TblImplementationSteps)
                    .HasForeignKey(d => d.FldExecutionStrategyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ImplementationSteps_Tbl_ExecutionStrategy");

                entity.HasOne(d => d.FldProject)
                    .WithMany(p => p.TblImplementationSteps)
                    .HasForeignKey(d => d.FldProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ImplementationSteps_Tbl_Project");
            });

            modelBuilder.Entity<TblMold>(entity =>
            {
                entity.HasKey(e => e.FldMoldId);

                entity.ToTable("Tbl_Mold");

                entity.Property(e => e.FldMoldId)
                    .HasColumnName("Fld_Mold_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldModelId).HasColumnName("Fld_Model_ID");

                entity.Property(e => e.FldMoldTxt)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_Mold_txt");
            });

            modelBuilder.Entity<TblMoldWorkpiece>(entity =>
            {
                entity.HasKey(e => e.FldMoldWorkpieceId);

                entity.ToTable("Tbl_MoldWorkpiece");

                entity.Property(e => e.FldMoldWorkpieceId)
                    .HasColumnName("Fld_MoldWorkpiece_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldMoldId).HasColumnName("Fld_Mold_ID");

                entity.Property(e => e.FldWorkpieceId).HasColumnName("Fld_Workpiece_ID");

                entity.HasOne(d => d.FldMold)
                    .WithMany(p => p.TblMoldWorkpieces)
                    .HasForeignKey(d => d.FldMoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MoldWorkpiece_Tbl_Mold");

                entity.HasOne(d => d.FldWorkpiece)
                    .WithMany(p => p.TblMoldWorkpieces)
                    .HasForeignKey(d => d.FldWorkpieceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MoldWorkpiece_Tbl_Workpiece");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.FldProjectId);

                entity.ToTable("Tbl_Project");

                entity.Property(e => e.FldProjectId)
                    .HasColumnName("Fld_Project_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectDeadlineForCompletion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_Project_DeadlineForCompletion");

                entity.Property(e => e.FldProjectExecutorDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_Project_ExecutorDate");

                entity.Property(e => e.FldProjectExecutorId).HasColumnName("Fld_Project_ExecutorID");

                entity.Property(e => e.FldProjectRegistrarDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_Project_RegistrarDate");

                entity.Property(e => e.FldProjectRegistrarId).HasColumnName("Fld_Project_RegistrarID");

                entity.Property(e => e.FldProjectTxt)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Fld_Project_txt");

                entity.Property(e => e.FldProjectTypeId).HasColumnName("Fld_ProjectType_ID");

                entity.Property(e => e.FldProjectVerifierDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_Project_VerifierDate");

                entity.Property(e => e.FldProjectVerifierId).HasColumnName("Fld_Project_VerifierID");

                entity.HasOne(d => d.FldProjectType)
                    .WithMany(p => p.TblProjects)
                    .HasForeignKey(d => d.FldProjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Project_Tbl_ProjectType");
            });

            modelBuilder.Entity<TblProjectFile>(entity =>
            {
                entity.HasKey(e => e.FldProjectFilesId);

                entity.ToTable("Tbl_ProjectFiles");

                entity.Property(e => e.FldProjectFilesId)
                    .HasColumnName("Fld_ProjectFiles_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectFileTypeId).HasColumnName("Fld_ProjectFileType_ID");

                entity.Property(e => e.FldProjectFilesDeleted).HasColumnName("Fld_ProjectFiles_Deleted");

                entity.Property(e => e.FldProjectFilesFileId).HasColumnName("Fld_ProjectFiles_FileID");

                entity.Property(e => e.FldProjectFilesOldFileId).HasColumnName("Fld_ProjectFiles_OldFileID");

                entity.Property(e => e.FldProjectId).HasColumnName("Fld_Project_ID");

                entity.Property(e => e.FldWorkpieceId).HasColumnName("Fld_Workpiece_ID");

                entity.HasOne(d => d.FldProjectFileType)
                    .WithMany(p => p.TblProjectFiles)
                    .HasForeignKey(d => d.FldProjectFileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectFiles_Tbl_ProjectFileType");

                entity.HasOne(d => d.FldProject)
                    .WithMany(p => p.TblProjectFiles)
                    .HasForeignKey(d => d.FldProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectFiles_Tbl_Project");

                entity.HasOne(d => d.FldWorkpiece)
                    .WithMany(p => p.TblProjectFiles)
                    .HasForeignKey(d => d.FldWorkpieceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectFiles_Tbl_Workpiece");
            });

            modelBuilder.Entity<TblProjectFileType>(entity =>
            {
                entity.HasKey(e => e.FldProjectFileTypeId);

                entity.ToTable("Tbl_ProjectFileType");

                entity.Property(e => e.FldProjectFileTypeId)
                    .HasColumnName("Fld_ProjectFileType_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectFileTypeTxt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Fld_ProjectFileType_txt")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TblProjectMold>(entity =>
            {
                entity.HasKey(e => e.FldProjectMoldId);

                entity.ToTable("Tbl_ProjectMold");

                entity.Property(e => e.FldProjectMoldId)
                    .HasColumnName("Fld_ProjectMold_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldMoldId).HasColumnName("Fld_Mold_ID");

                entity.Property(e => e.FldProjectId).HasColumnName("Fld_Project_ID");

                entity.HasOne(d => d.FldMold)
                    .WithMany(p => p.TblProjectMolds)
                    .HasForeignKey(d => d.FldMoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectMold_Tbl_Mold");

                entity.HasOne(d => d.FldProject)
                    .WithMany(p => p.TblProjectMolds)
                    .HasForeignKey(d => d.FldProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectMold_Tbl_Project");
            });

            modelBuilder.Entity<TblProjectMoldWorkpiece>(entity =>
            {
                entity.HasKey(e => e.FldProjectMoldWorkpieceId);

                entity.ToTable("Tbl_ProjectMoldWorkpiece");

                entity.Property(e => e.FldProjectMoldWorkpieceId)
                    .HasColumnName("Fld_ProjectMoldWorkpiece_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectMoldId).HasColumnName("Fld_ProjectMold_ID");

                entity.Property(e => e.FldProjectMoldWorkpieceBasePointX)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_BasePointX");

                entity.Property(e => e.FldProjectMoldWorkpieceBasePointY)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_BasePointY");

                entity.Property(e => e.FldProjectMoldWorkpieceBasePointZ)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_BasePointZ");

                entity.Property(e => e.FldProjectMoldWorkpieceHeight)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_Height");

                entity.Property(e => e.FldProjectMoldWorkpieceLength)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_Length");

                entity.Property(e => e.FldProjectMoldWorkpieceWidth)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpiece_Width");

                entity.Property(e => e.FldWorkpieceId).HasColumnName("Fld_Workpiece_ID");

                entity.HasOne(d => d.FldProjectMold)
                    .WithMany(p => p.TblProjectMoldWorkpieces)
                    .HasForeignKey(d => d.FldProjectMoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectMoldWorkpiece_Tbl_ProjectMold");

                entity.HasOne(d => d.FldWorkpiece)
                    .WithMany(p => p.TblProjectMoldWorkpieces)
                    .HasForeignKey(d => d.FldWorkpieceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectMoldWorkpiece_Tbl_Workpiece");
            });

            modelBuilder.Entity<TblProjectMoldWorkpieceCheckpoint>(entity =>
            {
                entity.HasKey(e => e.FldProjectMoldWorkpieceCheckpointId);

                entity.ToTable("Tbl_ProjectMoldWorkpieceCheckpoint");

                entity.Property(e => e.FldProjectMoldWorkpieceCheckpointId)
                    .HasColumnName("Fld_ProjectMoldWorkpieceCheckpoint_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectMoldWorkpieceCheckpointBasePointX)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpieceCheckpoint_BasePointX");

                entity.Property(e => e.FldProjectMoldWorkpieceCheckpointBasePointY)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpieceCheckpoint_BasePointY");

                entity.Property(e => e.FldProjectMoldWorkpieceCheckpointBasePointZ)
                    .HasColumnType("decimal(27, 9)")
                    .HasColumnName("Fld_ProjectMoldWorkpieceCheckpoint_BasePointZ");

                entity.Property(e => e.FldProjectMoldWorkpieceId).HasColumnName("Fld_ProjectMoldWorkpiece_ID");

                entity.HasOne(d => d.FldProjectMoldWorkpiece)
                    .WithMany(p => p.TblProjectMoldWorkpieceCheckpoints)
                    .HasForeignKey(d => d.FldProjectMoldWorkpieceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectMoldWorkpieceCheckpoint_Tbl_ProjectMoldWorkpiece");
            });

            modelBuilder.Entity<TblProjectType>(entity =>
            {
                entity.HasKey(e => e.FldProjectTypeId);

                entity.ToTable("Tbl_ProjectType");

                entity.Property(e => e.FldProjectTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_ProjectType_ID");

                entity.Property(e => e.FldProjectTypeTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_ProjectType_txt");
            });

            modelBuilder.Entity<TblSoftwareUsed>(entity =>
            {
                entity.HasKey(e => e.FldSoftwareUsedId);

                entity.ToTable("Tbl_SoftwareUsed");

                entity.Property(e => e.FldSoftwareUsedId)
                    .HasColumnName("Fld_SoftwareUsed_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldSoftwareUsedManufacturer)
                    .HasMaxLength(200)
                    .HasColumnName("Fld_SoftwareUsed_Manufacturer");

                entity.Property(e => e.FldSoftwareUsedTxt)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_SoftwareUsed_txt");
            });

            modelBuilder.Entity<TblSoftwareUsedProjectFileType>(entity =>
            {
                entity.HasKey(e => e.FldSoftwareUsedProjectFileTypeId);

                entity.ToTable("Tbl_SoftwareUsedProjectFileType");

                entity.Property(e => e.FldSoftwareUsedProjectFileTypeId)
                    .HasColumnName("Fld_SoftwareUsedProjectFileType_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldProjectFileTypeId).HasColumnName("Fld_ProjectFileType_ID");

                entity.Property(e => e.FldSoftwareUsedId).HasColumnName("Fld_SoftwareUsed_ID");

                entity.HasOne(d => d.FldProjectFileType)
                    .WithMany(p => p.TblSoftwareUsedProjectFileTypes)
                    .HasForeignKey(d => d.FldProjectFileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SoftwareUsedProjectFileType_Tbl_ProjectFileType");

                entity.HasOne(d => d.FldSoftwareUsed)
                    .WithMany(p => p.TblSoftwareUsedProjectFileTypes)
                    .HasForeignKey(d => d.FldSoftwareUsedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_SoftwareUsedProjectFileType_Tbl_SoftwareUsed");
            });

            modelBuilder.Entity<TblTypeOfCommunicationStep>(entity =>
            {
                entity.HasKey(e => e.FldTypeOfCommunicationStepId);

                entity.ToTable("Tbl_TypeOfCommunicationStep");

                entity.Property(e => e.FldTypeOfCommunicationStepId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_TypeOfCommunicationStep_ID");

                entity.Property(e => e.FldTypeOfCommunicationStepTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_TypeOfCommunicationStep_txt");
            });

            modelBuilder.Entity<TblWorkType>(entity =>
            {
                entity.HasKey(e => e.FldWorkTypeId);

                entity.ToTable("Tbl_WorkType");

                entity.Property(e => e.FldWorkTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_WorkType_ID");

                entity.Property(e => e.FldWorkTypeTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Fld_WorkType_txt");
            });

            modelBuilder.Entity<TblWorkpiece>(entity =>
            {
                entity.HasKey(e => e.FldWorkpieceId);

                entity.ToTable("Tbl_Workpiece");

                entity.Property(e => e.FldWorkpieceId)
                    .HasColumnName("Fld_Workpiece_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldWorkpieceIsCombination).HasColumnName("Fld_Workpiece_IsCombination");

                entity.Property(e => e.FldWorkpieceTxt)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("Fld_Workpiece_txt");
            });

            modelBuilder.Entity<TblWorkpieceDtl>(entity =>
            {
                entity.HasKey(e => e.FldWorkpieceDtlId);

                entity.ToTable("Tbl_WorkpieceDtl");

                entity.Property(e => e.FldWorkpieceDtlId)
                    .HasColumnName("Fld_WorkpieceDtl_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FldWorkpieceCompositionComponentsId).HasColumnName("Fld_Workpiece_CompositionComponentsID");

                entity.Property(e => e.FldWorkpieceId).HasColumnName("Fld_Workpiece_ID");

                entity.HasOne(d => d.FldWorkpieceCompositionComponents)
                    .WithMany(p => p.TblWorkpieceDtlFldWorkpieceCompositionComponents)
                    .HasForeignKey(d => d.FldWorkpieceCompositionComponentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_WorkpieceDtl_Tbl_Workpiece1");

                entity.HasOne(d => d.FldWorkpiece)
                    .WithMany(p => p.TblWorkpieceDtlFldWorkpieces)
                    .HasForeignKey(d => d.FldWorkpieceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_WorkpieceDtl_Tbl_Workpiece");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
