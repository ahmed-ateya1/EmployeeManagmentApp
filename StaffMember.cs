
namespace EmployeeManagmentApp
{
    public abstract class StaffMember
    {

        private int _employeeId;
        private string _employeeName;
        private string _phone;
        private string _email;
        private Department _department;

        public int EmployeeId
        {
            get => _employeeId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Negative Value");
                _employeeId = value;
            }
        }

        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
                _employeeName = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (!IsValidPhone(value))
                    return;
                _phone = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!IsValidEmail(value))
                    return;
                _email = value;
            }
        }

        public Department Department
        {
            get => _department;
            set
            {
                if (_department != null)
                {
                    _department.Employees.Remove(EmployeeId);//if employee in another dept
                }

                _department = value;

                if (value != null)
                {
                    value.Employees[EmployeeId] = this;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10;
        }

        public abstract decimal Pay();

        public override string ToString()
        {
            var res = "\t\t---------------------------\n";
            res += $"\t\tMember Id: {EmployeeId}\n";
            res += $"\t\tMember Name: {EmployeeName}\n";
            res += $"\t\tPhone: {Phone}\n";
            res += $"\t\tEmail: {Email}\n";
            if (Department != null)
                res += $"{Department.ToString()}";
            return res;
        }
    }
}
