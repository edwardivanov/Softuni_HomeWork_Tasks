﻿using System.Text;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            : base (id,firstName,lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }       

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($" Salary: {this.Salary:F2}");
            return sb.ToString().Trim();
        }
    }
}
