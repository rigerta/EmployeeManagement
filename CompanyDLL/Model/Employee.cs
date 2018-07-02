using System;
 
namespace DAL
{
    public abstract class Employee 
    {
        private string _name;
        private DateTime _birthdate;
        private EmployeeTypeEnum _employeeType;
 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public EmployeeTypeEnum EmployeeType
        {
            get { return _employeeType; }
            set { _employeeType = value; }
        }

        // it doesn't have a setter, in order to be readonly
        public int Age
        {
            get
            {
                return DateTime.Now.Year - _birthdate.Year;
            }
        }

        // it doesn't have a setter, in order to be readonly
        public string EmployeeId
        {
            get
            {
                return String.Format("{0}{1}", _employeeType.ToString().Substring(0, 1), _birthdate.ToString("yyyyMMdd"));
            }
        }
 
        public Employee() { }

        public Employee (string name, DateTime birthDate)
        {
            _name = name;
            _birthdate = birthDate;
        }

        public abstract string IntroduceYourself();
    }
}
