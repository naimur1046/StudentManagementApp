﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentManagementApp.Model;


namespace StudentManagementApp.View
{
    
    public class Screen
    {
        private int rollNumber;
        private string firstName;
        private string lastName;
        private string department;
        private string mobileNumber;
        public void MainScreen()
        {
            Console.WriteLine("Enter options 1 or 2: ");
            Console.WriteLine("1. Entry data");
            Console.WriteLine("2. Show data");
            string inputValue= Console.ReadLine();
            int inuputNumber=int.Parse(inputValue);
            Console.WriteLine($"Inputed value is {inuputNumber}");
            if (inuputNumber == 1)
            {
                EntryData();
            }
            else
            {
               
            }


        }

        public void EntryData()
        {
            Console.WriteLine("Enter RollNumber");
            String inputValue= Console.ReadLine();
            rollNumber=int.Parse(inputValue);
            Console.WriteLine("Enter First Name");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Department");
            department = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile Number");
            mobileNumber = Console.ReadLine();

            Console.WriteLine("Your Inputed value is "+rollNumber+" "+ firstName+" "+ lastName+" "+department+" "+mobileNumber);

            PushTheValueToDatabase();
            

        }

        public void ShowData()
        {
            Console.WriteLine("Here are the students Details");
        }

        public void PushTheValueToDatabase()
        {
            string connStr = "Data Source=NAIMURRAHMAN;Initial Catalog=STUDENT;TrustServerCertificate=True; Trusted_Connection=True;";

            var config = new Configuration();
            config.DataBaseIntegration(d =>
            {
                d.ConnectionString = connStr;
                d.Dialect<MsSql2012Dialect>();
                d.Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>();

            });


            config.AddAssembly(Assembly.GetExecutingAssembly());


            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
               try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var student = new Student()
                            {
                                rollNumber = this.rollNumber,
                                firstName = this.firstName,
                                lastName = this.lastName,
                                department = this.department,
                                mobileNumber = this.mobileNumber,
                            };


                            session.Save(student);
                            transaction.Commit();
                            Console.WriteLine("Product saved successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                catch(Exception ex) 
                {

                }
            }

        }
    }
}
