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

            var sum = numbers.Sum();
            Console.WriteLine("Sum");
            Console.WriteLine(sum);
            Console.WriteLine("-----------------");
            var avg = numbers.Average();
            Console.WriteLine("Average");
            Console.WriteLine(avg);

            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("-----------------");
            Console.WriteLine("Ascending");
            foreach (var item in asc)
            {
                Console.WriteLine(item);
            }
            

            var decen = numbers.OrderByDescending(num => num);
            Console.WriteLine("-----------------");
            Console.WriteLine("Decending");
            foreach (var down in decen)
            {
                Console.WriteLine(down);
            }
            


            //Print to the console only the numbers greater than 6

            var gr6 = numbers.Where(x => x > 6);
            Console.WriteLine("-----------------");
            Console.WriteLine("Values greater than 6");
            foreach(var big in gr6)
            {
                Console.WriteLine(big);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var order = numbers.OrderBy(x => x).Take(4);
            Console.WriteLine("-----------------");
            Console.WriteLine("Take 4");
            foreach(var ord in order)
            {
                Console.WriteLine(ord);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 25;
            var age = numbers.OrderByDescending(years => years);
            Console.WriteLine("-----------------");
            Console.WriteLine("Descending from my age");
            foreach(var dob in age)
            {
                Console.WriteLine(dob);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filtered =
                employees.Where(name => name.FirstName.StartsWith('S') || name.FirstName.StartsWith('C')).OrderBy(name => name.FirstName);
            Console.WriteLine("-----------------");
            Console.WriteLine("Empoyees 'S' & 'C'");
            foreach(var emp in filtered)
            {
                Console.WriteLine(emp.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var twentysix =
                employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            Console.WriteLine("-----------------");
            Console.WriteLine("Employees older than 26");
            foreach(var emp in twentysix)
            {
                Console.WriteLine($"Age: {emp.Age}, Firstname; {emp.FirstName}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var experience = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumYOE = experience.Sum(emp => emp.YearsOfExperience);
            var avgYOE = experience.Average(emp => emp.YearsOfExperience);

            Console.WriteLine("-----------------");
            Console.WriteLine($"Sum of years experience: {sumYOE}, average years experience {avgYOE}");


            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee( "Whit", "Stroup", 25, 12)).ToList();

            Console.WriteLine("-----------------");
            Console.WriteLine("Added Whit Stroup");
            foreach(var item in employees)
            {
                Console.WriteLine(item.FullName);
            }

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
