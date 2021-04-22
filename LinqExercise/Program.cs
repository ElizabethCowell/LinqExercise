using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum(x => x);
            Console.WriteLine("Sum");
            Console.WriteLine(sum);
            var average = numbers.Average(x => x);
            Console.WriteLine("Average");
            Console.WriteLine(average);

            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending");

            var ascending = numbers.OrderBy(x => x);
            foreach (var num in ascending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Descending");
            var descending = numbers.OrderByDescending(x => x);
            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6");

            var larger = numbers.Where(x => x > 6);
            foreach (var num in larger)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Acsending first 4");
            var firstFour = numbers.OrderBy(x => x).Take(4);
            foreach( var num in firstFour)
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Age in index 4 decending");
            numbers[4] = 36;
            Console.WriteLine("Before decending:");
            foreach (var num in numbers)
                {
                Console.Write(num + ", ");
            }
            Console.WriteLine("");
            var age = numbers.OrderByDescending(x => x);
            foreach (var num in age)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Employees");
            var empList = employees.Where(x => x.FirstName.StartsWith("C") || x.FullName.StartsWith("S")).OrderBy(x => x.FirstName);
            foreach (var person in empList)
            {
                Console.WriteLine(person.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("By age then by first name");
            var aboveAge = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var employee in aboveAge)
            {
                Console.WriteLine(employee.FullName + " " + employee.Age);
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            Console.WriteLine("Sum of Experience");
            var YOESum = employees.Sum(x => x.YearsOfExperience);
            Console.WriteLine(YOESum);
            Console.WriteLine("Average of Experience");
            var YOEAverage = employees.Average(x => x.YearsOfExperience);
            Console.WriteLine(YOEAverage);
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Experience & Age");
            var exAge = employees.Where(x => x.YearsOfExperience <= 10 && x.Age < 35);
            foreach(var emp in exAge)
            {
                Console.WriteLine(emp.FullName);
            }
            //Add an employee to the end of the list without using employees.Add()
            var newGuy = employees.Append(new Employee("Takko", "Taco", 25, 450)).ToList();
            foreach(var emp in newGuy)
            {
                Console.WriteLine(emp.FullName + " Age:" + emp.Age + " Experience:" + emp.YearsOfExperience);
            }
         


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
