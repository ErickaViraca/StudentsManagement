using StudentsManagament.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsManagament.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchByParameter(List<Student> students, string parameter, string parameterValue);
        Task<Student> CreateStudent(string type, string name, string gender, string timestamp);
        Task Delete(List<Student> students, Student studentDel);
        Task<Student> SearchByNameAndType(List<Student> students, string name, string type);
        void PrintStudents(List<Student> students);
    }
}
