using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types.Task.One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialDeposit = double.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());
            CalculateSavings(initialDeposit, years, interestRate);

        }
        static void CalculateSavings(double initialDeposit, int years, double interestRate)
        {
            double currentSavings = initialDeposit;
            for (int i = 0; i < years; i++)
            {
                currentSavings = (currentSavings / interestRate) + currentSavings;
                Console.WriteLine($"Год {i + 1}: {Math.Round(currentSavings, 2):F2} руб.");
            }
        }
    }
}
