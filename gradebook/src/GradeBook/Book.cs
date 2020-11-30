using System;
using System.Collections.Generic;  //to be able to use List

namespace GradeBook
{
    public class Book
    {

        private List<double> grades;
        private string name;
        public string Name; //for testing example from video

        public Book(string name)
        {
            grades = new List<double>();
            //to allow the book name to equal name coming in.
            this.name = name;
            // for testing
            Name = name;
        }

        public void AddGrade(double grade)
        {
            //.Add is a method of type List
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in this.grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            result.Average /= grades.Count;
            return result;
        }

    }
}