using System;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDictionary = new MyDictionary<string, int>();
            string index = "Four";

            myDictionary.Add("One", 1);
            myDictionary.Add("Two", 2);
            myDictionary.Add("Three", 3);
            myDictionary.Add("Four", 4);

            Console.WriteLine("-- Testing Get method");
            Console.WriteLine($"[{index}] => {myDictionary.Get(index)}");
            Console.WriteLine();

            myDictionary.Add("Five", 5);

            Console.WriteLine("-- Increasing Capacity");
            myDictionary.Add("Six", 6);
            myDictionary.Add("Seven", 7);
            myDictionary.Add("Eight", 8);
            myDictionary.Add("Nine", 9);
            myDictionary.Add("Ten", 10);
            myDictionary.Add("Eleven", 11);
            myDictionary.Add("Twelve", 12);
            Console.WriteLine();

            // Adding existing value with different key
            myDictionary.Add("Eight Again", 8);

            Console.WriteLine("Using indexer");
            index = "Seven";
            Console.WriteLine($"[{index}] => {myDictionary[index]}");

            index = "Thirteen";
            myDictionary[index] = 13;
            Console.WriteLine($"[{index}] => {myDictionary[index]}");
            Console.WriteLine();

            Console.WriteLine("-- Adding the same key");
            try
            {
                myDictionary[index] = 13;
            }
            catch (Exception e)
            {
                Console.WriteLine("-- Exception");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }


            Console.WriteLine("-- foreach");
            foreach (var kVP in myDictionary)
            {
                Console.WriteLine($"[{kVP.Key}] => [{kVP.Value}]");
            }
        }
    }
}
