using StudentManagement.Domain.Models;


namespace StudentManagement.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<MstStudents>> GetAllStudentsAsync(); 
        Task<MstStudents> GetStudentByIdAsync(int studentId);



        Task<List<ViewStudentRelatives>> GetRelativesByStudentIdAsync(int studentId);
        //


        Task<MstStudents> AddStudentAsync(MstStudents student);
        Task<MstStudents> UpdateStudentNationalityAsync(int studentId, int nationalityId);


        //

        Task<MstStudents> UpdateStudentAsync(MstStudents student);

        Task<FamilyMember> AddFamilyMemberAsync(int studentId, FamilyMember familyMember);




    }
}
