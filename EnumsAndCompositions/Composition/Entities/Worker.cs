using Composition.Entities.Enums;
using System.Collections.Generic;

namespace Composition.Entities
{
    public class Worker
    {
        private readonly List<HourContract> _contracts;

        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }

        public List<HourContract> Contracts
        {
            get { return _contracts; }
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Departament departament) : base()
        {
            _contracts = new List<HourContract>();

            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(HourContract hourContract)
        {
            Contracts.Add(hourContract);
        }

        public void RemoveContract(HourContract hourContract)
        {
            Contracts.Remove(hourContract);
        }

        public double Income(int month, int year)
        {
            double income = BaseSalary;

            foreach (HourContract contract in Contracts)
            {
                if (contract.Data.Year == year && contract.Data.Month == month)
                    income += contract.TotalValue();
            }

            return income;
        }
    }
}
