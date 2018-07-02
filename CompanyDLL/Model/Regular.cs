using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Regular : Employee
    {
        public Employee Manager { get; set; }


        public Regular()
        {

        }
 
        public Regular(string name, DateTime birthDate, Manager manager)
            : base(name, birthDate)
        {
            this.EmployeeType = EmployeeTypeEnum.Regular;
            this.Manager = manager;
        }

        public override string IntroduceYourself()
        {
            string introduction = "";
            StringBuilder sb = new StringBuilder(introduction);

            sb.Append(String.Format("Hello, my name is {0} ({1}), I'm {2} and currently working as Regular. My boss is {3}", Name, EmployeeId, Age, Manager.Name));

            return sb.ToString();
        }
    }
}
