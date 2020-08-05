using System;
using System.Collections.Generic;  //to be able to use List

namespace GradeBook
{
    class Book
    {

        private List<double> grades;
        private string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            var lenGrades = grades.Count;

            foreach (var number in this.grades)
            {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }

            Console.WriteLine($"the total is {result:N3}");
            Console.WriteLine($"the average is {(result / lenGrades):N3}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The highest grade is {highGrade}");
        }
    }
}