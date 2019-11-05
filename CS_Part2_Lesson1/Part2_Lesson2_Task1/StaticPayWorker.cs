using System;


namespace Part2_Lesson2_Task1
{
    class StaticPayWorker: Worker
    {
        public StaticPayWorker(int personnelNumber, string firstName,
            string secondName, double salary) : base(personnelNumber,
                firstName, secondName)
        {
            Salary = salary;
        }

        public override double CalculateSalary()
        {
            return Salary;
        }

        public override void Print()
        {
            Console.Write("ID № " + PersonnelNumber + ", ");
            Console.Write(FirstName + ", ");
            Console.Write(SecondName + ", ");
            Console.WriteLine(Salary + " RUB " + "; ");

        }

    }
}
