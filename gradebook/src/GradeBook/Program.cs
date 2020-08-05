using System;
using System.Collections.Generic;  //to be able to use List

namespace GradeBook
{

    class Program
    {
        // dotnet run -- Martin
        static void Main(string[] args)
        {

            var book = new Book("Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(10.6);
            book.ShowStatistics();


            /*
            var numbers = new[] { 12.7, 10.3, 6.11 };
            var grades = new List<double>() { 12.7, 10.3, 6.11 };
            var lenGrades = grades.Count;
            grades.Add(56.1);
            //grades[0]

            var result = 0.0;
            foreach (var number in grades)
            {
                result += number;
            }

            Console.WriteLine($"the total is {result:N3}");
            Console.WriteLine($"the average is {(result / lenGrades):N3}");
            */
            /*

            var result = 0.0;
            foreach (var number in numbers)
            {
                result += number;
            }

            Console.WriteLine(result);
            */
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
