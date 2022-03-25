
using System;
using Composition.Entities.Enums;
using Composition.Entities;
using System.Globalization;


namespace Composition
{
    /*
     
       Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário).
       Depois, solicitar do usuário um mês e mostrar qual foi o salário do funcionário nesse mês, conforme exemplo
      
       Enter department's name: Design
       Enter worker data:
       Name: Alex
       Level (Junior/MidLevel/Senior): MidLevel
       Base salary: 1200.00
       How many contracts to this worker? 3
       Enter #1 contract data:
       Date (DD/MM/YYYY): 20/08/2018
       Value per hour: 50.00
       Duration (hours): 20
       Enter #2 contract data:
       Date (DD/MM/YYYY): 13/06/2018
       Value per hour: 30.00
       Duration (hours): 18
       Enter #3 contract data:
       Date (DD/MM/YYYY): 25/08/2018
       Value per hour: 80.00
       Duration (hours): 10

       Enter month and year to calculate income (MM/YYYY): 08/2018
       Name: Alex
       Department: Design
       Income for 08/2018: 3000.00
    
    */

    class Composition
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Departament dept = new Departament(deptName);

            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("How many contracts to this worker? ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            Worker worker = new Worker(name, level, baseSalary, dept);

            for (int i = 0; i < numberOfContracts; i++)
            {
                Console.WriteLine($"Enter #{i + 1} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                string data = Console.ReadLine();
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int numberOfHours = int.Parse(Console.ReadLine());
                var contract = new HourContract(DateTime.Parse(data), valuePerHour, numberOfHours);
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYearIncome = Console.ReadLine();

            int month = int.Parse(monthAndYearIncome.Substring(0, 2));
            int year = int.Parse(monthAndYearIncome.Substring(3, 4));

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Departament.Name}");
            Console.WriteLine($"Income for {monthAndYearIncome}: {worker.Income(month, year).ToString("F2", CultureInfo.InvariantCulture)}");

        }
    }
}
