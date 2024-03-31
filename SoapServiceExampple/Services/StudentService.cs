using SoapServiceExampple.Models;
using System.ServiceModel;

namespace SoapServiceExampple.Services
{
    [ServiceContract]
    public class StudentService
    {
        private List<Student> students = new()
        {
            new Student { Id = 1, FirstName = "Ivan", LastName = "Ivanov", Email = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        [OperationContract]
        public Student? GetStudent(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        [OperationContract]
        public List<Student> GetAllStudent()
        {
            return students;
        }

        [OperationContract]
        public Student? AddStudent(Student student)
        {
            students.Add(student);
            return student;
        }

        [OperationContract]
        public void RemoveStudent(int id)
        {
            students.RemoveAll(x => x.Id == id);
        }
    }
}