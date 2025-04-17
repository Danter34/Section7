using WebApplication2.Models.Domain;
using WebApplication2.Models.ViewModel;

namespace WebApplication2.Models.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAll(string? searchString, string? type);
        public VMStudent GetStudentsById(int id);
        public void UpdateStudentById(int id, VMStudent model);
        public void AddStudent(VMStudent model);
        public void DeleteStudentById(int id);
    }
}