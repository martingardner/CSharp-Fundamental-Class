using System;
using System.Collections.Generic;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /********** Dictionary **************/
            var dict = new Dictionary<string, object>();

            dict.Add("Scott", 115);
            dict.Add("Bob", 118);
            dict.Add("Clarence", 2174);

            //searches through dictionary looking for first Scott reference
            var Scott = dict["Scott"];

            Console.WriteLine(Scott);
            foreach (var item in dict)
            {
                Console.WriteLine("{0} and {1}", item.Key, item.Value);
            }
            /********** Dictionary End *********/

        }
    }
}
