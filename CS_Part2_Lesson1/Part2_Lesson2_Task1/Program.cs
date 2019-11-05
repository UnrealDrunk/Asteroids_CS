using System;
using System.Collections.Generic;


namespace Part2_Lesson2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating List of workers
            var workers = new List<Worker>
            {
                new HourlyPayWorker(001, "Ivan", "Ivanov", 200),
                new HourlyPayWorker(015, "Peter", "Petrov", 180),
                new HourlyPayWorker(007, "James", "Bond", 300),
                new StaticPayWorker(101, "Arnold", "Terminator", 110000),
                new StaticPayWorker(302, "Anna", "Sidorova", 90000),
                new StaticPayWorker(209, "Tanya", "Borisova", 120000)
            };

            //print List of Workers using Print method inside Worker class
            Console.WriteLine("Print List of workers before sorting" + "\n");

            foreach (var worker in workers)
                worker.Print();

            workers.Sort();
            Console.WriteLine("\n" + "Print List of workers after sorting" + "\n");

            foreach (var worker in workers)
                worker.Print();

            Console.WriteLine("\n" + "Print List of workers using ListPrinter class " + "\n");
            foreach (var worker in workers)
                ListPrinter.PrintList(worker);


        }
    }
}
