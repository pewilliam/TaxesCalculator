using System;
using System.Globalization;
using System.Collections.Generic;
using TaxesCalculator.Entities;

namespace TaxesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.Clear();

                Console.WriteLine("Tax payer #" + i + " data:");
                Console.Write("Individual or company (I/C): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i' || ch == 'I')
                {
                    Console.Write("Helth expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }

            Console.Clear();

            double sum = 0;
            Console.WriteLine("Taxes paid: ");

            foreach(TaxPayer payer in list)
            {
                Console.WriteLine(payer.Name + ": R$ " + payer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                sum += payer.Tax();
            }

            Console.WriteLine("\n\nTotal paid taxes: R$ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
