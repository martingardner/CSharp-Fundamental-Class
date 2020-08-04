using System;

namespace GradeBook
{
    class Program
    {
        // dotnet run -- Martin
        static void Main(string[] args)
        {

            var numbers = new [] { 12.7, 10.3, 6.11};
            var result = 0.0;
            foreach(var number in numbers)
            {
                result += number;
            }

            Console.WriteLine(result);

            /*
            Console.WriteLine(numbers[0] + numbers[1] + numbers[2]);
            */
            /*
            var x = 34.1;
            var y = 35.9;            

            Console.WriteLine(x + y);
            */
            /*


            if(args.Length > 0)
            {
                Console.WriteLine($"Hello,  { args[0] } !");
            }
            else 
            {
                Console.WriteLine("Hello");
            }
            */
        }
    }
}
