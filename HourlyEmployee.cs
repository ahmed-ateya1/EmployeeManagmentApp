using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class HourlyEmployee : Employee
    {
        private decimal _hoursWorked;
        private decimal _rate;
        public decimal HoursWorked
        {
            get=> _hoursWorked;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _hoursWorked = value;
            }
        }
        public decimal Rate
        {
            set
            {
                if( value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _rate = value;
            }
        }
        public override decimal Pay()=> _hoursWorked * _rate;
        public void AddHour(int moreHour) => _hoursWorked += moreHour;
        public override string ToString()
        {
            var res = $"\n\t\t{nameof(HourlyEmployee)} Details\n\n";
            res += base.ToString();
            res += $"\n\t\tSalary: {Pay().ToString("C")}\n\n";
            return res;
        }
    }
}
