using System;


namespace Part2_Lesson2_Task1
{
    static class ListPrinter
    {
        public static void PrintList(Worker worker)
        {
            Console.WriteLine("ID № " + worker.PersonnelNumber + " " +
                worker.FirstName + " " + worker.SecondName + " " +
                worker.Salary + "RUB \n");
        }
    }
}
