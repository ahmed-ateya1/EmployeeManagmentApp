using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class CommissionEmployee : Employee
    {
        private decimal _target;
        public decimal Target
        {
            get=> _target;
            set
            {
                if(value < 0) value = 0;
                _target = value;
            }
        }
        public override decimal Pay() => 0.05m * _target;
        public override string ToString()
        {
            var res = $"\n\t\t{nameof(CommissionEmployee)} Details\n\n";
            res += base.ToString();
            res += $"\n\t\tSalary: {Pay().ToString("C")}\n\n";
            return res;
        }
    }
}
