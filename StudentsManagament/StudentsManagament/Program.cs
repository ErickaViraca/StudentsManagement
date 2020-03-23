using System;
using System.Threading.Tasks;

namespace StudentsManagament
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Runner runner = Runner.GetInstance();
                string csvFile = $"{args[0]}";
                await runner.InsertInitialData(csvFile);
                await runner.ExecuteCommand(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
