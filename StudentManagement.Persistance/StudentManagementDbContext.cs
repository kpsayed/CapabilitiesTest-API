using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Models;


namespace StudentManagement.Persistance
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options) : base(options)
        {
        }
        #region Student
        public DbSet<MstStudents>? MstStudents { get; set; }
        public DbSet<ViewStudents>? ViewStudents { get; set; }
        public DbSet<ViewStudentRelatives>? ViewStudentRelatives { get; set; }
        #endregion

        #region Family Members
        public DbSet<FamilyMember>? FamilyMember { get; set; }
        #endregion

        #region Nationalities
        public DbSet<MstNationalities>? MstNationalities { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerDate>().HasNoKey();

        }
    }
}
