using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentApp
{
    public class Budget
    {
        private int _idBudget;
        private decimal _value;
        public int IdBudget { get => _idBudget; set => _idBudget = value; }
        public decimal Value { get => _value; set => _value = value; }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null, obj)) 
                return false;
            return obj is Budget budget &&
                   _idBudget == budget._idBudget &&
                   _value == budget._value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_idBudget, _value);
        }

        public decimal IncreaseBudget(decimal amount)
        {
            Value += amount;
            return Value;
        }
    }
}
