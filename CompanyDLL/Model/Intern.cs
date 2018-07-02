using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Intern : Employee
    {
        public Employee Manager { get; set; }
        public Employee Mentor { get; set; }


        public Intern()
        {

        }

        public Intern(string name, DateTime birthDate, Manager manager, Regular mentor)
            : base(name, birthDate)
        {
            this.EmployeeType = EmployeeTypeEnum.Intern;
            this.Manager = manager;
            this.Mentor = mentor;
        }

        public override string IntroduceYourself()
        {
            string introduction = "";
            StringBuilder sb = new StringBuilder(introduction);

            sb.Append(String.Format("Yo, I'm {0}, {1} and working as Intern. I'm working for {2} and my mentor is {3}.", Name, Age, Manager.Name, Mentor.Name));

            return sb.ToString();
        }
    }
}
