using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IrsMonkeyApi.Models.DB
{
    public partial class IRSMonkeyContext : DbContext
    {
        public IRSMonkeyContext()
        {
        }

        public IRSMonkeyContext(DbContextOptions<IRSMonkeyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<AlertType> AlertType { get; set; }
        public virtual DbSet<AmountType> AmountType { get; set; }
        public virtual DbSet<DebtType> DebtType { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Folder> Folder { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormControlType> FormControlType { get; set; }
        public virtual DbSet<FormPredefinedField> FormPredefinedField { get; set; }
        public virtual DbSet<FormQuestion> FormQuestion { get; set; }
        public virtual DbSet<FormQuestionAnswer> FormQuestionAnswer { get; set; }
        public virtual DbSet<FormResolution> FormResolution { get; set; }
        public virtual DbSet<FormSubmitted> FormSubmitted { get; set; }
        public virtual DbSet<FormSubmittedAnswer> FormSubmittedAnswer { get; set; }
        public virtual DbSet<FormSubmittedStatus> FormSubmittedStatus { get; set; }
        public virtual DbSet<FormType> FormType { get; set; }
        public virtual DbSet<GarnishmentType> GarnishmentType { get; set; }
        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
        public virtual DbSet<HousingStandard> HousingStandard { get; set; }
        public virtual DbSet<Irsoffice> Irsoffice { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<LienType> LienType { get; set; }
        public virtual DbSet<LogActionType> LogActionType { get; set; }
        public virtual DbSet<LogMemberAction> LogMemberAction { get; set; }
        public virtual DbSet<LogOrderBilling> LogOrderBilling { get; set; }
        public virtual DbSet<LogUserAction> LogUserAction { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberLogin> MemberLogin { get; set; }
        public virtual DbSet<MemberResolutionLetter> MemberResolutionLetter { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<MemberStatus> MemberStatus { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuRole> MenuRole { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<PaymentLog> PaymentLog { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Resolution> Resolution { get; set; }
        public virtual DbSet<ResolutionControl> ResolutionControl { get; set; }
        public virtual DbSet<ResolutionLetter> ResolutionLetter { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<SignUpType> SignUpType { get; set; }
        public virtual DbSet<StateCode> StateCode { get; set; }
        public virtual DbSet<TaxpediaPage> TaxpediaPage { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketDocument> TicketDocument { get; set; }
        public virtual DbSet<TicketLog> TicketLog { get; set; }
        public virtual DbSet<TicketStatus> TicketStatus { get; set; }
        public virtual DbSet<TicketType> TicketType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Wizard> Wizard { get; set; }
        public virtual DbSet<WizardStep> WizardStep { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.AlertDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AlertEndDate).HasColumnType("datetime");

                entity.Property(e => e.AlertLink).IsUnicode(false);

                entity.Property(e => e.AlertName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AlertStartDate).HasColumnType("datetime");

                entity.Property(e => e.AlertTypeId).HasColumnName("AlertTypeID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.RefId)
                    .HasColumnName("RefID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlertType)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.AlertTypeId)
                    .HasConstraintName("FK_Alert_AlertType");
            });

            modelBuilder.Entity<AlertType>(entity =>
            {
                entity.Property(e => e.AlertTypeId).HasColumnName("AlertTypeID");

                entity.Property(e => e.AlertTypeIconClass)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlertTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AmountType>(entity =>
            {
                entity.Property(e => e.AmountTypeId).HasColumnName("AmountTypeID");

                entity.Property(e => e.AmountTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DebtType>(entity =>
            {
                entity.Property(e => e.DebtTypeId).HasColumnName("DebtTypeID");

                entity.Property(e => e.DebtTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_File_Folder");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MembershipTypeId).HasColumnName("MembershipTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Folder)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folder_Member");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.CatalogNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.FactMessage).HasColumnType("text");

                entity.Property(e => e.FormCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FormTypeId).HasColumnName("FormTypeID");

                entity.Property(e => e.MotivationalMessage).HasColumnType("text");

                entity.Property(e => e.Pdffile)
                    .HasColumnName("PDFFile")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RevDate).HasColumnType("date");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FormType)
                    .WithMany(p => p.Form)
                    .HasForeignKey(d => d.FormTypeId)
                    .HasConstraintName("FK_Form_FormType");
            });

            modelBuilder.Entity<FormControlType>(entity =>
            {
                entity.Property(e => e.FormControlTypeId).HasColumnName("FormControlTypeID");

                entity.Property(e => e.FormControlTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormPredefinedField>(entity =>
            {
                entity.HasKey(e => e.FormPredefinedFieldlId);

                entity.Property(e => e.FormPredefinedFieldlId).HasColumnName("FormPredefinedFieldlID");

                entity.Property(e => e.FormPredefinedFieldName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormQuestion>(entity =>
            {
                entity.Property(e => e.FormQuestionId).HasColumnName("FormQuestionID");

                entity.Property(e => e.ControlId)
                    .HasColumnName("ControlID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cssclass)
                    .HasColumnName("CSSClass")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValidator).HasColumnName("fieldValidator");

                entity.Property(e => e.FormControlTypeId).HasColumnName("FormControlTypeID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.FormPredefinedFieldId).HasColumnName("FormPredefinedFieldID");

                entity.Property(e => e.FormSectionId).HasColumnName("FormSectionID");

                entity.Property(e => e.HtmlControlId)
                    .HasColumnName("htmlControlId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HtmlControlName)
                    .HasColumnName("htmlControlName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsNavigationControl).HasColumnName("isNavigationControl");

                entity.Property(e => e.Label)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PdfcontrolId)
                    .HasColumnName("PDFControlID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PdffontName)
                    .HasColumnName("PDFFontName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PdffontSize).HasColumnName("PDFFontSize");

                entity.Property(e => e.PdfpageNumber).HasColumnName("PDFPageNumber");

                entity.Property(e => e.PdfposX)
                    .HasColumnName("PDFPosX")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PdfposY)
                    .HasColumnName("PDFPosY")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tip).IsUnicode(false);

                entity.Property(e => e.TriggerFunction)
                    .HasColumnName("triggerFunction")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WizardStepId).HasColumnName("WizardStepID");

                entity.HasOne(d => d.FormControlType)
                    .WithMany(p => p.FormQuestion)
                    .HasForeignKey(d => d.FormControlTypeId)
                    .HasConstraintName("FK_FormQuestion_FormControlType");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormQuestion)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FormQuestion_Form");

                entity.HasOne(d => d.FormPredefinedField)
                    .WithMany(p => p.FormQuestion)
                    .HasForeignKey(d => d.FormPredefinedFieldId)
                    .HasConstraintName("FK_FormQuestion_FormPredefinedField");

                entity.HasOne(d => d.WizardStep)
                    .WithMany(p => p.FormQuestion)
                    .HasForeignKey(d => d.WizardStepId)
                    .HasConstraintName("FK_FormQuestion_WizardStep");
            });

            modelBuilder.Entity<FormQuestionAnswer>(entity =>
            {
                entity.Property(e => e.FormQuestionAnswerId).HasColumnName("FormQuestionAnswerID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.AssociatedPdfcontrolId)
                    .HasColumnName("AssociatedPDFControlID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cssclass)
                    .HasColumnName("CSSClass")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormQuestionId).HasColumnName("FormQuestionID");

                entity.Property(e => e.HtmlControlId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PdfcontrolId)
                    .HasColumnName("PDFControlID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.FormQuestion)
                    .WithMany(p => p.FormQuestionAnswer)
                    .HasForeignKey(d => d.FormQuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormQuestionAnswer_FormQuestion");
            });

            modelBuilder.Entity<FormResolution>(entity =>
            {
                entity.Property(e => e.FormResolutionId)
                    .HasColumnName("FormResolutionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.IsPdf).HasColumnName("IsPDF");

                entity.Property(e => e.ResolutionId).HasColumnName("ResolutionID");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormResolution)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormResolution_Form1");

                entity.HasOne(d => d.Resolution)
                    .WithMany(p => p.FormResolution)
                    .HasForeignKey(d => d.ResolutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormResolution_Resolution1");
            });

            modelBuilder.Entity<FormSubmitted>(entity =>
            {
                entity.Property(e => e.FormSubmittedId).HasColumnName("FormSubmittedID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.FormSubmitedStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormSubmitted)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FormSubmitted_Form");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FormSubmitted)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_FormSubmitted_Member");

                entity.HasOne(d => d.WizarStep)
                    .WithMany(p => p.FormSubmitted)
                    .HasForeignKey(d => d.WizarStepId)
                    .HasConstraintName("FormSubmitted_WizardStep_WizardStepID_fk");
            });

            modelBuilder.Entity<FormSubmittedAnswer>(entity =>
            {
                entity.Property(e => e.FormSubmittedAnswerId).HasColumnName("FormSubmittedAnswerID");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.ControlId)
                    .HasColumnName("ControlID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FormSubmittedId).HasColumnName("FormSubmittedID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.FormSubmitted)
                    .WithMany(p => p.FormSubmittedAnswer)
                    .HasForeignKey(d => d.FormSubmittedId)
                    .HasConstraintName("FK_FormSubmittedAnswer_FormSubmitted");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.FormSubmittedAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_FormSubmittedAnswer_FormQuestion");
            });

            modelBuilder.Entity<FormSubmittedStatus>(entity =>
            {
                entity.Property(e => e.FormSubmittedStatusId).HasColumnName("FormSubmittedStatusID");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormType>(entity =>
            {
                entity.Property(e => e.FormTypeId)
                    .HasColumnName("FormTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FormTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GarnishmentType>(entity =>
            {
                entity.Property(e => e.GarnishmentTypeId).HasColumnName("GarnishmentTypeID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.GarnishmentTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ResolutionCategoryId).HasColumnName("ResolutionCategoryID");
            });

            modelBuilder.Entity<GeoLocation>(entity =>
            {
                entity.HasIndex(e => e.ZipCode)
                    .HasName("GeoLocation_ZipCode_index");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HousingStandard>(entity =>
            {
                entity.HasKey(e => e.HousingStandardId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.HousingStandardId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State).HasMaxLength(100);
            });

            modelBuilder.Entity<Irsoffice>(entity =>
            {
                entity.ToTable("IRSOffice");

                entity.Property(e => e.IrsofficeId).HasColumnName("IRSOfficeID");

                entity.Property(e => e.IrsofficeName)
                    .IsRequired()
                    .HasColumnName("IRSOfficeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.AmountTypeId).HasColumnName("AmountTypeID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentItem).HasColumnName("parent_item");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.AmountType)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.AmountTypeId)
                    .HasConstraintName("FK_Item_AmountType");
            });

            modelBuilder.Entity<LienType>(entity =>
            {
                entity.Property(e => e.LienTypeId).HasColumnName("LienTypeID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ResolutionCategoryId).HasColumnName("ResolutionCategoryID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogActionType>(entity =>
            {
                entity.Property(e => e.LogActionTypeId).HasColumnName("LogActionTypeID");

                entity.Property(e => e.LogActionDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogMemberAction>(entity =>
            {
                entity.HasKey(e => e.LogMemberAction1);

                entity.Property(e => e.LogMemberAction1).HasColumnName("LogMemberAction");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogActionTypeId).HasColumnName("LogActionTypeID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.NewValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OldValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.LogActionType)
                    .WithMany(p => p.LogMemberAction)
                    .HasForeignKey(d => d.LogActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogMemberAction_LogActionType");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.LogMemberAction)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogMemberAction_Member");
            });

            modelBuilder.Entity<LogOrderBilling>(entity =>
            {
                entity.Property(e => e.LogOrderBillingId).HasColumnName("LogOrderBillingID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IpHost)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MessageCodes)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Messages)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LogOrderBilling)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_LogOrderBilling_Order");
            });

            modelBuilder.Entity<LogUserAction>(entity =>
            {
                entity.HasKey(e => e.UserActionLogId);

                entity.Property(e => e.UserActionLogId).HasColumnName("UserActionLogID");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogActionTypeId).HasColumnName("LogActionTypeID");

                entity.Property(e => e.NewValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OldValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.LogActionType)
                    .WithMany(p => p.LogUserAction)
                    .HasForeignKey(d => d.LogActionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAction_LogActionType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LogUserAction)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAction_User");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("Member_Email_uindex")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BusinessAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessState)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberStatusId).HasColumnName("MemberStatusID");

                entity.Property(e => e.MembershipTypeId).HasColumnName("MembershipTypeID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SignUpDate).HasColumnType("datetime");

                entity.Property(e => e.SignUpTypeId).HasColumnName("SignUpTypeID");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(25);

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UtmCampaign)
                    .HasColumnName("utm_campaign")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtmContent)
                    .HasColumnName("utm_content")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtmMedium)
                    .HasColumnName("utm_medium")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtmSouce)
                    .HasColumnName("utm_souce")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtmTerm)
                    .HasColumnName("utm_term")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode).HasMaxLength(5);

                entity.HasOne(d => d.MemberStatus)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MemberStatusId)
                    .HasConstraintName("FK_Member_MemberStatus");

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_MembershipType");
            });

            modelBuilder.Entity<MemberLogin>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("MemberLogin_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("MemberLogin_username_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberLogin)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("MemberLogin_Member_MemberID_fk");
            });

            modelBuilder.Entity<MemberResolutionLetter>(entity =>
            {
                entity.Property(e => e.MemberResolutionLetterId)
                    .HasColumnName("MemberResolutionLetterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnswerParagraph1).HasColumnType("text");

                entity.Property(e => e.AnswerParagraph2).HasColumnType("text");

                entity.Property(e => e.AnswerParagraph3).HasColumnType("text");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ResolutionLetterId).HasColumnName("ResolutionLetterID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberResolutionLetter)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberResolutionLetter_Member");

                entity.HasOne(d => d.ResolutionLetter)
                    .WithMany(p => p.MemberResolutionLetter)
                    .HasForeignKey(d => d.ResolutionLetterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberResolutionLetter_ResolutionLetter");
            });

            modelBuilder.Entity<MembershipType>(entity =>
            {
                entity.Property(e => e.MembershipTypeId).HasColumnName("MembershipTypeID");

                entity.Property(e => e.MembershipTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberStatus>(entity =>
            {
                entity.Property(e => e.MemberStatusId).HasColumnName("MemberStatusID");

                entity.Property(e => e.MemberStatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Icon)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MenuDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuTypeId).HasColumnName("MenuTypeID");

                entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenuID");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MenuType)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.MenuTypeId)
                    .HasConstraintName("FK_Menu_MenuType");
            });

            modelBuilder.Entity<MenuRole>(entity =>
            {
                entity.Property(e => e.MenuRoleId)
                    .HasColumnName("MenuRoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuRole)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRole_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MenuRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRole_Role");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.Property(e => e.MenuTypeId).HasColumnName("MenuTypeID");

                entity.Property(e => e.MenuTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountType)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.Property(e => e.PaymentStartDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.SubscriptionId)
                    .HasColumnName("SubscriptionID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Order_Member");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_Order_PaymentType");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Item");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Order");
            });

            modelBuilder.Entity<PaymentLog>(entity =>
            {
                entity.Property(e => e.PaymentLogId).HasColumnName("PaymentLogID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.PaymentLog)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_PaymentLog_Member");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.QuestionType1)
                    .HasColumnName("QuestionType")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resolution>(entity =>
            {
                entity.Property(e => e.ResolutionId).HasColumnName("ResolutionID");

                entity.Property(e => e.AppealsTaxpediaPageId).HasColumnName("AppealsTaxpediaPageID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Resolution1)
                    .HasColumnName("Resolution")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaxpediaPageId).HasColumnName("TaxpediaPageID");
            });

            modelBuilder.Entity<ResolutionControl>(entity =>
            {
                entity.HasKey(e => e.ResolutionControlId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.ResolutionControlId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FormControl).HasMaxLength(255);

                entity.Property(e => e.Label).HasMaxLength(255);

                entity.HasOne(d => d.FormControlTypeNavigation)
                    .WithMany(p => p.ResolutionControl)
                    .HasForeignKey(d => d.FormControlType)
                    .HasConstraintName("ResolutionControl_FormControlType_FormControlTypeID_fk");
            });

            modelBuilder.Entity<ResolutionLetter>(entity =>
            {
                entity.Property(e => e.ResolutionLetterId).HasColumnName("ResolutionLetterID");

                entity.Property(e => e.ResolutionId).HasColumnName("ResolutionID");

                entity.Property(e => e.TextTemplate).HasColumnType("text");

                entity.HasOne(d => d.Resolution)
                    .WithMany(p => p.ResolutionLetter)
                    .HasForeignKey(d => d.ResolutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResolutionLetter_Resolution");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("session");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AppState).HasColumnName("app_state");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.SassionDate)
                    .HasColumnName("sassion_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SignUpType>(entity =>
            {
                entity.Property(e => e.SignUpTypeId).HasColumnName("SignUpTypeID");

                entity.Property(e => e.SignUpTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateCode>(entity =>
            {
                entity.HasKey(e => e.StateCode1);

                entity.Property(e => e.StateCode1)
                    .HasColumnName("StateCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StateCodeId).HasColumnName("StateCodeID");
            });

            modelBuilder.Entity<TaxpediaPage>(entity =>
            {
                entity.Property(e => e.TaxpediaPageId).HasColumnName("TaxpediaPageID");

                entity.Property(e => e.TaxpediaPageText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TaxpediaPageTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateAssigned).HasColumnType("datetime");

                entity.Property(e => e.DateClosed).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MembershipTypeId).HasColumnName("MembershipTypeID");

                entity.Property(e => e.TicketDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");

                entity.Property(e => e.TicketTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.TicketAssignedByNavigation)
                    .HasForeignKey(d => d.AssignedBy)
                    .HasConstraintName("FK_Ticket_User");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.TicketAssignedToNavigation)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("FK_Ticket_User1");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Member");

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_MembershipType");

                entity.HasOne(d => d.TicketStatus)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketStatusId)
                    .HasConstraintName("FK_Ticket_TicketStatus");

                entity.HasOne(d => d.TicketType)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_TicketType");
            });

            modelBuilder.Entity<TicketDocument>(entity =>
            {
                entity.Property(e => e.TicketDocumentId).HasColumnName("TicketDocumentID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");
            });

            modelBuilder.Entity<TicketLog>(entity =>
            {
                entity.Property(e => e.TicketLogId)
                    .HasColumnName("TicketLogID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateStamp).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EnteredByMemberId).HasColumnName("EnteredByMemberID");

                entity.Property(e => e.EnteredByUserId).HasColumnName("EnteredByUserID");

                entity.Property(e => e.NewTicketStatusId).HasColumnName("NewTicketStatusID");

                entity.Property(e => e.OldTicketStatusId).HasColumnName("OldTicketStatusID");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EnteredByMember)
                    .WithMany(p => p.TicketLog)
                    .HasForeignKey(d => d.EnteredByMemberId)
                    .HasConstraintName("FK_TicketLog_Member");

                entity.HasOne(d => d.EnteredByUser)
                    .WithMany(p => p.TicketLog)
                    .HasForeignKey(d => d.EnteredByUserId)
                    .HasConstraintName("FK_TicketLog_User");

                entity.HasOne(d => d.NewTicketStatus)
                    .WithMany(p => p.TicketLogNewTicketStatus)
                    .HasForeignKey(d => d.NewTicketStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketLog_TicketStatus");

                entity.HasOne(d => d.OldTicketStatus)
                    .WithMany(p => p.TicketLogOldTicketStatus)
                    .HasForeignKey(d => d.OldTicketStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketLog_TicketStatus1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketLog)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketLog_Ticket");
            });

            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.Property(e => e.TicketStatusId).HasColumnName("TicketStatusID");

                entity.Property(e => e.TicketStatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");

                entity.Property(e => e.TicketTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<Wizard>(entity =>
            {
                entity.Property(e => e.WizardId).HasColumnName("WizardID");

                entity.Property(e => e.FactsMessage).HasColumnType("text");

                entity.Property(e => e.Footer).HasColumnType("text");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.Header).HasColumnType("text");

                entity.Property(e => e.MotivationalMessage).HasColumnType("text");

                entity.Property(e => e.ParentWizardId).HasColumnName("ParentWizardID");

                entity.Property(e => e.ResolutionId).HasColumnName("ResolutionID");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Wizard)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_FormResolution_Form");

                entity.HasOne(d => d.Resolution)
                    .WithMany(p => p.Wizard)
                    .HasForeignKey(d => d.ResolutionId)
                    .HasConstraintName("FK_FormResolution_Resolution");
            });

            modelBuilder.Entity<WizardStep>(entity =>
            {
                entity.Property(e => e.WizardStepId).HasColumnName("WizardStepID");

                entity.Property(e => e.FactsMessage).HasColumnType("text");

                entity.Property(e => e.Footer).HasColumnType("text");

                entity.Property(e => e.Header).HasColumnType("text");

                entity.Property(e => e.MotivationalMessage).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WizardId).HasColumnName("WizardID");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.WizardStep)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("WizardStep_Form_FormID_fk");

                entity.HasOne(d => d.Wizard)
                    .WithMany(p => p.WizardStep)
                    .HasForeignKey(d => d.WizardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WizardStep_Wizard");
            });
        }
    }
}
