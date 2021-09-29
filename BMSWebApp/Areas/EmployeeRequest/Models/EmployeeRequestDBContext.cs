using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeRequest.Models
{
    public partial class EmployeeRequestDBContext : DbContext
    {
        public EmployeeRequestDBContext()
        {
        }

        public EmployeeRequestDBContext(DbContextOptions<EmployeeRequestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Outline> Outlines { get; set; }
        public virtual DbSet<OutlineVersion> OutlineVersions { get; set; }
        public virtual DbSet<PayDeanery> PayDeaneries { get; set; }
        public virtual DbSet<PayDiploma> PayDiplomas { get; set; }
        public virtual DbSet<PayEducation> PayEducations { get; set; }
        public virtual DbSet<PayJob> PayJobs { get; set; }
        public virtual DbSet<PayWorkPlace> PayWorkPlaces { get; set; }
        public virtual DbSet<Ping> Pings { get; set; }
        public virtual DbSet<TblCustomerDegree> TblCustomerDegrees { get; set; }
        public virtual DbSet<TblDefinition> TblDefinitions { get; set; }
        public virtual DbSet<TblEmployeeRequestCompilationType> TblEmployeeRequestCompilationTypes { get; set; }
        public virtual DbSet<TblEmployeeRequestCreativityType> TblEmployeeRequestCreativityTypes { get; set; }
        public virtual DbSet<TblEmployeeRequestEmergencyCall> TblEmployeeRequestEmergencyCalls { get; set; }
        public virtual DbSet<TblEmployeeRequestEmployee> TblEmployeeRequestEmployees { get; set; }
        public virtual DbSet<TblEmployeeRequestEmployeeEditLog> TblEmployeeRequestEmployeeEditLogs { get; set; }
        public virtual DbSet<TblEmployeeRequestEmployeeRequest> TblEmployeeRequestEmployeeRequests { get; set; }
        public virtual DbSet<TblEmployeeRequestFinalAcception> TblEmployeeRequestFinalAcceptions { get; set; }
        public virtual DbSet<TblEmployeeRequestGeneralRecord> TblEmployeeRequestGeneralRecords { get; set; }
        public virtual DbSet<TblEmployeeRequestHelp> TblEmployeeRequestHelps { get; set; }
        public virtual DbSet<TblEmployeeRequestHowFind> TblEmployeeRequestHowFinds { get; set; }
        public virtual DbSet<TblEmployeeRequestInterviewSession> TblEmployeeRequestInterviewSessions { get; set; }
        public virtual DbSet<TblEmployeeRequestIpLog> TblEmployeeRequestIpLogs { get; set; }
        public virtual DbSet<TblEmployeeRequestJob> TblEmployeeRequestJobs { get; set; }
        public virtual DbSet<TblEmployeeRequestJobTitleFrom> TblEmployeeRequestJobTitleFroms { get; set; }
        public virtual DbSet<TblEmployeeRequestLanguageType> TblEmployeeRequestLanguageTypes { get; set; }
        public virtual DbSet<TblEmployeeRequestLink> TblEmployeeRequestLinks { get; set; }
        public virtual DbSet<TblEmployeeRequestMedicalRecord> TblEmployeeRequestMedicalRecords { get; set; }
        public virtual DbSet<TblEmployeeRequestMilitary> TblEmployeeRequestMilitaries { get; set; }
        public virtual DbSet<TblEmployeeRequestMilitaryOrganization> TblEmployeeRequestMilitaryOrganizations { get; set; }
        public virtual DbSet<TblEmployeeRequestPageTimeLog> TblEmployeeRequestPageTimeLogs { get; set; }
        public virtual DbSet<TblEmployeeRequestPagesSequence> TblEmployeeRequestPagesSequences { get; set; }
        public virtual DbSet<TblEmployeeRequestPrimaryAcception> TblEmployeeRequestPrimaryAcceptions { get; set; }
        public virtual DbSet<TblEmployeeRequestPrimaryInformation> TblEmployeeRequestPrimaryInformations { get; set; }
        public virtual DbSet<TblEmployeeRequestSkill> TblEmployeeRequestSkills { get; set; }
        public virtual DbSet<TblEmployeeRequestSmsReceived> TblEmployeeRequestSmsReceiveds { get; set; }
        public virtual DbSet<TblEmployeeRequestSmsSent> TblEmployeeRequestSmsSents { get; set; }
        public virtual DbSet<TblEmployeeRequestUser> TblEmployeeRequestUsers { get; set; }
        public virtual DbSet<TblEmployeeRequestUserCompilation> TblEmployeeRequestUserCompilations { get; set; }
        public virtual DbSet<TblEmployeeRequestUserCreativity> TblEmployeeRequestUserCreativities { get; set; }
        public virtual DbSet<TblEmployeeRequestUserJob> TblEmployeeRequestUserJobs { get; set; }
        public virtual DbSet<TblEmployeeRequestUserLanguage> TblEmployeeRequestUserLanguages { get; set; }
        public virtual DbSet<TblEmployeeRequestUserMilitary> TblEmployeeRequestUserMilitaries { get; set; }
        public virtual DbSet<TblEmployeeRequestUserSetting> TblEmployeeRequestUserSettings { get; set; }
        public virtual DbSet<TblEmployeeRequestUserSkill> TblEmployeeRequestUserSkills { get; set; }
        public virtual DbSet<TblJob> TblJobs { get; set; }
        public virtual DbSet<TblJobTamin> TblJobTamins { get; set; }
        public virtual DbSet<TblLeaveJob> TblLeaveJobs { get; set; }
        public virtual DbSet<TblUserSuggestion> TblUserSuggestions { get; set; }
        public virtual DbSet<TblWebsite> TblWebsites { get; set; }
        public virtual DbSet<TblWebsiteType> TblWebsiteTypes { get; set; }
        public virtual DbSet<TblWorkExperience> TblWorkExperiences { get; set; }
        public virtual DbSet<TblWorkExperienceLeaveJobDtl> TblWorkExperienceLeaveJobDtls { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Version> Versions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.10.250;database=EmployeeRequestDB;User Id=EmplyUser2;Password=S33@||;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AS");

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Outline>(entity =>
            {
                entity.ToTable("Outline");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EnglishDescription).HasMaxLength(4000);

                entity.Property(e => e.EnglishTitle).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<OutlineVersion>(entity =>
            {
                entity.ToTable("Outline_Version");

                entity.Property(e => e.OutlineId).HasColumnName("Outline_Id");

                entity.Property(e => e.TopicId).HasColumnName("Topic_Id");

                entity.Property(e => e.VersionId).HasColumnName("Version_Id");

                entity.HasOne(d => d.Outline)
                    .WithMany(p => p.OutlineVersions)
                    .HasForeignKey(d => d.OutlineId)
                    .HasConstraintName("FK_Outline_Version_Outline");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.OutlineVersions)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_Outline_Version_Topic");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.OutlineVersions)
                    .HasForeignKey(d => d.VersionId)
                    .HasConstraintName("FK_Outline_Version_Version");
            });

            modelBuilder.Entity<PayDeanery>(entity =>
            {
                entity.HasKey(e => e.DeaneryId);

                entity.ToTable("Pay_Deanery");

                entity.Property(e => e.DeaneryId).HasColumnName("Deanery_ID");

                entity.Property(e => e.DeaneryCompanyRef).HasColumnName("Deanery_Company_Ref");

                entity.Property(e => e.DeaneryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Deanery_Name");
            });

            modelBuilder.Entity<PayDiploma>(entity =>
            {
                entity.HasKey(e => e.DiplomaId);

                entity.ToTable("Pay_Diploma");

                entity.HasIndex(e => e.DiplomaName, "IX_Pay_Diploma")
                    .IsUnique();

                entity.Property(e => e.DiplomaId).HasColumnName("Diploma_ID");

                entity.Property(e => e.DiplomaCode).HasColumnName("Diploma_Code");

                entity.Property(e => e.DiplomaName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Diploma_Name");
            });

            modelBuilder.Entity<PayEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.ToTable("Pay_Education");

                entity.HasIndex(e => e.EducationName, "IX_Pay_Education")
                    .IsUnique();

                entity.Property(e => e.EducationId).HasColumnName("Education_ID");

                entity.Property(e => e.EducationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Education_Name")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<PayJob>(entity =>
            {
                entity.HasKey(e => e.JobsId);

                entity.ToTable("Pay_Jobs");

                entity.Property(e => e.JobsId).HasColumnName("Jobs_ID");

                entity.Property(e => e.JobsCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Jobs_Code");

                entity.Property(e => e.JobsCompanyRef).HasColumnName("Jobs_Company_Ref");

                entity.Property(e => e.JobsDeaneryRef).HasColumnName("Jobs_Deanery_Ref");

                entity.Property(e => e.JobsName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Jobs_Name");

                entity.Property(e => e.JobsWorkPlaceRef).HasColumnName("Jobs_WorkPlace_Ref");

                entity.HasOne(d => d.JobsDeaneryRefNavigation)
                    .WithMany(p => p.PayJobs)
                    .HasForeignKey(d => d.JobsDeaneryRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pay_Jobs_Pay_Deanery");

                entity.HasOne(d => d.JobsWorkPlaceRefNavigation)
                    .WithMany(p => p.PayJobs)
                    .HasForeignKey(d => d.JobsWorkPlaceRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pay_Jobs_Pay_WorkPlace");
            });

            modelBuilder.Entity<PayWorkPlace>(entity =>
            {
                entity.HasKey(e => e.WorkPlaceId);

                entity.ToTable("Pay_WorkPlace");

                entity.Property(e => e.WorkPlaceId).HasColumnName("WorkPlace_ID");

                entity.Property(e => e.WorkPlaceCompanyRef).HasColumnName("WorkPlace_Company_Ref");

                entity.Property(e => e.WorkPlaceName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("WorkPlace_Name");

                entity.Property(e => e.WorkPlaceWorkPlaceRef).HasColumnName("WorkPlace_WorkPlace_Ref");

                entity.HasOne(d => d.WorkPlaceWorkPlaceRefNavigation)
                    .WithMany(p => p.InverseWorkPlaceWorkPlaceRefNavigation)
                    .HasForeignKey(d => d.WorkPlaceWorkPlaceRef)
                    .HasConstraintName("FK_Pay_WorkPlace_Pay_WorkPlace");
            });

            modelBuilder.Entity<Ping>(entity =>
            {
                entity.ToTable("Ping");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblCustomerDegree>(entity =>
            {
                entity.HasKey(e => e.FldCustomerDegreeId);

                entity.ToTable("Tbl_CustomerDegree");

                entity.Property(e => e.FldCustomerDegreeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_CustomerDegreeID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.DiplomaId).HasColumnName("Diploma_ID");

                entity.Property(e => e.EducationId).HasColumnName("Education_ID");

                entity.Property(e => e.FldDes)
                    .HasMaxLength(500)
                    .HasColumnName("Fld_Des");

                entity.Property(e => e.FldEducationName)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EducationName");

                entity.Property(e => e.FldEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EndDate");

                entity.Property(e => e.FldExportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_ExportDate");

                entity.Property(e => e.FldExportNo)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_ExportNO");

                entity.Property(e => e.FldPoint)
                    .HasMaxLength(5)
                    .HasColumnName("Fld_Point");

                entity.Property(e => e.FldStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_StartDate");

                entity.Property(e => e.FldStudyCity)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_StudyCity");

                entity.Property(e => e.FldStudyPlace)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_StudyPlace");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("User_Id");

                entity.HasOne(d => d.Diploma)
                    .WithMany(p => p.TblCustomerDegrees)
                    .HasForeignKey(d => d.DiplomaId)
                    .HasConstraintName("FK_Tbl_CustomerDegree_Pay_Diploma");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.TblCustomerDegrees)
                    .HasForeignKey(d => d.EducationId)
                    .HasConstraintName("FK_Tbl_CustomerDegree_Pay_Education");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCustomerDegrees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Tbl_CustomerDegree_Tbl_User");
            });

            modelBuilder.Entity<TblDefinition>(entity =>
            {
                entity.ToTable("Tbl_Definition");

                entity.Property(e => e.Definition).HasMaxLength(150);
            });

            modelBuilder.Entity<TblEmployeeRequestCompilationType>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestCompilationTypeId)
                    .HasName("PK_Tbl_CompilationType");

                entity.ToTable("Tbl_EmployeeRequest_CompilationType");

                entity.Property(e => e.FldEmployeeRequestCompilationTypeId).HasColumnName("Fld_EmployeeRequest_CompilationType_Id");

                entity.Property(e => e.FldEmployeeRequestCompilationTypeCompilationType)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_CompilationType_CompilationType");
            });

            modelBuilder.Entity<TblEmployeeRequestCreativityType>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestCreativityTypeId)
                    .HasName("PK_Tbl_CreativityType");

                entity.ToTable("Tbl_EmployeeRequest_CreativityType");

                entity.Property(e => e.FldEmployeeRequestCreativityTypeId).HasColumnName("Fld_EmployeeRequest_CreativityType_Id");

                entity.Property(e => e.FldEmployeeRequestCreativityTypeCreativityType)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_CreativityType_CreativityType");
            });

            modelBuilder.Entity<TblEmployeeRequestEmergencyCall>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestEmergencyCallId)
                    .HasName("PK_Tbl_EmergencyCall");

                entity.ToTable("Tbl_EmployeeRequest_EmergencyCall");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_Id");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_Description");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_FirstName");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallInsuranceNo)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_InsuranceNo");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_LastName");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallPhoneNo)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_PhoneNo");

                entity.Property(e => e.FldEmployeeRequestEmergencyCallRelative)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmergencyCall_Relative");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestEmergencyCalls)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_EmergencyCall_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestEmployee>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestEmployeeId)
                    .HasName("PK_Tbl_User");

                entity.ToTable("Tbl_EmployeeRequest_Employee");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeCurrentLevel)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_Employee_CurrentLevel");

                entity.Property(e => e.FldEmployeeRequestEmployeeFinalAcceptDescription).HasColumnName("Fld_EmployeeRequest_Employee_FinalAcceptDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeFinalAcceptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Employee_FinalAcceptionDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeFinalRejectDescription).HasColumnName("Fld_EmployeeRequest_Employee_FinalRejectDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeInterviewEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Employee_InterviewEndDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeInterviewStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Employee_InterviewStartDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeMaxPoint).HasColumnName("Fld_EmployeeRequest_Employee_MaxPoint");

                entity.Property(e => e.FldEmployeeRequestEmployeePassword)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Password");

                entity.Property(e => e.FldEmployeeRequestEmployeePrimaryAcceptDescription).HasColumnName("Fld_EmployeeRequest_Employee_PrimaryAcceptDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeePrimaryAcceptionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Employee_PrimaryAcceptionDate");

                entity.Property(e => e.FldEmployeeRequestEmployeePrimaryRejectDescription).HasColumnName("Fld_EmployeeRequest_Employee_PrimaryRejectDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeRejectFromUserDescription).HasColumnName("Fld_EmployeeRequest_Employee_RejectFromUserDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeResultPoint).HasColumnName("Fld_EmployeeRequest_Employee_ResultPoint");

                entity.Property(e => e.FldEmployeeRequestEmployeeUsername)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Username");

                entity.Property(e => e.FldEmployeeRequestFinalAcceptionId).HasColumnName("Fld_EmployeeRequest_FinalAcception_Id");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceId).HasColumnName("Fld_EmployeeRequest_PagesSequence_Id");

                entity.Property(e => e.FldEmployeeRequestPrimaryAcceptionId).HasColumnName("Fld_EmployeeRequest_PrimaryAcception_Id");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.TransferedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FldEmployeeRequestFinalAcception)
                    .WithMany(p => p.TblEmployeeRequestEmployees)
                    .HasForeignKey(d => d.FldEmployeeRequestFinalAcceptionId)
                    .HasConstraintName("FK_Tbl_User_Tbl_FinalAcception");

                entity.HasOne(d => d.FldEmployeeRequestPagesSequence)
                    .WithMany(p => p.TblEmployeeRequestEmployees)
                    .HasForeignKey(d => d.FldEmployeeRequestPagesSequenceId)
                    .HasConstraintName("FK_Tbl_User_Tbl_PagesSequence");

                entity.HasOne(d => d.FldEmployeeRequestPrimaryAcception)
                    .WithMany(p => p.TblEmployeeRequestEmployees)
                    .HasForeignKey(d => d.FldEmployeeRequestPrimaryAcceptionId)
                    .HasConstraintName("FK_Tbl_User_Tbl_PrimaryAcception");

                entity.HasOne(d => d.FldEmployeeRequestUserFinalAccepter)
                    .WithMany(p => p.TblEmployeeRequestEmployeeFldEmployeeRequestUserFinalAccepters)
                    .HasForeignKey(d => d.FldEmployeeRequestUserFinalAccepterId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_Employee_Tbl_EmployeeRequest_User");

                entity.HasOne(d => d.FldEmployeeRequestUserPrimaryAccepter)
                    .WithMany(p => p.TblEmployeeRequestEmployeeFldEmployeeRequestUserPrimaryAccepters)
                    .HasForeignKey(d => d.FldEmployeeRequestUserPrimaryAccepterId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_Employee_Tbl_EmployeeRequest_User1");
            });

            modelBuilder.Entity<TblEmployeeRequestEmployeeEditLog>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestEmployeeEditLogId);

                entity.ToTable("Tbl_EmployeeRequest_EmployeeEditLog");

                entity.Property(e => e.FldEmployeeRequestEmployeeEditLogId).HasColumnName("Fld_EmployeeRequest_EmployeeEditLog_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeEditLogDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeEditLog_Date");

                entity.Property(e => e.FldEmployeeRequestEmployeeEditLogSection)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_EmployeeEditLog_Section");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestUserId).HasColumnName("Fld_EmployeeRequest_User_Id");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestEmployeeEditLogs)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeEditLog_Tbl_EmployeeRequest_Employee");

                entity.HasOne(d => d.FldEmployeeRequestUser)
                    .WithMany(p => p.TblEmployeeRequestEmployeeEditLogs)
                    .HasForeignKey(d => d.FldEmployeeRequestUserId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeEditLog_Tbl_EmployeeRequest_User");
            });

            modelBuilder.Entity<TblEmployeeRequestEmployeeRequest>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestEmployeeRequestId)
                    .HasName("PK_Tbl_EmployeeRequest");

                entity.ToTable("Tbl_EmployeeRequest_EmployeeRequest");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestId).HasColumnName("Fld_EmployeeRequest_EmployeeRequest_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestAcceptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_AcceptDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestApplicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_ApplicationDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_EndDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestInternalDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_InternalDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestIsAccept).HasColumnName("Fld_EmployeeRequest_EmployeeRequest_IsAccept");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestIsTransfered).HasColumnName("Fld_EmployeeRequest_EmployeeRequest_IsTransfered");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestJobDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_JobDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestNeedMan).HasColumnName("Fld_EmployeeRequest_EmployeeRequest_NeedMan");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestNeedWoman).HasColumnName("Fld_EmployeeRequest_EmployeeRequest_NeedWoman");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestPublishDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_PublishDescription");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_StartDate");

                entity.Property(e => e.FldEmployeeRequestEmployeeRequestTransferDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_EmployeeRequest_TransferDate");

                entity.Property(e => e.FldEmployeeRequestJobOnetId).HasColumnName("Fld_EmployeeRequest_JobOnet_Id");

                entity.Property(e => e.FldEmployeeRequestJobTaminId).HasColumnName("Fld_EmployeeRequest_JobTamin_Id");

                entity.Property(e => e.FldEmployeeRequestJobTitleFromId).HasColumnName("Fld_EmployeeRequest_JobTitleFrom_Id");

                entity.Property(e => e.FldEmployeeRequestJobsId).HasColumnName("Fld_EmployeeRequest_Jobs_ID");

                entity.Property(e => e.FldEmployeeRequestUserAccepterId).HasColumnName("Fld_EmployeeRequest_User_AccepterId");

                entity.Property(e => e.FldEmployeeRequestUserApplicantId).HasColumnName("Fld_EmployeeRequest_User_ApplicantId");

                entity.Property(e => e.FldEmployeeRequestUserSubmitterId).HasColumnName("Fld_EmployeeRequest_User_SubmitterId");

                entity.HasOne(d => d.FldEmployeeRequestJobOnet)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequests)
                    .HasForeignKey(d => d.FldEmployeeRequestJobOnetId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Tbl_Job");

                entity.HasOne(d => d.FldEmployeeRequestJobTamin)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequests)
                    .HasForeignKey(d => d.FldEmployeeRequestJobTaminId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_Tbl_JobTamin");

                entity.HasOne(d => d.FldEmployeeRequestJobTitleFrom)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequests)
                    .HasForeignKey(d => d.FldEmployeeRequestJobTitleFromId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Tbl_EmployeeRequest_JobTitleFrom");

                entity.HasOne(d => d.FldEmployeeRequestJobs)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequests)
                    .HasForeignKey(d => d.FldEmployeeRequestJobsId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Pay_Jobs");

                entity.HasOne(d => d.FldEmployeeRequestUserAccepter)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserAccepters)
                    .HasForeignKey(d => d.FldEmployeeRequestUserAccepterId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Tbl_EmployeeRequest_User1");

                entity.HasOne(d => d.FldEmployeeRequestUserApplicant)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserApplicants)
                    .HasForeignKey(d => d.FldEmployeeRequestUserApplicantId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Tbl_EmployeeRequest_User");

                entity.HasOne(d => d.FldEmployeeRequestUserSubmitter)
                    .WithMany(p => p.TblEmployeeRequestEmployeeRequestFldEmployeeRequestUserSubmitters)
                    .HasForeignKey(d => d.FldEmployeeRequestUserSubmitterId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_EmployeeRequest_Tbl_EmployeeRequest_User2");
            });

            modelBuilder.Entity<TblEmployeeRequestFinalAcception>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestFinalAcceptionId)
                    .HasName("PK_Tbl_FinalAcception");

                entity.ToTable("Tbl_EmployeeRequest_FinalAcception");

                entity.Property(e => e.FldEmployeeRequestFinalAcceptionId).HasColumnName("Fld_EmployeeRequest_FinalAcception_Id");

                entity.Property(e => e.FldEmployeeRequestFinalAcceptionStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_FinalAcception_Status");
            });

            modelBuilder.Entity<TblEmployeeRequestGeneralRecord>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestGeneralRecordId)
                    .HasName("PK_Tbl_GeneralRecord");

                entity.ToTable("Tbl_EmployeeRequest_GeneralRecord");

                entity.Property(e => e.FldEmployeeRequestGeneralRecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_GeneralRecord_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestGeneralRecordCriminalDes)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_GeneralRecord_CriminalDes");

                entity.Property(e => e.FldEmployeeRequestGeneralRecordCriminalTiltle)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_GeneralRecord_CriminalTiltle");

                entity.Property(e => e.FldEmployeeRequestGeneralRecordDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_GeneralRecord_Description");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestGeneralRecords)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_GeneralRecord_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestHelp>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestHelpId);

                entity.ToTable("Tbl_EmployeeRequest_Help");

                entity.Property(e => e.FldEmployeeRequestHelpId).HasColumnName("Fld_EmployeeRequest_Help_Id");

                entity.Property(e => e.FldEmployeeRequestHelpDescription).HasColumnName("Fld_EmployeeRequest_Help_Description");

                entity.Property(e => e.FldEmployeeRequestHelpName)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_Help_Name");
            });

            modelBuilder.Entity<TblEmployeeRequestHowFind>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestHowFindId)
                    .HasName("PK_Tbl_HowFind");

                entity.ToTable("Tbl_EmployeeRequest_HowFind");

                entity.Property(e => e.FldEmployeeRequestHowFindId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_HowFind_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestHowFindAdditionalDes)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_HowFind_AdditionalDes");

                entity.Property(e => e.FldEmployeeRequestHowFindTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_HowFind_Title");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestHowFinds)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_HowFind_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestInterviewSession>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestInterviewSessionId)
                    .HasName("PK_Tbl_InterviewSession");

                entity.ToTable("Tbl_EmployeeRequest_InterviewSession");

                entity.Property(e => e.FldEmployeeRequestInterviewSessionId).HasColumnName("Fld_EmployeeRequest_InterviewSession_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestInterviewSessionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_InterviewSession_Date");

                entity.Property(e => e.FldEmployeeRequestInterviewSessionMaxPoint)
                    .HasColumnName("Fld_EmployeeRequest_InterviewSession_MaxPoint")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldEmployeeRequestInterviewSessionResultPoint)
                    .HasColumnName("Fld_EmployeeRequest_InterviewSession_ResultPoint")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldEmployeeRequestPrimaryAcceptionId).HasColumnName("Fld_EmployeeRequest_PrimaryAcception_Id");

                entity.Property(e => e.FldEmployeeRequestUserId).HasColumnName("Fld_EmployeeRequest_User_Id");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestInterviewSessions)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_InterviewSession_Tbl_User");

                entity.HasOne(d => d.FldEmployeeRequestPrimaryAcception)
                    .WithMany(p => p.TblEmployeeRequestInterviewSessions)
                    .HasForeignKey(d => d.FldEmployeeRequestPrimaryAcceptionId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_InterviewSession_Tbl_EmployeeRequest_PrimaryAcception");

                entity.HasOne(d => d.FldEmployeeRequestUser)
                    .WithMany(p => p.TblEmployeeRequestInterviewSessions)
                    .HasForeignKey(d => d.FldEmployeeRequestUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_InterviewSession_Tbl_Admin");
            });

            modelBuilder.Entity<TblEmployeeRequestIpLog>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestIpLogId)
                    .HasName("PK_Tbl_IpLog");

                entity.ToTable("Tbl_EmployeeRequest_IpLog");

                entity.Property(e => e.FldEmployeeRequestIpLogId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_IpLog_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestIpLogDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_IpLog_DateTime");

                entity.Property(e => e.FldEmployeeRequestIpLogIp)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_IpLog_Ip");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestIpLogs)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_IpLog_Tbl_User1");
            });

            modelBuilder.Entity<TblEmployeeRequestJob>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestJobsId)
                    .HasName("PK_Jobs");

                entity.ToTable("Tbl_EmployeeRequest_Jobs");

                entity.Property(e => e.FldEmployeeRequestJobsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_Jobs_Id");

                entity.Property(e => e.FldEmployeeRequestJobsDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_Jobs_Description");

                entity.Property(e => e.FldEmployeeRequestJobsEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Jobs_EndDate");

                entity.Property(e => e.FldEmployeeRequestJobsIsActive).HasColumnName("Fld_EmployeeRequest_Jobs_IsActive");

                entity.Property(e => e.FldEmployeeRequestJobsJobTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_Jobs_JobTitle");

                entity.Property(e => e.FldEmployeeRequestJobsNeedMan).HasColumnName("Fld_EmployeeRequest_Jobs_NeedMan");

                entity.Property(e => e.FldEmployeeRequestJobsNeedWoman).HasColumnName("Fld_EmployeeRequest_Jobs_NeedWoman");

                entity.Property(e => e.FldEmployeeRequestJobsStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Jobs_StartDate");
            });

            modelBuilder.Entity<TblEmployeeRequestJobTitleFrom>(entity =>
            {
                entity.ToTable("Tbl_EmployeeRequest_JobTitleFrom");

                entity.Property(e => e.TblEmployeeRequestJobTitleFromId).HasColumnName("Tbl_EmployeeRequest_JobTitleFrom_Id");

                entity.Property(e => e.TblEmployeeRequestJobTitleFromTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Tbl_EmployeeRequest_JobTitleFrom_Title");
            });

            modelBuilder.Entity<TblEmployeeRequestLanguageType>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestLanguageTypeId)
                    .HasName("PK_Tbl_LanguageType");

                entity.ToTable("Tbl_EmployeeRequest_LanguageType");

                entity.Property(e => e.FldEmployeeRequestLanguageTypeId).HasColumnName("Fld_EmployeeRequest_LanguageType_Id");

                entity.Property(e => e.FldEmployeeRequestLanguageTypeLanguageType)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_LanguageType_LanguageType");
            });

            modelBuilder.Entity<TblEmployeeRequestLink>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestLinkId)
                    .HasName("PK_Tbl_Link");

                entity.ToTable("Tbl_EmployeeRequest_Link");

                entity.Property(e => e.FldEmployeeRequestLinkId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Link_Id");

                entity.Property(e => e.FldEmployeeRequestLinkExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Link_ExpireDate");

                entity.Property(e => e.FldEmployeeRequestLinkPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Link_Phone");
            });

            modelBuilder.Entity<TblEmployeeRequestMedicalRecord>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestMedicalRecordId)
                    .HasName("PK_Tbl_MedicalRecord");

                entity.ToTable("Tbl_EmployeeRequest_MedicalRecord");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordComplicationsDes)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_ComplicationsDes")
                    .IsFixedLength(true);

                entity.Property(e => e.FldEmployeeRequestMedicalRecordDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_Description");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordDisease)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_Disease");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_EndDate");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordHasComplications).HasColumnName("Fld_EmployeeRequest_MedicalRecord_HasComplications");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordHasProblem).HasColumnName("Fld_EmployeeRequest_MedicalRecord_HasProblem");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordIsAddict).HasColumnName("Fld_EmployeeRequest_MedicalRecord_IsAddict");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordProblemDes)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_ProblemDes");

                entity.Property(e => e.FldEmployeeRequestMedicalRecordStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_MedicalRecord_StartDate");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestMedicalRecords)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_MedicalRecord_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestMilitary>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestMilitaryId)
                    .HasName("PK_Tbl_Military");

                entity.ToTable("Tbl_EmployeeRequest_Military");

                entity.Property(e => e.FldEmployeeRequestMilitaryId).HasColumnName("Fld_EmployeeRequest_Military_Id");

                entity.Property(e => e.FldEmployeeRequestMilitaryMilitaryStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Military_MilitaryStatus");
            });

            modelBuilder.Entity<TblEmployeeRequestMilitaryOrganization>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestMilitaryOrganizationId)
                    .HasName("PK_Tbl_MilitaryOrganization");

                entity.ToTable("Tbl_EmployeeRequest_MilitaryOrganization");

                entity.Property(e => e.FldEmployeeRequestMilitaryOrganizationId).HasColumnName("Fld_EmployeeRequest_MilitaryOrganization_Id");

                entity.Property(e => e.FldEmployeeRequestMilitaryOrganizationOrganizationName)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_MilitaryOrganization_OrganizationName");
            });

            modelBuilder.Entity<TblEmployeeRequestPageTimeLog>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestPageTimeLogId)
                    .HasName("PK_Tbl_PageTimeLog");

                entity.ToTable("Tbl_EmployeeRequest_PageTimeLog");

                entity.Property(e => e.FldEmployeeRequestPageTimeLogId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_PageTimeLog_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestPageTimeLogEndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_PageTimeLog_EndTime");

                entity.Property(e => e.FldEmployeeRequestPageTimeLogPageLevel)
                    .HasMaxLength(10)
                    .HasColumnName("Fld_EmployeeRequest_PageTimeLog_PageLevel");

                entity.Property(e => e.FldEmployeeRequestPageTimeLogStartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_PageTimeLog_StartTime");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestPageTimeLogs)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_PageTimeLog_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestPagesSequence>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestPagesSequenceId)
                    .HasName("PK_Tbl_PagesSequence");

                entity.ToTable("Tbl_EmployeeRequest_PagesSequence");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_PagesSequence_Id");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceEight).HasColumnName("Fld_EmployeeRequest_PagesSequence_Eight");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceEleven).HasColumnName("Fld_EmployeeRequest_PagesSequence_Eleven");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceFifteen).HasColumnName("Fld_EmployeeRequest_PagesSequence_Fifteen");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceFive).HasColumnName("Fld_EmployeeRequest_PagesSequence_Five");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceFour).HasColumnName("Fld_EmployeeRequest_PagesSequence_Four");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceFourteen).HasColumnName("Fld_EmployeeRequest_PagesSequence_Fourteen");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceNine).HasColumnName("Fld_EmployeeRequest_PagesSequence_Nine");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceOne).HasColumnName("Fld_EmployeeRequest_PagesSequence_One");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceRecord).HasColumnName("Fld_EmployeeRequest_PagesSequence_Record");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceSeven).HasColumnName("Fld_EmployeeRequest_PagesSequence_Seven");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceSix).HasColumnName("Fld_EmployeeRequest_PagesSequence_Six");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceSixteen).HasColumnName("Fld_EmployeeRequest_PagesSequence_Sixteen");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceStatus).HasColumnName("Fld_EmployeeRequest_PagesSequence_Status");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceTen).HasColumnName("Fld_EmployeeRequest_PagesSequence_Ten");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceThirteen).HasColumnName("Fld_EmployeeRequest_PagesSequence_Thirteen");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceThree).HasColumnName("Fld_EmployeeRequest_PagesSequence_Three");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceTwelve).HasColumnName("Fld_EmployeeRequest_PagesSequence_Twelve");

                entity.Property(e => e.FldEmployeeRequestPagesSequenceTwo).HasColumnName("Fld_EmployeeRequest_PagesSequence_Two");
            });

            modelBuilder.Entity<TblEmployeeRequestPrimaryAcception>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestPrimaryAcceptionId)
                    .HasName("PK_Tbl_PrimaryAcception");

                entity.ToTable("Tbl_EmployeeRequest_PrimaryAcception");

                entity.Property(e => e.FldEmployeeRequestPrimaryAcceptionId).HasColumnName("Fld_EmployeeRequest_PrimaryAcception_Id");

                entity.Property(e => e.FldEmployeeRequestPrimaryAcceptionStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryAcception_Status");
            });

            modelBuilder.Entity<TblEmployeeRequestPrimaryInformation>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestPrimaryInformationId)
                    .HasName("PK_Tbl_PrimaryInformation");

                entity.ToTable("Tbl_EmployeeRequest_PrimaryInformation");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationAddress)
                    .HasMaxLength(2000)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Address");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationAddress2)
                    .HasMaxLength(2000)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Address2");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_BirthDate");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationChildrenNo).HasColumnName("Fld_EmployeeRequest_PrimaryInformation_ChildrenNo");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_FirstName");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationGender)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Gender");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationLastName)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_LastName");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationMarital)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Marital");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationNationalCode)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_NationalCode");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationPhoneNo)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_PhoneNo");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationPostalCode)
                    .HasMaxLength(20)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_PostalCode");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationTrackNo)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_PrimaryInformation_TrackNo");

                entity.Property(e => e.FldEmployeeRequestPrimaryInformationTutelage).HasColumnName("Fld_EmployeeRequest_PrimaryInformation_Tutelage");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestPrimaryInformations)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_PrimaryInformation_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestSkill>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestSkillsId)
                    .HasName("PK_Skills");

                entity.ToTable("Tbl_EmployeeRequest_Skills");

                entity.Property(e => e.FldEmployeeRequestSkillsId).HasColumnName("Fld_EmployeeRequest_Skills_Id");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillActive)
                    .IsRequired()
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillDescription");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillEndDate");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillEnglishDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillEnglishDescription");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillEnglishTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillEnglishTitle");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillStartDate");

                entity.Property(e => e.FldEmployeeRequestSkillsSkillTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_Skills_SkillTitle");
            });

            modelBuilder.Entity<TblEmployeeRequestSmsReceived>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestSmsReceivedId)
                    .HasName("PK_SmsReceived");

                entity.ToTable("Tbl_EmployeeRequest_SmsReceived");

                entity.Property(e => e.FldEmployeeRequestSmsReceivedId).HasColumnName("Fld_EmployeeRequest_SmsReceived_Id");

                entity.Property(e => e.FldEmployeeRequestSmsReceivedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_SmsReceived_Date");

                entity.Property(e => e.FldEmployeeRequestSmsReceivedIsVisit).HasColumnName("Fld_EmployeeRequest_SmsReceived_IsVisit");

                entity.Property(e => e.FldEmployeeRequestSmsReceivedMessage)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_SmsReceived_Message");

                entity.Property(e => e.FldEmployeeRequestSmsReceivedPhone)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_SmsReceived_Phone");
            });

            modelBuilder.Entity<TblEmployeeRequestSmsSent>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestSmsSentId)
                    .HasName("PK_SmsSent");

                entity.ToTable("Tbl_EmployeeRequest_SmsSent");

                entity.Property(e => e.FldEmployeeRequestSmsSentId).HasColumnName("Fld_EmployeeRequest_SmsSent_Id");

                entity.Property(e => e.FldEmployeeRequestSmsSentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_SmsSent_Date");

                entity.Property(e => e.FldEmployeeRequestSmsSentMessage)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_SmsSent_Message");

                entity.Property(e => e.FldEmployeeRequestSmsSentPhone)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_SmsSent_Phone");
            });

            modelBuilder.Entity<TblEmployeeRequestUser>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserId)
                    .HasName("PK_Tbl_Admin");

                entity.ToTable("Tbl_EmployeeRequest_User");

                entity.Property(e => e.FldEmployeeRequestUserId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_User_Id");

                entity.Property(e => e.FldEmployeeRequestUserName)
                    .HasMaxLength(3000)
                    .HasColumnName("Fld_EmployeeRequest_User_Name");

                entity.Property(e => e.FldEmployeeRequestUserPassword)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_User_Password");

                entity.Property(e => e.FldEmployeeRequestUserUsername)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_User_Username");
            });

            modelBuilder.Entity<TblEmployeeRequestUserCompilation>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserCompilationId)
                    .HasName("PK_Tbl_UserCompilations");

                entity.ToTable("Tbl_EmployeeRequest_UserCompilation");

                entity.Property(e => e.FldEmployeeRequestUserCompilationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Id");

                entity.Property(e => e.FldEmployeeRequestCompilationTypeId).HasColumnName("Fld_EmployeeRequest_CompilationType_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestUserCompilationAuthor)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Author");

                entity.Property(e => e.FldEmployeeRequestUserCompilationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Date");

                entity.Property(e => e.FldEmployeeRequestUserCompilationDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Description");

                entity.Property(e => e.FldEmployeeRequestUserCompilationExplanation)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Explanation");

                entity.Property(e => e.FldEmployeeRequestUserCompilationTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserCompilation_Title");

                entity.HasOne(d => d.FldEmployeeRequestCompilationType)
                    .WithMany(p => p.TblEmployeeRequestUserCompilations)
                    .HasForeignKey(d => d.FldEmployeeRequestCompilationTypeId)
                    .HasConstraintName("FK_Tbl_UserCompilations_Tbl_CompilationType");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserCompilations)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserCompilations_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestUserCreativity>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserCreativityId)
                    .HasName("PK_Tbl_UserCreativity");

                entity.ToTable("Tbl_EmployeeRequest_UserCreativity");

                entity.Property(e => e.FldEmployeeRequestUserCreativityId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserCreativity_Id");

                entity.Property(e => e.FldEmployeeRequestCreativityTypeId).HasColumnName("Fld_EmployeeRequest_CreativityType_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestUserCreativityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_UserCreativity_Date");

                entity.Property(e => e.FldEmployeeRequestUserCreativityDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserCreativity_Description");

                entity.Property(e => e.FldEmployeeRequestUserCreativityExplanation)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserCreativity_Explanation");

                entity.Property(e => e.FldEmployeeRequestUserCreativityTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserCreativity_Title");

                entity.HasOne(d => d.FldEmployeeRequestCreativityType)
                    .WithMany(p => p.TblEmployeeRequestUserCreativities)
                    .HasForeignKey(d => d.FldEmployeeRequestCreativityTypeId)
                    .HasConstraintName("FK_Tbl_UserCreativity_Tbl_CreativityType");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserCreativities)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserCreativity_Tbl_User");
            });

            modelBuilder.Entity<TblEmployeeRequestUserJob>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserJobId)
                    .HasName("PK_Lvl5Users");

                entity.ToTable("Tbl_EmployeeRequest_UserJob");

                entity.Property(e => e.FldEmployeeRequestUserJobId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserJob_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestJobsId).HasColumnName("Fld_EmployeeRequest_Jobs_Id");

                entity.Property(e => e.FldEmployeeRequestUserJobDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Fld_EmployeeRequest_UserJob_Description");

                entity.Property(e => e.FldEmployeeRequestUserJobRequestMoney)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserJob_RequestMoney");

                entity.Property(e => e.FldEmployeeRequestUserJobTitle)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserJob_Title");

                entity.Property(e => e.FldEmployeeRequestUserJobWhatKnowAbout)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserJob_WhatKnowAbout");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserJobs)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserJob_Tbl_User");

                entity.HasOne(d => d.FldEmployeeRequestJobs)
                    .WithMany(p => p.TblEmployeeRequestUserJobs)
                    .HasForeignKey(d => d.FldEmployeeRequestJobsId)
                    .HasConstraintName("FK_UserJob_Jobs");
            });

            modelBuilder.Entity<TblEmployeeRequestUserLanguage>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserLanguageId)
                    .HasName("PK_Table_1");

                entity.ToTable("Tbl_EmployeeRequest_UserLanguage");

                entity.Property(e => e.FldEmployeeRequestUserLanguageId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserLanguage_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestUserLanguageDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("Fld_EmployeeRequest_UserLanguage_Description");

                entity.Property(e => e.FldEmployeeRequestUserLanguageIsNative).HasColumnName("Fld_EmployeeRequest_UserLanguage_IsNative");

                entity.Property(e => e.FldEmployeeRequestUserLanguageLanguageTypeId).HasColumnName("Fld_EmployeeRequest_UserLanguage_LanguageType_Id");

                entity.Property(e => e.FldEmployeeRequestUserLanguageListeningLevel).HasColumnName("Fld_EmployeeRequest_UserLanguage_ListeningLevel");

                entity.Property(e => e.FldEmployeeRequestUserLanguageReadingLevel).HasColumnName("Fld_EmployeeRequest_UserLanguage_ReadingLevel");

                entity.Property(e => e.FldEmployeeRequestUserLanguageSpeakingLevel).HasColumnName("Fld_EmployeeRequest_UserLanguage_SpeakingLevel");

                entity.Property(e => e.FldEmployeeRequestUserLanguageWritingLevel).HasColumnName("Fld_EmployeeRequest_UserLanguage_WritingLevel");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserLanguages)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserLanguage_Tbl_User");

                entity.HasOne(d => d.FldEmployeeRequestUserLanguageLanguageType)
                    .WithMany(p => p.TblEmployeeRequestUserLanguages)
                    .HasForeignKey(d => d.FldEmployeeRequestUserLanguageLanguageTypeId)
                    .HasConstraintName("FK_Tbl_UserLanguage_Tbl_LanguageType");
            });

            modelBuilder.Entity<TblEmployeeRequestUserMilitary>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserMilitaryId)
                    .HasName("PK_Tbl_UserMilitary");

                entity.ToTable("Tbl_EmployeeRequest_UserMilitary");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestMilitaryId).HasColumnName("Fld_EmployeeRequest_Military_Id");

                entity.Property(e => e.FldEmployeeRequestMilitaryOrganizationId).HasColumnName("Fld_EmployeeRequest_MilitaryOrganization_Id");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryCity)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_City");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_Description");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_EndDate");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryExemptDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_ExemptDescription");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_StartDate");

                entity.Property(e => e.FldEmployeeRequestUserMilitaryUnit)
                    .HasMaxLength(200)
                    .HasColumnName("Fld_EmployeeRequest_UserMilitary_Unit");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserMilitaries)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserMilitary_Tbl_User");

                entity.HasOne(d => d.FldEmployeeRequestMilitary)
                    .WithMany(p => p.TblEmployeeRequestUserMilitaries)
                    .HasForeignKey(d => d.FldEmployeeRequestMilitaryId)
                    .HasConstraintName("FK_Tbl_UserMilitary_Tbl_Military");

                entity.HasOne(d => d.FldEmployeeRequestMilitaryOrganization)
                    .WithMany(p => p.TblEmployeeRequestUserMilitaries)
                    .HasForeignKey(d => d.FldEmployeeRequestMilitaryOrganizationId)
                    .HasConstraintName("FK_Tbl_UserMilitary_Tbl_MilitaryOrganization");
            });

            modelBuilder.Entity<TblEmployeeRequestUserSetting>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserSettingId);

                entity.ToTable("Tbl_EmployeeRequest_UserSetting");

                entity.Property(e => e.FldEmployeeRequestUserSettingId).HasColumnName("Fld_EmployeeRequest_UserSetting_Id");

                entity.Property(e => e.FldEmployeeRequestUserId).HasColumnName("Fld_EmployeeRequest_User_Id");

                entity.Property(e => e.FldEmployeeRequestUserSettingIsCollaps)
                    .IsRequired()
                    .HasColumnName("Fld_EmployeeRequest_UserSetting_IsCollaps")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldEmployeeRequestUserSettingIsShowGreen)
                    .IsRequired()
                    .HasColumnName("Fld_EmployeeRequest_UserSetting_IsShowGreen")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldEmployeeRequestUserSettingIsShowRed)
                    .IsRequired()
                    .HasColumnName("Fld_EmployeeRequest_UserSetting_IsShowRed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldEmployeeRequestUserSettingPageSize)
                    .HasColumnName("Fld_EmployeeRequest_UserSetting_PageSize")
                    .HasDefaultValueSql("((5))");

                entity.HasOne(d => d.FldEmployeeRequestUser)
                    .WithMany(p => p.TblEmployeeRequestUserSettings)
                    .HasForeignKey(d => d.FldEmployeeRequestUserId)
                    .HasConstraintName("FK_Tbl_EmployeeRequest_UserSetting_Tbl_EmployeeRequest_User");
            });

            modelBuilder.Entity<TblEmployeeRequestUserSkill>(entity =>
            {
                entity.HasKey(e => e.FldEmployeeRequestUserSkillId)
                    .HasName("PK_Lvl4Users");

                entity.ToTable("Tbl_EmployeeRequest_UserSkill");

                entity.Property(e => e.FldEmployeeRequestUserSkillId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_Id");

                entity.Property(e => e.FldEmployeeRequestEmployeeId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_Employee_Id");

                entity.Property(e => e.FldEmployeeRequestSkillsId).HasColumnName("Fld_EmployeeRequest_Skills_Id");

                entity.Property(e => e.FldEmployeeRequestUserSkillDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_Date");

                entity.Property(e => e.FldEmployeeRequestUserSkillDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_Description");

                entity.Property(e => e.FldEmployeeRequestUserSkillIsSelfTaught).HasColumnName("Fld_EmployeeRequest_UserSkill_IsSelfTaught");

                entity.Property(e => e.FldEmployeeRequestUserSkillLicenseNo)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_LicenseNo");

                entity.Property(e => e.FldEmployeeRequestUserSkillLicenseReference)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_LicenseReference");

                entity.Property(e => e.FldEmployeeRequestUserSkillLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_Location");

                entity.Property(e => e.FldEmployeeRequestUserSkillSkillLevel).HasColumnName("Fld_EmployeeRequest_UserSkill_SkillLevel");

                entity.Property(e => e.FldEmployeeRequestUserSkillSkillTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_SkillTitle");

                entity.Property(e => e.FldEmployeeRequestUserSkillSkillType)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EmployeeRequest_UserSkill_SkillType");

                entity.HasOne(d => d.FldEmployeeRequestEmployee)
                    .WithMany(p => p.TblEmployeeRequestUserSkills)
                    .HasForeignKey(d => d.FldEmployeeRequestEmployeeId)
                    .HasConstraintName("FK_Tbl_UserSkill_Tbl_User");

                entity.HasOne(d => d.FldEmployeeRequestSkills)
                    .WithMany(p => p.TblEmployeeRequestUserSkills)
                    .HasForeignKey(d => d.FldEmployeeRequestSkillsId)
                    .HasConstraintName("FK_Tbl_UserSkill_Skills");
            });

            modelBuilder.Entity<TblJob>(entity =>
            {
                entity.HasKey(e => e.FldJobId);

                entity.ToTable("Tbl_Job");

                entity.Property(e => e.FldJobId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_JobID");

                entity.Property(e => e.FldBehinyabAddress).HasColumnName("Fld_BehinyabAddress");

                entity.Property(e => e.FldBehinyabId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_BehinyabID");

                entity.Property(e => e.FldDes)
                    .HasColumnType("ntext")
                    .HasColumnName("Fld_Des");

                entity.Property(e => e.FldDesDeActive)
                    .HasColumnType("ntext")
                    .HasColumnName("Fld_DesDeActive");

                entity.Property(e => e.FldDesEn)
                    .HasColumnType("ntext")
                    .HasColumnName("Fld_DesEN");

                entity.Property(e => e.FldEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EndDate");

                entity.Property(e => e.FldIsactive).HasColumnName("Fld_ISActive");

                entity.Property(e => e.FldJobName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_JobName");

                entity.Property(e => e.FldJobNameEn)
                    .HasMaxLength(200)
                    .HasColumnName("Fld_JobNameEN");

                entity.Property(e => e.FldMiniCode)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_miniCode");

                entity.Property(e => e.FldOnetAddress).HasColumnName("Fld_ONetAddress");

                entity.Property(e => e.FldOnetId)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_ONetID");

                entity.Property(e => e.FldStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_StartDate");

                entity.Property(e => e.FldTaminJobId).HasColumnName("Fld_TaminJobID");

                entity.Property(e => e.JobsId).HasColumnName("Jobs_ID");

                entity.Property(e => e.LevelId).HasColumnName("Level_ID");
            });

            modelBuilder.Entity<TblJobTamin>(entity =>
            {
                entity.HasKey(e => e.FldTaminJobId);

                entity.ToTable("Tbl_JobTamin");

                entity.Property(e => e.FldTaminJobId).HasColumnName("Fld_TaminJobID");

                entity.Property(e => e.FldTaminJobCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Fld_TaminJobCode");

                entity.Property(e => e.FldTaminJobName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_TaminJobName");

                entity.Property(e => e.FldTaminJobStatus).HasColumnName("Fld_TaminJobStatus");

                entity.Property(e => e.FldTaminJobStatusDate)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_TaminJobStatusDate");
            });

            modelBuilder.Entity<TblLeaveJob>(entity =>
            {
                entity.HasKey(e => e.FldLeaveJobId);

                entity.ToTable("Tbl_LeaveJob");

                entity.Property(e => e.FldLeaveJobId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_LeaveJobID");

                entity.Property(e => e.FldLeaveJobTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Fld_LeaveJobTitle");
            });

            modelBuilder.Entity<TblUserSuggestion>(entity =>
            {
                entity.ToTable("Tbl_UserSuggestion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserSuggestions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Tbl_UserSuggestion_Tbl_EmployeeRequest_Employee");
            });

            modelBuilder.Entity<TblWebsite>(entity =>
            {
                entity.ToTable("Tbl_Website");

                entity.Property(e => e.DefinitionId).HasColumnName("Definition_Id");

                entity.Property(e => e.SubDefinationId).HasColumnName("SubDefination_Id");

                entity.Property(e => e.Website).HasMaxLength(150);

                entity.Property(e => e.WebsiteTypeId).HasColumnName("WebsiteType_Id");

                entity.HasOne(d => d.Definition)
                    .WithMany(p => p.TblWebsites)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("FK_Tbl_Website_Tbl_Definition");

                entity.HasOne(d => d.WebsiteType)
                    .WithMany(p => p.TblWebsites)
                    .HasForeignKey(d => d.WebsiteTypeId)
                    .HasConstraintName("FK_Tbl_Website_Tbl_WebsiteType");
            });

            modelBuilder.Entity<TblWebsiteType>(entity =>
            {
                entity.ToTable("Tbl_WebsiteType");

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<TblWorkExperience>(entity =>
            {
                entity.HasKey(e => e.FldWorkExperienceId);

                entity.ToTable("Tbl_WorkExperience");

                entity.Property(e => e.FldWorkExperienceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_WorkExperienceID");

                entity.Property(e => e.FieldOfWork).HasMaxLength(150);

                entity.Property(e => e.FldAmountOfDailyInsurance)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_AmountOfDailyInsurance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldCompanyName)
                    .HasMaxLength(200)
                    .HasColumnName("Fld_CompanyName");

                entity.Property(e => e.FldContactInnerNumberOfCompany)
                    .HasMaxLength(10)
                    .HasColumnName("Fld_ContactInnerNumberOfCompany");

                entity.Property(e => e.FldContactNumberOfCompany)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_ContactNumberOfCompany");

                entity.Property(e => e.FldCustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_CustomerName");

                entity.Property(e => e.FldDescription).HasColumnName("Fld_Description");

                entity.Property(e => e.FldEarlySalary)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_EarlySalary");

                entity.Property(e => e.FldEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_EndDate");

                entity.Property(e => e.FldJobTitle)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_JobTitle");

                entity.Property(e => e.FldLateSalary)
                    .HasMaxLength(50)
                    .HasColumnName("Fld_LateSalary");

                entity.Property(e => e.FldLeaveJobId).HasColumnName("Fld_LeaveJobID");

                entity.Property(e => e.FldReasonsToLeaveJob).HasColumnName("Fld_ReasonsToLeaveJob");

                entity.Property(e => e.FldRelatedPeople)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_RelatedPeople");

                entity.Property(e => e.FldStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Fld_StartDate");

                entity.Property(e => e.FldTaminJobId).HasColumnName("Fld_TaminJobID");

                entity.Property(e => e.FldUnitName)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_UnitName");

                entity.Property(e => e.FldWorkDay)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_WorkDay");

                entity.Property(e => e.FldWorkTime)
                    .HasMaxLength(100)
                    .HasColumnName("Fld_WorkTime");

                entity.Property(e => e.InsuranceNo).HasMaxLength(50);

                entity.Property(e => e.PreviousJobAchievements).HasMaxLength(1000);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("User_Id");

                entity.Property(e => e.WhyWantChangeJob).HasMaxLength(1000);

                entity.HasOne(d => d.FldLeaveJob)
                    .WithMany(p => p.TblWorkExperiences)
                    .HasForeignKey(d => d.FldLeaveJobId)
                    .HasConstraintName("FK_Tbl_WorkExperience_Tbl_LeaveJob");

                entity.HasOne(d => d.FldTaminJob)
                    .WithMany(p => p.TblWorkExperiences)
                    .HasForeignKey(d => d.FldTaminJobId)
                    .HasConstraintName("FK_Tbl_WorkExperience_Tbl_JobTamin");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblWorkExperiences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Tbl_WorkExperience_Tbl_User");
            });

            modelBuilder.Entity<TblWorkExperienceLeaveJobDtl>(entity =>
            {
                entity.HasKey(e => e.FldWorkExperienceLeaveJobDtlId);

                entity.ToTable("Tbl_WorkExperienceLeaveJobDtl");

                entity.Property(e => e.FldWorkExperienceLeaveJobDtlId)
                    .ValueGeneratedNever()
                    .HasColumnName("Fld_WorkExperienceLeaveJobDtlID");

                entity.Property(e => e.FldLeaveJob).HasColumnName("Fld_LeaveJob");

                entity.Property(e => e.FldLeaveJobId).HasColumnName("Fld_LeaveJobID");

                entity.Property(e => e.FldLeaveJobPercent).HasColumnName("Fld_LeaveJobPercent");

                entity.Property(e => e.FldWorkExperienceId).HasColumnName("Fld_WorkExperienceID");

                entity.HasOne(d => d.FldLeaveJobNavigation)
                    .WithMany(p => p.TblWorkExperienceLeaveJobDtls)
                    .HasForeignKey(d => d.FldLeaveJobId)
                    .HasConstraintName("FK_Tbl_WorkExperienceLeaveJobDtl_Tbl_LeaveJob");

                entity.HasOne(d => d.FldWorkExperience)
                    .WithMany(p => p.TblWorkExperienceLeaveJobDtls)
                    .HasForeignKey(d => d.FldWorkExperienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_WorkExperienceLeaveJobDtl_Tbl_WorkExperience");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.EnglishDescription).HasMaxLength(4000);

                entity.Property(e => e.EnglishTitle).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.VersionId).HasColumnName("Version_Id");

                entity.HasOne(d => d.Version)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.VersionId)
                    .HasConstraintName("FK_Topic_Version");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("Version");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EnglishDescription).HasMaxLength(4000);

                entity.Property(e => e.PersianVersion).HasMaxLength(50);

                entity.Property(e => e.SkillId).HasColumnName("Skill_Id");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Version1)
                    .HasMaxLength(50)
                    .HasColumnName("Version");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Versions)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK_Version_Tbl_EmployeeRequest_Skills");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
