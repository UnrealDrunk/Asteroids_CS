using System;


namespace Part2_Lesson2_Task1
{
    class HourlyPayWorker : Worker
    {
        public double HourlySalary { get; set; }

        public HourlyPayWorker(int personnelNumber, string firstName,
            string secondName, double hourlySallary) : base(personnelNumber,
                firstName, secondName)
        {
            this.HourlySalary = hourlySallary;
        }

        public override double CalculateSalary()
        {
            return Salary = 20.8 * 8 * HourlySalary;
        }

        public override void Print()
        {

            Console.Write("ID № " + PersonnelNumber + ", ");
            Console.Write(FirstName + ", ");
            Console.Write(SecondName + ", ");
            Console.WriteLine(CalculateSalary() + " RUB " + ", ");

        }
    }
}
