using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class Company
    {
        private string _name;
        private List<Employee> _employeeList = new List<Employee>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Employee> EmployeeList
        {
            get { return _employeeList; }
        }

        public Company()
        {
        }

        public Company(string name)
        {
            this.Name = name;
        }

        public string OfficialIntroduction()
        {
            string companyIntro = "";
            StringBuilder sb = new StringBuilder(companyIntro);
            int averageEmployeesAge = 0;

            if (EmployeeList.Count > 0)
            {
                averageEmployeesAge = (Int32)EmployeeList.Average(item => item.Age);
            }
 
            sb.Append(String.Format("Hi, this is {0}!", Name));
            sb.Append(String.Format(" We currently have {0} employees with an average age of {1}.", EmployeeList.Count, averageEmployeesAge));
 
            if (EmployeeList.Count > 0)
            {
                foreach (var employee in EmployeeList)
                {
                    if (employee.EmployeeType == EmployeeTypeEnum.Regular)
                    {
                        Regular regular = (Regular)employee;
                        sb.Append(Environment.NewLine);
                        sb.Append('-');
                        sb.Append(regular.IntroduceYourself());
                    }
                    else
                    if (employee.EmployeeType == EmployeeTypeEnum.Intern)
                    {
                        Intern intern = (Intern)employee;
                        sb.Append(Environment.NewLine);
                        sb.Append('-');
                        sb.Append(intern.IntroduceYourself());
                    }
                    else
                    if (employee.EmployeeType == EmployeeTypeEnum.Manager)
                    {
                        Manager manager = (Manager)employee;
                        sb.Append(Environment.NewLine);
                        sb.Append('-');
                        sb.Append(manager.IntroduceYourself());
                    }
                }
            }

            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        public bool LayOffEmployeeByEmployeeId(string employeeId)
        {
            bool isLayOffSuccessful = false;

            try
            {
                var employeeToRemove = EmployeeList.Single(r => r.EmployeeId == employeeId);
                EmployeeList.Remove(employeeToRemove);

                isLayOffSuccessful = true;
            }

            catch(Exception ex)
            {
 
            }
   
            return isLayOffSuccessful;
        }
        
        public string PromoteToManager(Regular regular)
        {
            string promoted = "";
            StringBuilder sb = new StringBuilder(promoted);

            var employeeToRemove = EmployeeList.Single(r => r.EmployeeId == regular.EmployeeId);
            EmployeeList.Remove(employeeToRemove);
 
            Manager manager = new Manager(regular.Name, regular.Birthdate);
            EmployeeList.Add(manager);

            sb.Append(String.Format("Congratulations, {0} got promoted from Regular to Manager.", regular.Name));

            return sb.ToString();
        }

        public string PromoteToRegular(Intern intern)
        {
            string promoted = "";
            StringBuilder sb = new StringBuilder(promoted);

            // tried updating, wasn't enough so i'm deleting it and inserting it as regular

            //var employee = EmployeeList.FirstOrDefault(d => d.EmployeeId == intern.EmployeeId);
            //if (employee != null)
            //{
            //    var regular = (Regular)employee;
            //    employee.EmployeeType = EmployeeTypeEnum.Regular;
            //}

            var employeeToRemove = EmployeeList.Single(r => r.EmployeeId == intern.EmployeeId);
            EmployeeList.Remove(employeeToRemove);

            var manager = (Manager)intern.Manager;
            Regular regular = new Regular(intern.Name, intern.Birthdate, manager);

            EmployeeList.Add(regular);
             
            sb.Append(String.Format("Congratulations, {0} got promoted from Intern to Regular.", intern.Name));
 
            return sb.ToString();
        }
    }
}
