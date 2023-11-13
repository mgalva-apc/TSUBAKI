using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TSUBAKI.Models.DB
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }
        public MyDBContext(DbContextOptions<MyDBContext> options) 
        : base(options)
        {
        }
        public virtual DbSet<Account> Account {get; set;}
        public virtual DbSet<Client> Client {get; set;}
        public virtual DbSet<Document> Document {get; set;}
        public virtual DbSet<Notification> Notification {get; set;}
        public virtual DbSet<Schedule> Schedule {get; set;}
        public virtual DbSet<Staff> Staff {get; set;}
        public virtual DbSet<Transaction> Transaction {get; set;}
        public virtual DbSet<UserRole> UserRole {get; set;}
        public virtual DbSet<Role> Role {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\AYAKADB; Initial Catalog=AyakaDB; Integrated Security=True; Multiple Active Result Sets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity=>
            {
                entity.ToTable("SYSAccount");

                entity.Property(e => e.AccountID)
                .HasColumnName("ACC_ID")
                .HasColumnType("int");

                entity.Property(e => e.AccountUsername)
                .HasColumnName("ACC_Username")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.AccountPassword)
                .HasColumnName("ACC_Password")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.Salt)
                .HasColumnName("Salt")
                .HasMaxLength(128)
                .IsUnicode(false);

                entity.Property(e => e.AccountType)
                .HasColumnName("ACC_Type")
                .HasColumnType("char(1)");

                entity.Property(e => e.AccountEmail)
                .HasColumnName("ACC_Email")
                .HasMaxLength(150)
                .IsUnicode(false);

                entity.Property(e => e.AccountImage)
                .HasColumnName("ACC_Image")
                .IsUnicode(false)
                .IsRequired(false);

                entity.Property(e => e.AccountCreateDate)
                .HasColumnName("ACC_CreateDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AccountModDate)
                .HasColumnName("ACC_ModDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Client>(entity=>
            {
                entity.ToTable("SYSClient");

                entity.Property(e => e.ClientID)
                .HasColumnName("CLI_ID")
                .HasColumnType("int");

                entity.Property(e => e.AccountID)
                .HasColumnName("ACC_ID")
                .HasColumnType("int");

                entity.Property(e => e.ClientFirstName)
                .HasColumnName("CLI_FirstName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.ClientLastName)
                .HasColumnName("CLI_LastName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.ClientAddress)
                .HasColumnName("CLI_Address")
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.ClientGender)
                .HasColumnName("CLI_Gender")
                .HasColumnType("char(1)");

                entity.Property(e => e.ClientConNum)
                .HasColumnName("CLI_ConNum")
                .HasColumnType("char(11)");

                entity.Property(e => e.ClientBirthday)
                .HasColumnName("CLI_Birth");

                entity.Property(e => e.ClientCreateDate)
                .HasColumnName("CLI_CreateDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ClientModDate)
                .HasColumnName("CLI_ModDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Staff>(entity=>
            {
                entity.ToTable("SYSStaff");

                entity.Property(e => e.StaffID)
                .HasColumnName("STAFF_ID")
                .HasColumnType("int");

                entity.Property(e => e.AccountID)
                .HasColumnName("ACC_ID")
                .HasColumnType("int");

                entity.Property(e => e.StaffFirstName)
                .HasColumnName("STAFF_FirstName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.StaffLastName)
                .HasColumnName("STAFF_LastName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.StaffRole)
                .HasColumnName("STAFF_Role")
                .HasColumnType("char(1)");

                entity.Property(e => e.StaffGender)
                .HasColumnName("STAFF_Gender")
                .HasColumnType("char(1)");

                entity.Property(e => e.StaffConNum)
                .HasColumnName("STAFF_ConNum")
                .HasColumnType("char(12)");

                entity.Property(e => e.StaffBirthday)
                .HasColumnName("STAFF_Birth");

                entity.Property(e => e.StaffCreateDate)
                .HasColumnName("STAFF_CreateDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StaffModDate)
                .HasColumnName("STAFF_ModDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Schedule>(entity=>
            {
                entity.ToTable("SYSSchedule");

                entity.Property(e => e.ScheduleID)
                .HasColumnName("Sched_ID")
                .HasColumnType("int");

                entity.Property(e => e.AccountID)
                .HasColumnName("ACC_ID")
                .HasColumnType("int");

                entity.Property(e => e.ScheduleDate)
                .HasColumnName("Sched_Date");

                entity.Property(e => e.ScheduleTimeslot)
                .HasColumnName("Sched_Time");

                entity.Property(e => e.ScheduleCreateDate)
                .HasColumnName("Sched_CreateDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ScheduleModDate)
                .HasColumnName("Sched_ModDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Transaction>(entity=>
            {
                entity.ToTable("SYSTransaction");

                entity.Property(e => e.TransID)
                .HasColumnName("TRNS_ID")
                .HasColumnType("int");

                entity.Property(e => e.TransName)
                .HasColumnName("TRNS_Name")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.TransStatus)
                .HasColumnName("TRNS_Status")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.TransType)
                .HasColumnName("TRNS_Type")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.TransStartDate)
                .HasColumnName("TRNS_StartDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TransEndDate)
                .HasColumnName("TRNS_EndDate");

                entity.Property(e => e.StaffID)
                .HasColumnName("STAFF_ID")
                .HasColumnType("int");

                entity.Property(e => e.ClientID)
                .HasColumnName("CLI_ID")
                .HasColumnType("int");
            });

            modelBuilder.Entity<Notification>(entity=>
            {
                entity.ToTable("SYSNotification");

                entity.Property(e => e.NotifID)
                .HasColumnName("Notif_ID")
                .HasColumnType("int");

                entity.Property(e => e.NotifContent)
                .HasColumnName("Notif_Content")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.NotifSendDate)
                .HasColumnName("Notif_SendDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StaffID)
                .HasColumnName("STAFF_ID")
                .HasColumnType("int");

                entity.Property(e => e.ClientID)
                .HasColumnName("CLI_ID")
                .HasColumnType("int");

                entity.Property(e => e.DocuID)
                .HasColumnName("DOCU_ID")
                .HasColumnType("int");

                entity.Property(e => e.TransID)
                .HasColumnName("TRNS_ID")
                .HasColumnType("int");
            });

            modelBuilder.Entity<Document>(entity=>
            {
                entity.ToTable("SYSDocument");

                entity.Property(e => e.DocuID)
                .HasColumnName("DOCU_ID")
                .HasColumnType("int");

                entity.Property(e => e.DocuName)
                .HasColumnName("DOCU_Name")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.DocuType)
                .HasColumnName("DOCU_Type")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.DocuContent)
                .HasColumnName("DOCU_Content")
                .IsUnicode(false);

                entity.Property(e => e.DocuCreateDate)
                .HasColumnName("DOCU_CreateDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DocuModDate)
                .HasColumnName("DOCU_ModDate")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StaffID)
                .HasColumnName("STAFF_ID")
                .HasColumnType("int");

                entity.Property(e => e.ClientID)
                .HasColumnName("CLI_ID")
                .HasColumnType("int");

                entity.Property(e => e.TransID)
                .HasColumnName("TRNS_ID")
                .HasColumnType("int");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("SYSRole");

                entity.HasKey(e => new { e.RoleID });

                entity.Property(e => e.RoleID)
                .HasColumnName("SYSUserRoleID")
                .HasColumnType("int");

                entity.Property(e => e.AccountID)
                .HasColumnName("ACC_ID")
                .HasColumnType("int");

                entity.Property(e => e.LookUpRoleID)
                .HasColumnName("LOOKUPRoleID")
                .HasColumnType("int");

                entity.Property(e => e.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit");

                entity.Property(e => e.CreatedBy)
                .HasColumnName("RowCreatedSYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.CreatedDateTime)
                .HasColumnName("RowCreatedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy)
                .HasColumnName("RowModifiedSYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("RowModifiedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("SYSLOOKUPRole");

                entity.Property(e => e.RoleID)
                .HasColumnName("LOOKUPRoleID")
                .HasColumnType("int");

                entity.Property(e => e.RoleName)
                .HasColumnName("RoleName")
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.RoleDescription)
                .HasColumnName("RoleDescription")
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                .HasColumnName("RowCreatedSYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.CreatedDateTime)
                .HasColumnName("RowCreatedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy)
                .HasColumnName("RowModifiedSYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("RowModifiedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}