using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class Volunteer : StaffMember
    {
        private decimal _amount;
        public decimal Amount
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _amount = value;
            }
        }
        public override decimal Pay()=> _amount;
        public override string ToString()
        {
            var res = $"\n\t\t{nameof(Volunteer)} Details\n\n";
            res += base.ToString();
            res += $"\t\tAmount of Value: {Pay().ToString("C")}\n\n";
            return res;
        }
    }
}
