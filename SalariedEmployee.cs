
namespace EmployeeManagmentApp
{
    public class SalariedEmployee : Employee
    {
        private decimal _salary;

        public decimal Salary
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _salary = value;
            }
        }

        public override decimal Pay() => _salary;

        public override string ToString()
        {
            var res = "\n\t\t\tSalaried Employee\n";
            res += base.ToString();
            res += $"\n\t\tSalary: {Pay().ToString("C")}\n";
            return res;
        }
    }

}
