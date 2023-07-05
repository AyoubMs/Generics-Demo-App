using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] testArr;
            //List<string> stringList = new List<string>();
            //List<int> intList = new List<int>();

            //string test = "";
            //string result = FizzBuzz("tests");

            //Console.WriteLine($"Tests: {result}");

            //result = FizzBuzz(123);

            //Console.WriteLine($"123: {result}");

            //result = FizzBuzz(true);

            //Console.WriteLine($"true: {result}");

            //result = FizzBuzz(new PersonModel { FirstName = "Tim", LastName = "Corey" });

            //Console.WriteLine($"PersonModel: {result}");

            GenericHelper<PersonModel> peopleHelper = new GenericHelper<PersonModel>();
            peopleHelper.CheckItemAndAdd(new PersonModel
            {
                FirstName = "Tim",
                HasError = true,
            });

            foreach (var item in peopleHelper.RejectedItems)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} was rejected.");
            }

            Console.ReadLine();
        }

        // 3 - Fizz, 5 - Buzz, 3 & 5 - FizzBuzz
        private static string FizzBuzz<T>(T item)
        {
            int itemLength = item.ToString().Length;
            string output = string.Empty;

            if (itemLength % 3 == 0)
            {
                output += "Fizz";
            }

            else if (itemLength % 5 == 0)
            {
                output += "Buzz";
            }

            return output;
        }

        private static string GenericMethod<T>(T item)
        {
            return item.ToString();
        }

    }

    public class GenericHelper<T> where T : IErrorCheck
    {
        public List<T> Items { get; set; } = new List<T>();
        public List<T> RejectedItems { get; set; } = new List<T> { };

        public void CheckItemAndAdd(T item)
        {
            if (item.HasError == false)
            {
                Items.Add(item);
            }
            else
            {
                RejectedItems.Add(item);
            }
        }
    }

    public interface IErrorCheck
    {
        bool HasError { get; set; }
    }

    public class CarModel : IErrorCheck
    {
        public string Manufacturer { get; set; }
        public int YearManufactured { get; set; }
        public bool HasError { get; set; }

    }

    public class PersonModel : IErrorCheck
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasError { get; set; }
    }
}
