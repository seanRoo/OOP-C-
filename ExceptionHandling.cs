/*
**Demonstration of Exception Handling through C#**

-Write a Program to handle FormatException.  
If a user enters values other than integer while entering the marks of each subject, catch FormatException. 
The name of the students and marks in 3 subjects are taken from the user while executing the program. 

-Grades cannot be a negative number and name value cannot be null or contain anything other than letters

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HandsOn3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> grades = new List<int>();
            int thisGrade;
            Console.WriteLine("Enter the name of the student: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student grades separated by a space: ");
            String[] gradesStr = Console.ReadLine().Split(' ');
            var obj = new StudentGrades();

            foreach (var ch in gradesStr)
            {

                try
                {

                    thisGrade = int.Parse(ch.ToString());
                    grades.Add(thisGrade);

                }
                catch (FormatException e)
                {

                    Console.WriteLine("ERROR with input " + ch + "\n" + e);
                }
                catch (NegativeGradeException e)
                {

                    Console.WriteLine(e);

                }

            }

            try
            {

                obj.PrintList(grades, name);

            }
            catch (InvalidNameInputException e)
            {

                Console.WriteLine(e);

            }

            Console.ReadKey();

        }
    }
    class StudentGrades{

        public void PrintList(List<int> gradeList_, string name_)
        {
            StringBuilder sb = new StringBuilder();
            if(name_ != null && Regex.IsMatch(name_, @"^([a-zA-Z]\s?){1,}$"))
            {
                Console.WriteLine("Grades for " + name_.First().ToString().ToUpper() + name_.Substring(1) + ":");

                foreach (var i in gradeList_)
                {
                    if (i > 0)
                    {
  
                        sb.Append(i + " ");

                    }
                    else
                    {

                       Console.WriteLine(new NegativeGradeException(i));

                    }
                }
            }

            else
            {

                throw new InvalidNameInputException(name_);
            }


            Console.WriteLine(sb.ToString());

        }
    }

    class NegativeGradeException : Exception
    {
        public NegativeGradeException()
        {

        }
        public NegativeGradeException(int num)
        
            :base(String.Format("Negative value {0}! Grade cannot be a negative number!", num))
        {
            
        }
    }

    class InvalidNameInputException : Exception
    {
        public InvalidNameInputException()
        {

        }
        public InvalidNameInputException(string name)

            : base(String.Format("Name value {0} is null or contains illegal characters!", name))
        {

        }
    }

}


