using StudentsManagament.Helpers;
using StudentsManagament.Models;
using StudentsManagament.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StudentsManagament
{
    public class Runner
    {
        private readonly IStudentService _studentService;
        private readonly ICommandValidator _commandValidator;
        private static Runner _instance;
        private List<Student> _students;

        private const string PATHFILE = "D:\\StudentsManagement\\Files";
        private const char COMMA = ',';

        protected Runner()
        {
            _studentService = new StudentService();
            _commandValidator = new CommandValidator();
            _students = new List<Student>();
        }

        /// <summary>
        /// Method that return the runner instance.
        /// </summary>
        /// <returns></returns>
        public static Runner GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Runner();
            }

            return _instance;
        }

        /// <summary>
        /// Method that insert all objetcs from csv file into a List<Student>.
        /// </summary>
        /// <param name="csvFile"></param>
        /// <returns></returns>
        public async Task InsertInitialData(string csvFile)
        {
            try
            {
                using (var reader = new StreamReader(PATHFILE + csvFile))
                {
                    
                    string text = reader.ReadToEnd();
                    string[] lines = text.Split(Environment.NewLine);

                    foreach (string line in lines)
                    {
                        Student student = await BuildStudent(line);
                        _students.Add(student);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while inserting the data to list: " + e.Message);
            }
        }

        /// <summary>
        /// Method that build a student from a string into Student Object.
        /// </summary>
        /// <param name="line"></param>
        /// <returns>Student</returns>
        private async Task<Student> BuildStudent(string line)
        {
            string[] parameters = line.Split(COMMA);
            return await _studentService.CreateStudent(parameters[0], parameters[1], parameters[2], parameters[3]);
        }

        /// <summary>
        /// Method that execute the commands as from console arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task ExecuteCommand(string[] args)
        {
            int quantityArgs = args.Length;
            List<Student> studentResults = _students;
            for (int i = 1; i < quantityArgs; i++)
            {
                if (_commandValidator.VerifyCorrectFormat($"{args[i]}"))
                {
                    string parameter = _commandValidator.GetCommandParameter($"{args[i]}");
                    string parameterValue = _commandValidator.GetCommandParameterValue($"{args[i]}");
                    studentResults = await _studentService.SearchByParameter(studentResults, parameter, parameterValue);
                }
            }
            _studentService.PrintStudents(studentResults);
        }
    }
}
