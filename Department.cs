using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class Department
    {
        private int _id;
        private string _name;

        public int DeptID
        {
            get => _id;
            set => _id = value;
        }

        public string DeptName
        {
            get => _name;
            set => _name = value;
        }

        public Dictionary<int, StaffMember> Employees { get; set; } = new Dictionary<int, StaffMember>();

        public override string ToString()
        {
            return 
                $"\t\tDepartment Details\n\t\t\t" +
                $"Department Id: {DeptID}\n\t\t\t" +
                $"DepartmentName: {DeptName}\n" +
                $"\t\tNum of employees in the department: {Employees.Count}\n\n";
        }
    }

}
