using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class ExecutiveEmployee : SalariedEmployee
    {
        private decimal _bouns;
        private decimal _total;

        public decimal Bouns
        {
            get => _bouns;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _bouns = value;
            }
        }

        public override decimal Pay() => base.Pay() + Bouns;

        public void AddBouns(decimal Morebouns) => _bouns += Morebouns;

        public override string ToString()
        {
            var res = base.ToString();
            res += $"\t\tBouns: {Bouns}\n";
            res += $"\t\tType: Executive Salaried Employee\n";
            return res;
        }
    }
}
