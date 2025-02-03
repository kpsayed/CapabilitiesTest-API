using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Domain.Models;


namespace StudentManagement.Persistance.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region private variables
        private readonly StudentManagementDbContext _studentDbContext;
        private static IConfiguration _config;
        #endregion

        #region constructor
        public StudentRepository(IConfiguration config, StudentManagementDbContext studentDbContext)
        {
            _config = config;
            _studentDbContext = studentDbContext;
        }
        #endregion

        #region Get Methods
        public async Task<List<MstStudents>> GetAllStudentsAsync()
        {
            var list = new List<MstStudents>();
            try
            {
                list = await _studentDbContext?.MstStudents?.ToListAsync();
            }
            catch (Exception)
            {
            }
            return list;
        }
        public async Task<MstStudents> GetStudentByIdAsync(int studentId)
        {
            var student = new MstStudents();
            try
            {
                student = await _studentDbContext?.MstStudents?.Where(s => s.StudentAID == studentId).FirstOrDefaultAsync();

            }
            catch (Exception)
            {

            }
            return student;
        }
        public async Task<List<ViewStudentRelatives>> GetRelativesByStudentIdAsync(int studentId)
        {
            var lstRelatives = new List<ViewStudentRelatives>();
            try
            {
                lstRelatives = await _studentDbContext.ViewStudentRelatives.Where(fm => fm.StudentID == studentId).ToListAsync();
            }
            catch (Exception)
            {

            }
            return lstRelatives;
        }
        #endregion

        #region Post Methods
        public async Task<MstStudents> AddStudentAsync(MstStudents student)
        {
            _studentDbContext.MstStudents.Add(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }
        public async Task<FamilyMember> AddFamilyMemberAsync(int studentId, FamilyMember familyMember)
        {
            familyMember.StudentID = studentId;
            _studentDbContext.FamilyMember.Add(familyMember);
            await _studentDbContext.SaveChangesAsync();
            return familyMember;
        }
        #endregion

        #region Put Methods
        public async Task<MstStudents> UpdateStudentAsync(MstStudents student)
        {
            var existingStudent = await _studentDbContext.MstStudents.FindAsync(student.StudentAID);
            if (existingStudent == null)
                return null;

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DOB = student.DOB;
            await _studentDbContext.SaveChangesAsync();
            return existingStudent;
        }
        public async Task<MstStudents> UpdateStudentNationalityAsync(int studentId, int nationalityId)
        {
            var student = await _studentDbContext.MstStudents.FindAsync(studentId);
            if (student == null)
                return null;

            student.NationalityID = nationalityId;
            await _studentDbContext.SaveChangesAsync();
            return student;
        }
        #endregion

    }
}
