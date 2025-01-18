using System;
 
namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");
 
            Console.Write("How many dice rolls would you like to simulate? ");
            if (!int.TryParse(Console.ReadLine(), out int rolls) || rolls <= 0)
            {
                Console.WriteLine("Please enter a valid positive integer.");
                return;
            }
 
            DiceSimulator simulator = new DiceSimulator();
            int[] rollResults = simulator.SimulateRolls(rolls);
 
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {rolls}.");
 
            for (int i = 2; i <= 12; i++)
            {
                double percentage = (rollResults[i] / (double)rolls) * 100;
                int asteriskCount = (int)Math.Round(percentage);
                Console.WriteLine($"{i}: {new string('*', asteriskCount)}");
            }
 
            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }
 
    class DiceSimulator
    {
        private static Random _random = new Random();
 
        public int[] SimulateRolls(int rolls)
        {
            int[] results = new int[13]; // Index 0 and 1 will remain unused
 
            for (int i = 0; i < rolls; i++)
            {
                int die1 = RollDie();
                int die2 = RollDie();
                int sum = die1 + die2;
                results[sum]++;
            }
 
            return results;
        }
 
        private int RollDie()
        {
            return _random.Next(1, 7); // Generates a random number between 1 and 6
        }
    }
}