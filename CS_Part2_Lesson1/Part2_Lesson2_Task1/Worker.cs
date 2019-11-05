using System;


namespace Part2_Lesson2_Task1
{
    abstract class Worker : IComparable<Worker>
    {
        public int PersonnelNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Salary { get; set; }

        public abstract double CalculateSalary();

        public Worker(int personnelNumber, string firstName, string secondName)
        {
            PersonnelNumber = personnelNumber;
            FirstName = firstName;
            SecondName = secondName;
        }



        public abstract void Print();

        public int CompareTo(Worker other)
        {
            var res = -Salary.CompareTo(other.Salary);
            if (res == 0)
                res = SecondName.CompareTo(other.SecondName);
            return res;
        }


    }
}
