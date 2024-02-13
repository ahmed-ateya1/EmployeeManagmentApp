using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class Project
    {
        private int _projectid;
        private string _location;
        private StaffMember _manager;
        private decimal _currentCost;
        private List<Budget> _budgets = new List<Budget>();

        public int Projectid { get => _projectid; set => _projectid = value; }
        public string Location { get => _location; set => _location = value; }
        
        public decimal CurrentCost { get => _currentCost; set => _currentCost = value; }
        public List<Budget> Budgets { get => _budgets; set => _budgets = value; }
        public StaffMember Manager { get => _manager; set => _manager = value; }

        public void AddBudget(Budget budget)
        {
            var existingBudget = Budgets.FirstOrDefault(x => x.IdBudget == budget.IdBudget);

            if (existingBudget == null)
            {
                Budgets.Add(budget);
            }
            else
            {
                existingBudget.Value += budget.Value;
            }
        }
        public decimal GetTotalBudget()
        {
            decimal totalBudget = 0;

            foreach (var budget in Budgets)
            {
                totalBudget += budget.Value;
            }

            return totalBudget - CurrentCost;
        }
        public void IncreaseBudget(int budgetId, decimal additionalValue)
        {
            var existingBudget = Budgets.FirstOrDefault(x => x.IdBudget == budgetId);

            if (existingBudget == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\t\t\tBudget with ID {budgetId} not found for the project.");
                Console.ResetColor();
            }
            else
            {
                existingBudget.IncreaseBudget(additionalValue);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\tBudget with ID {budgetId} increased by {additionalValue} successfully.");
                Console.ResetColor();
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t\t\tProject ID: {Projectid}");
            sb.AppendLine($"\t\t\tLocation: {Location}");
            sb.AppendLine($"\t\t\tManager: {Manager.EmployeeName}");
            sb.AppendLine($"\t\t\tCurrent Cost: {CurrentCost}");

            if (Budgets.Any())
            {
                sb.AppendLine("\t\t\tBudgets:");
                foreach (var budget in Budgets)
                {
                    sb.AppendLine($"\t\t\t\t\tBudget ID: {budget.IdBudget}, Value: {budget.Value}");
                }
                sb.AppendLine($"\t\t\tTotal Budget: {GetTotalBudget()}");
            }
            else
            {
                sb.AppendLine("No Budgets assigned yet.");
            }

            return sb.ToString();
        }
    }
}
