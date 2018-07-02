using System;
using DAL;

namespace Trying
{
    public class Program
    {
        static void Main(string[] args)
        {
            var company = new Company("'I be M'");

            Console.WriteLine(company.OfficialIntroduction());

            var manager = new Manager("Hugo Boss", new DateTime(1970, 5, 23));
            var regular1 = new Regular("Mr. Strong", new DateTime(1980, 2, 29), manager);
            var regular2 = new Regular("Ms. Good Looking", new DateTime(1990, 9, 2), manager);
            var regular3 = new Regular("Ms. Smart", new DateTime(1993, 10, 12), manager);
            var intern1 = new Intern("Slave", new DateTime(1995, 4, 30), manager, regular2);

            company.AddEmployee(manager);
            company.AddEmployee(regular1);
            company.AddEmployee(regular2);
            company.AddEmployee(regular3);
            company.AddEmployee(intern1);

            Console.WriteLine(company.OfficialIntroduction());

            var employeeId = "R199310XX";
            var layOffSuccessful = company.LayOffEmployeeByEmployeeId(employeeId);
            Console.WriteLine(layOffSuccessful ? $"Employee with ID {employeeId} successfully fired!" : $"Employee with ID {employeeId} was not found!");

            employeeId = "R19931012";
            layOffSuccessful = company.LayOffEmployeeByEmployeeId(employeeId);
            Console.WriteLine(layOffSuccessful ? $"Employee with ID {employeeId} successfully fired!" : $"Employee with ID {employeeId} was not found!");

            Console.WriteLine();

            Console.WriteLine(company.PromoteToRegular(intern1));

            Console.WriteLine();

            Console.WriteLine(company.OfficialIntroduction());
            Console.WriteLine(company.PromoteToManager(regular1));

            Console.WriteLine();

            Console.WriteLine(company.OfficialIntroduction());
            Console.ReadLine();
        }
    }
}
