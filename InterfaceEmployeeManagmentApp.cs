using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public static class InterfaceEmployeeManagmentApp
    {
        #region Interface
        private static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\tWelcome to Employee Management Application");
            Console.WriteLine("\t\t\t-------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t1. Department" +
                              "\n\t\t\t2. Staff\n" +
                              "\t\t\t3. Project\n" +
                              "\t\t\t0. Exit");
            Console.Write("\t\t\tEnter Choice: ");
        }

        private static int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                Console.Write("\t\t\tInvalid input. Please enter a valid number : ");

                return GetUserChoice();
            }
        }

        private static void DepartmentMenu(List<Department> departments)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\tDepartment Menu\n");
            Console.WriteLine("\t\t\t----------------------------");
            Console.WriteLine("\t\t\t1. Add New Department\n\t\t\t2. Print All Departments\n");
            Console.Write("\t\t\tEnter Choice: ");

            int choice = GetUserChoice();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    AddNewDepartment(departments);
                    Console.WriteLine("Added successfully");
                    Console.Clear();
                    break;
                case 2:
                    PrintAllDepartments(departments);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private static void AddNewDepartment(List<Department> departments)
        {
            Console.WriteLine("\t\t\tEnter department details: \n");
            Console.WriteLine("\t\t\t------------------------------");
            Console.Write("\t\t\tEnter Department Id: ");
            int deptid = GetUserChoice();
            Console.Write("\n\t\t\tEnter Department Name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine();
            departments.Add(new Department() { DeptID = deptid, DeptName = deptName });
        }

        private static void PrintAllDepartments(List<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine(department);
            }
        }

        private static void StaffMenu(List<StaffMember> employees, List<Department> departments)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\tStaff Menu\n");
            Console.WriteLine("\t\t\t--------------------\n");
            Console.WriteLine("\t\t\t1. Add New Member\n" +
                              "\t\t\t2. Print All Members\n" +
                              "\t\t\t3. Calculate Payroll\n" +
                              "\t\t\t4. Delete Member\n" +
                              "\t\t\t0. Exit\n");
            Console.Write("\t\t\tEnter Choice: ");

            int choice = GetUserChoice();
            Staff staff = new Staff(employees, departments);
            Console.Clear();
            switch (choice)
            {
                case 1:
                    staff.AddMembers();
                    Console.Clear();
                    break;
                case 2:
                    PrintAllMembers(employees);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    staff.CalcPayroll();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    staff.DelMember();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private static void PrintAllMembers(List<StaffMember> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }


        private static void ProjectMenu(List<Project> projects, List<StaffMember> employees, List<Budget> budgets)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\tProject Menu\n");
            Console.WriteLine("\t\t\t--------------------\n");
            Console.WriteLine("\t\t\t1. Add New Project\n" +
                              "\t\t\t2. Print All Projects\n" +
                              "\t\t\t3. Increase Budget to Existing Project\n" +
                              "\t\t\t0. Exit\n");
            Console.Write("\t\t\tEnter Choice: ");
            int choice = GetUserChoice();
            Console.Clear();
            switch (choice)
            {
                case 1:
                    AddNewProject(projects, employees, budgets);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    PrintAllProjects(projects);
                    break;
                case 3:
                    IncreaseBudgetToExistingProject(projects, budgets);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    break;
            }
        }

        private static void IncreaseBudgetToExistingProject(List<Project> projects, List<Budget> budgets)
        {
            Console.WriteLine("\t\t\tIncrease Budget to Existing Project\n");
            Console.WriteLine("\t\t\t-----------------------------------");
            Console.Write("\t\t\tEnter Project Id: ");
            int.TryParse(Console.ReadLine(), out int projectId);

            var existingProject = projects.FirstOrDefault(p => p.Projectid == projectId);

            if (existingProject == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t\t\tProject with ID {projectId} not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("\t\t\tEnter Budget Id: ");
            int.TryParse(Console.ReadLine(), out int budgetId);

            Console.Write("\t\t\tEnter Budget adds value: ");
            decimal.TryParse(Console.ReadLine(), out decimal additionalValue);

            existingProject.IncreaseBudget(budgetId, additionalValue);
        }

        private static void AddNewProject(List<Project> projects, List<StaffMember> employees, List<Budget> budgets)
        {
            Console.WriteLine("\t\t\tEnter project details: \n");
            Console.WriteLine("\t\t\t------------------------------");
            Console.Write("\t\t\tEnter Project Id: ");
            int.TryParse(Console.ReadLine(), out int id);

            var existingProject = projects.FirstOrDefault(p => p.Projectid == id);

            if (existingProject != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\tProject with the specified ID already exists.");
                Console.ResetColor();
                return;
            }
            Console.Write("\t\t\tEnter Budget Id: ");
            int.TryParse(Console.ReadLine(), out int budgetId);
            var existingBudget = budgets.FirstOrDefault(p => p.IdBudget == budgetId);
            Console.Write("\t\t\tEnter Amount Of Budget: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            var budget = new Budget { IdBudget = budgetId, Value = amount };

            Console.Write("\t\t\tEnter Location: ");
            string location = Console.ReadLine();
            Console.Write("\t\t\tEnter Manager Id: ");
            int.TryParse(Console.ReadLine(), out int managerId);

            var manager = employees.FirstOrDefault(e => e.EmployeeId == managerId);

            if (manager == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\tManager Not Found");
                Console.ResetColor();
                return;
            }

            Console.Write("\t\t\tEnter Current Cost: ");
            decimal.TryParse(Console.ReadLine(), out decimal cur);

            var newProject = new Project
            {
                Projectid = id,
                Location = location,
                Manager = manager,
                CurrentCost = cur,
            };
            newProject.AddBudget(budget);
            projects.Add(newProject);
            Console.ResetColor();
        }

        private static void PrintAllProjects(List<Project> projects)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\tAll Projects\n");
            Console.WriteLine("\t\t\t-----------------\n");

            if (projects.Any())
            {
                foreach (var project in projects)
                {
                    Console.WriteLine(project);
                    Console.WriteLine("\t\t\t-----------------\n");
                }
            }
            else
            {
                Console.WriteLine("\t\t\tNo projects available.\n");
            }

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static void Interface_(List<Department> departments, List<StaffMember> employees, List<Project> projects, List<Budget> budget)
        {
            int choice = -1;

            while (choice != 0)
            {
                Welcome();
                choice = GetUserChoice();
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        DepartmentMenu(departments);
                        break;
                    case 2:
                        StaffMenu(employees, departments);
                        break;
                    case 3:
                        ProjectMenu(projects, employees, budget);
                        break;
                    case 0:
                        break;
                }
            }
        }
        public  static void VersionInterface()
        {
            List<Department> departments = new List<Department>();
            List<StaffMember> employees = new List<StaffMember>();
            List<Project> projects = new List<Project>();
            List<Budget> budget = new List<Budget>();
            Interface_(departments, employees, projects, budget);
        }
        #endregion
    }
}
