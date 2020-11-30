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

        public void AddLetterGrade(char letter)
        {
            //works similar to js except must always have a break, can't have fall through logic
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                //.Add is a method of type List
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

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

            /*
            for (var index = 0; index < grades.Count; index += 1)
            {

                if (grades[index] == 42.1)
                {
                    //break;
                    //goto done; //should never really be used, holdover from C, will go to done: statement below.
                    continue;
                }

                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            */

            result.Average /= grades.Count;
            switch (result.Average)
            {
                //pattern matching switch statement
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d > 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            //var index = 0;

            /*
            while (index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1;
            };
            */
            /*
            do
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index += 1;
            } while (index < grades.Count);
            */


            //done:  used only if goto statement is used and then shouldn't be used that often as holdover from original C
            return result;
        }

    }
}