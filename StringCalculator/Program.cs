 namespace StringCalculator
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string for calculation:");
            var numbers = Console.ReadLine();
            StringCalculator calculator = new StringCalculator();
            Console.WriteLine($"Output for entered string with Numbers {numbers } is : " + calculator.Add(numbers).ToString());
            Console.ReadKey();
        }
    }
}
