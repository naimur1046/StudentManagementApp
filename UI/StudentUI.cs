using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentManagementApp.Model;
using StudentManagementApp.Logics;

namespace StudentManagementApp.UI
{
    
    public class StudentUI
    {
        private int option=3;
        private int rollNumber;
        private string firstName;
        private string lastName;
        private string department;
        private string mobileNumber;

        public StudentUI() { 
         option = 0;
        rollNumber =0;
         firstName = "";
         lastName = "";
        department = "";
         mobileNumber = "";

        if (option != 3) 
         ShowScreen();
        }

        void ShowScreen()
        {
            Console.WriteLine("Enter options 1 or 2: ");
            Console.WriteLine("1. Entry data");
            Console.WriteLine("2. Show data");
            string inputValue = Console.ReadLine();
            option= int.Parse(inputValue);
            if (option == 1)
            {
                rollNumber = int.Parse(inputValue);
                Console.WriteLine("Enter First Name");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                lastName = Console.ReadLine();
                Console.WriteLine("Enter Your Department");
                department = Console.ReadLine();
                Console.WriteLine("Enter Your Mobile Number");
                mobileNumber = Console.ReadLine();
                Console.WriteLine("Your Inputed value is " + rollNumber + " " + firstName + " " + lastName + " " + department + " " + mobileNumber);
            }
            
            ImplementTheLogic();
        }

        public static void showTheSearchResult(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("Roll Number: " + student.rollNumber);
                Console.WriteLine("First Name: " + student.firstName);
                Console.WriteLine("Last Name: " + student.lastName);
                Console.WriteLine("Department: " + student.department);
                Console.WriteLine("Mobile Number: " + student.mobileNumber);
                Console.WriteLine("-----------------------------------");
            }
        }

        void ImplementTheLogic()
        {
            var classImplement = new InteractionLogic(option, rollNumber,firstName,lastName,department,mobileNumber);
           
        }




    }
}
