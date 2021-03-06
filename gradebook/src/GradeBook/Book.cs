using System;
using System.Collections.Generic;  //to be able to use List
using System.IO;

namespace GradeBook
{
    //ordinarily this would be it's own file but for example, put here for ease of lesson
    //type object is the base type for C# anything can be passed using type object
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject
    {

        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        //  abstract method, so anything inheriting from BookBase will need to have an AddGrade method, regardless of what it does.
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; set; }
        event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name) { }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

            //writer.Dispose(); // from IDispose which AppendText inherits from if you f12 it deep enough
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    //public class InMemoryBook : Book, IBook
    {

        //readonly string category = "Science";
        private List<double> grades;

        //now being inherited from NamedObject.
        //public string Name;
        public string name;

        /*
        //can be public if it needs to be read outside of class
        const string CATEGORY = "Science";
        */

        /*
        auto property
        */
        // add private to setter means can only be used inside class
        /*
                public string Name { get; private set; }
                public string name { get; private set; }
        */
        /*
        private string name;
        //public string Name; //for testing example from video


        //property examples
        //set value is implicit for setter
        //original way of C#
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }

            }
        }
        */


        public InMemoryBook(string name) : base("")
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


        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                //.Add is a method of type List
                grades.Add(grade);
                //Event emitter
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        //event emitter tied to AddGrade above, and the delegate at top of file
        public override event GradeAddedDelegate GradeAdded;



        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);

            }

            /*
            foreach (var grade in this.grades)
            {
                
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            */
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