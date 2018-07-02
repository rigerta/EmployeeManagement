using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Manager : Employee
    {
        public List<Employee> EmployeesList { get; set; }

        public Manager()
        {

        }

        public Manager (string name, DateTime birthDate)
            : base(name, birthDate)
        {
            this.EmployeeType = EmployeeTypeEnum.Manager;
        }

        public override string IntroduceYourself()
        {
            string introduction = "";
            StringBuilder sb = new StringBuilder(introduction);

            sb.Append(String.Format("Good day, I'm {0} ({1}), currently a Manager and I'm {2} years old.", Name, EmployeeId, Age));

            return sb.ToString();
        }
    }
}
