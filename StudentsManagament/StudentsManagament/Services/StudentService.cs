using StudentsManagament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManagament.Services
{
    public class StudentService : IStudentService
    {
        /// <summary>
        /// Method that search all the objects that satisfy the exactly parameter value.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        /// <returns> <List<Student> </returns>
        public async Task<List<Student>> SearchByParameter(List<Student> students, string parameter, string parameterValue)
        {
            List<Student> studentsFounded = new List<Student>();
            switch (parameter)
            {
                case "name":
                    foreach (Student student in students)
                    {
                        if (student.studentName.Equals(parameterValue))
                        {
                            studentsFounded.Add(student);
                        }
                    }
                    break;
                case "type":
                    foreach (Student student in students)
                    {
                        if (student.studentType.Equals(parameterValue))
                        {
                            studentsFounded.Add(student);
                        }
                    }
                    break;
                case "gender":
                    foreach (Student student in students)
                    {
                        if (student.gender.Equals(parameterValue))
                        {
                            studentsFounded.Add(student);
                        }
                    }
                    break;
            }
            return studentsFounded.OrderByDescending(s => s.timestamp).ToList();
        }

        /// <summary>
        /// Method that create a new student.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="timestamp"></param>
        /// <returns> Student </returns>
        public async Task<Student> CreateStudent(string type, string name, string gender, string timestamp)
        {
            return new Student()
            {
                studentType = type,
                studentName = name,
                gender = gender,
                timestamp = timestamp
            };
        }

        /// <summary>
        /// Method that delete a specific student.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task Delete(List<Student> students, Student student)
        {
            Student studentToRemove = await SearchByNameAndType(students, student.studentName, student.studentType);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }

        /// <summary>
        /// Method that search a student by name and type.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns> Student </returns>
        public async Task<Student> SearchByNameAndType(List<Student> students, string name, string type)
        {
            Student studentFounded = null;
            foreach (Student student in students)
            {
                if (student.studentType.Equals(type) && student.studentName.Equals(name))
                {
                    studentFounded = student;
                }
            }
            return studentFounded;
        }

        /// <summary>
        /// Method that display all the list of objects over console.
        /// </summary>
        /// <param name="students"></param>
        public void PrintStudents(List<Student> students)
        {
            if (students.Any())
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.studentType + " " + student.studentName + " " + student.gender + " " + student.timestamp);
                }
            }
            else
            {
                Console.WriteLine("There is not result found.");
            }
        }
    }
}
