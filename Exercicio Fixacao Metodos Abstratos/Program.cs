using System;
using System.Collections.Generic;
using System.Globalization;
using Exercicio_Fixacao_Metodos_Abstratos.Entities;

namespace Exercicio_Fixacao_Metodos_Abstratos
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
                Console.WriteLine("Tax payer #"+i+" data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach(TaxPayer TP in list)
            {
                Console.WriteLine(TP.Name+": $"+TP.Tax().ToString("F2",CultureInfo.InvariantCulture));
            }
            double sum = 0.0;
            foreach (TaxPayer TP in list)
            {
                sum += TP.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $"+sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
