using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Collections
{
    internal class ImmutableDemo
    {
        public static void Show()
        {

            List<int> l = [1, 2, 3, 4];

            ImmutableList<int> immutableList = [1, 2, 3, 4];

            Add10(immutableList);

            Console.WriteLine();
            Console.WriteLine(Formatted(immutableList));

        }


        public static void Add10(IList<int> l)
        {
            
            var l1 = (ImmutableList<int>)l;
            var newList = l1.Add(10);
                     

            Console.WriteLine(Formatted(newList));
        }



        public void Add(ImmutableList<int> l)
        {
            l.AddRange(new[] { 1, 4, 4, 5, 5, 5 });

            var newCollection = new List<int>() { };
            foreach (var el in l)
            {
                newCollection.Add(el);
            }
            // SendToAirport(l)
        }




        record MyRecord(int a, string b);





        private static void InStolbikReadonly(IReadOnlyCollection<int> inputList)
        {
            foreach (var i in inputList)
            {
                Console.WriteLine($"|{i}|");
            }
        }




























        private static ImmutableList<int> InStolbik(ImmutableList<int> inputList)
        {
            var newList = inputList.Add(4);
            foreach (var i in inputList)
            {
                Console.WriteLine($"|{i}|");
            }

            Console.WriteLine("-----------------");
            var l = inputList.ToList();
            foreach (var i in newList)
            {
                Console.WriteLine($"|{i}|");
            }


            Console.WriteLine(newList == inputList);
            return newList;
        }


        private static string Formatted(IEnumerable<int> a)
        {

            return $"[{string.Join(",", a)}]";
        }

        private static string Formatted(IEnumerable<string> a)
        {

            return $"[{string.Join(",", a)}]";
        }
    }
}
