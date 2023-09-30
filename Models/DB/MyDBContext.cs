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

        public virtual DbSet<Users> Users {get; set;}
        public virtual DbSet<Schedule> Schedule {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\AYAKADB; Initial Catalog=AYAKADB; Integrated Security=True; Multiple Active Result Sets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity=>
            {
                entity.ToTable("SYSUser");

                entity.Property(e => e.UserID)
                .HasColumnName("SYSUserID")
                .HasColumnType("int");

                entity.Property(e => e.LoginName)
                .HasColumnName("LoginName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.PasswordEncryptedText)
                .HasColumnName("PasswordEncryptedText")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Gender)
                .HasColumnName("Gender")
                .HasColumnType("char(1)");

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

            modelBuilder.Entity<Schedule>(entity=>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleID)
                .HasColumnName("ScheduleID")
                .HasColumnType("int");

                entity.Property(e => e.LoginName)
                .HasColumnName("LoginName")
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Month)
                .HasColumnName("Month")
                .HasColumnType("varchar(20)");

                entity.Property(e => e.Day)
                .HasColumnName("Day")
                .HasColumnType("varchar(2)");

                entity.Property(e => e.TimeSlot)
                .HasColumnName("TimeSlot")
                .HasColumnType("varchar(20)");

                entity.Property(e => e.CreatedBy)
                .HasColumnName("RowCreatedScheduleID")
                .HasColumnType("int");

                entity.Property(e => e.CreatedDateTime)
                .HasColumnName("RowCreatedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy)
                .HasColumnName("RowModifiedScheduleID")
                .HasColumnType("int");

                entity.Property(e => e.ModifiedDateTime)
                .HasColumnName("RowModifiedDateTime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}