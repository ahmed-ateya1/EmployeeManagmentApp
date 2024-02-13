namespace EmployeeManagmentApp
{
    public class Staff
    {
        private List<StaffMember> Employees { get; set; } = new List<StaffMember>();
        private List<Department> Departments { get; set; } = new List<Department>();
        public Staff(List<StaffMember> employees, List<Department> departments)
        {
            Employees = employees ?? throw new ArgumentNullException(nameof(employees));
            Departments = departments ?? throw new ArgumentNullException(nameof(departments));
        }
        public void CalcPayroll()
        {
            var totalPayroll = Employees.Sum(x => x.Pay());
            Console.WriteLine($"\t\tTotal Payroll: {totalPayroll.ToString("C")}");
        }

        public void AddMembers()
        {
            Console.WriteLine("\t\t\tEnter Member Details:");
            Console.WriteLine("\t\t------------------------------------");
            Console.Write("\t\tEmployee Id: ");
            int empId = int.Parse(Console.ReadLine());
            Console.Write($"\n\t\tEmployee Name: ");
            string empName = Console.ReadLine();
            Console.Write($"\n\t\tPhoneNo: ");
            string phone = Console.ReadLine();
            Console.Write($"\n\t\tEmail Address: ");
            string email = Console.ReadLine();
            Console.Write($"\n\t\tDepartment Id: ");
            int deptId = int.Parse(Console.ReadLine());

            var existingDepartment = Departments.FirstOrDefault(d => d.DeptID == deptId);

            if (existingDepartment == null)
            {
                Console.Write("\n\t\tDepartment Not Found Enter Department Name to Add: ");
                string deptName = Console.ReadLine();
                existingDepartment = new Department { DeptID = deptId, DeptName = deptName };
                Departments.Add(existingDepartment);
            }

            Console.Write("\t\tEmployee Type (1 for Hourly, 2 for Salaried, 3 for Commission, 4 for Executive, 5 for Volunteer): ");
            int employeeType = int.Parse(Console.ReadLine());

            StaffMember newEmp = null;

            switch (employeeType)
            {
                case 1:
                    newEmp = new HourlyEmployee();
                    AddHourlyEmployee(newEmp);
                    break;
                case 2:
                    newEmp = new SalariedEmployee();
                    AddSalariedEmployee(newEmp);
                    break;
                case 3:
                    newEmp = new CommissionEmployee();
                    AddCommissionEmployee(newEmp);
                    break;
                case 4:
                    newEmp = new ExecutiveEmployee();
                    AddExecutiveEmployee(newEmp);
                    break;
                case 5:
                    newEmp = new Volunteer();
                    AddVolunteer(newEmp);
                    break;
                default:
                    Console.WriteLine("Invalid employee type.");
                    break;
            }

            newEmp.Email = email;
            newEmp.Phone = phone;
            newEmp.EmployeeName = empName;
            newEmp.EmployeeId = empId;
            newEmp.Department = existingDepartment;

            if (newEmp != null)
            {
                Employees.Add(newEmp);
            }
        }

        private void AddSalariedEmployee(StaffMember member)
        {
            if (member == null) return;
            var salariedEmp = member as SalariedEmployee;
            Console.Write($"\n\t\tEnter Social Security Number: ");
            string socialSecurityNumber = Console.ReadLine();
            Console.Write("\n\t\tEnter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            salariedEmp.Salary = salary;
            salariedEmp.SocialSecurityNumber = socialSecurityNumber;
        }

        private void AddHourlyEmployee(StaffMember member)
        {
            if (member == null) return;
            var HourlyEmp = member as HourlyEmployee;
            Console.Write($"\n\t\tEnter Social Security Number: ");
            string socialSecurityNumber = Console.ReadLine();
            Console.Write("\n\t\tEnter Hours Work: ");
            decimal hoursWorked = decimal.Parse(Console.ReadLine());
            Console.Write("\n\t\tEnter Rate: ");
            decimal Rate = decimal.Parse(Console.ReadLine());
            HourlyEmp.HoursWorked = hoursWorked;
            HourlyEmp.Rate = Rate;
            HourlyEmp.SocialSecurityNumber = socialSecurityNumber;
        }

        private void AddExecutiveEmployee(StaffMember member)
        {
            if (member == null) return;
            var executiveEmp = member as ExecutiveEmployee;
            Console.Write($"\n\t\tEnter Social Security Number: ");
            string socialSecurityNumber = Console.ReadLine();
            Console.Write($"\n\t\tEnter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("\n\t\tEnter Bonus: ");
            decimal bonus = decimal.Parse(Console.ReadLine());
            executiveEmp.SocialSecurityNumber = socialSecurityNumber;
            executiveEmp.Bouns = bonus;
            executiveEmp.Salary = salary;
        }

        private void AddVolunteer(StaffMember member)
        {
            if (member == null) return;
            var volunteerEmp = member as Volunteer;
            Console.Write($"\n\t\tAmount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            volunteerEmp.Amount = amount;
        }

        private void AddCommissionEmployee(StaffMember member)
        {
            if (member == null) return;
            var commissionEmp = member as CommissionEmployee;
            Console.Write($"\n\t\tEnter Social Security Number: ");
            string socialSecurityNumber = Console.ReadLine();
            Console.Write($"\n\t\tEnter Target: ");
            decimal target = decimal.Parse(Console.ReadLine());
            commissionEmp.Target = target;
        }

        public void DelMember()
        {
            Console.Write("\t\tEnter Member Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            if(DeleteMemberById(id))
                Console.WriteLine("\t\tDeleted successfully.");
            else
                Console.WriteLine("\t\tUser Not Found !");
        }

        private bool DeleteMemberById(int id)
        {
            var emp = Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (emp == null) return false;

            var department = emp.Department;

            if (department != null)
            {
                department.Employees.Remove(id);
            }

            Employees.Remove(emp);
            return true;
        }

    }
}
