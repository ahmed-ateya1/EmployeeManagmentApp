using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public abstract class Employee : StaffMember
    {
        private string _socialSecurityNumber;
        public string SocialSecurityNumber
        {
            get => _socialSecurityNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("value");
               _socialSecurityNumber = value;
            }
        }

        public override string ToString()
        {
            var str = base.ToString();
            str += $"\n\t\tSocialSecurityNumber: {SocialSecurityNumber}\n";
            return str;
        }
    }
}
