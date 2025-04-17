

using WebApplication2.Data;
using WebApplication2.Models.Domain;
using WebApplication2.Models.ViewModel;

namespace WebApplication2.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDbContext dbContext;
        public StudentRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Student> GetAll(string? searchString, string? type)
        {
            if (!String.IsNullOrEmpty(searchString)) //kiểm tra
            {
                var List = from l in dbContext.Students
                           select l;
                if (type == "Mssv")
                {
                    return List.Where(s => s.Mssv.Contains(searchString));
                }
                else
                {
                    return List.Where(s => s.Name.Contains(searchString));
                }
            }
            else
            {
                return dbContext.Students;
            }
        }

        public VMStudent? GetStudentsById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                string GenderVm;
                if (student.Gender == false) GenderVm = "female"; else GenderVm = "male";
                var studentVM = new VMStudent()
                {
                    Id = id,
                    Name = student.Name,
                    Birth = student.Birth,
                    ImgUrl = student.ImgUrl,
                    Gender = GenderVm,
                    Mssv = student.Mssv,
                    Decription = student.Decription,
                };
                return studentVM;
            }
            return null;
        }


        public void UpdateStudentById(int id, VMStudent model)
        {
            var StudentById = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (StudentById != null)
            {
                StudentById.Name = model.Name;
                StudentById.Birth = model.Birth;
                if (model.Gender == "male") StudentById.Gender = true; else StudentById.Gender = false;
                StudentById.ImgUrl = model.ImgUrl;
                StudentById.Mssv = model.Mssv;
                StudentById.Decription = model.Decription;
                dbContext.Update(StudentById);
                dbContext.SaveChanges();
            }
        }

        public void AddStudent(VMStudent Model)
        {
            bool GenderData;
            if (Model.Gender == "male")
                GenderData = true;
            else GenderData = false;

            var student = new Student()
            {
                Name = Model.Name,
                Birth = Model.Birth,
                Gender = GenderData,
                ImgUrl = Model.ImgUrl,
                Mssv = Model.Mssv,
                Decription = Model.Decription
            };

            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
