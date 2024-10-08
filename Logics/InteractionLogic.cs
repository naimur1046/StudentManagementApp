using StudentManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentManagementApp.Model;

namespace StudentManagementApp.Logics
{

    internal class InteractionLogic
    {
        private int option;
        private int rollNumber;
        private string firstName;
        private string lastName;
        private string department;
        private string mobileNumber;
        string connectionString;


        public InteractionLogic(int option, int rollNumber, string firstName, string lastName, string department, string mobileNumber)
        {
            this.option = option;
            this.rollNumber = rollNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
            this.mobileNumber = mobileNumber;

            


        }
        public void InteractionWithDatabase()
        {
            connectionString = "Data Source=NAIMURRAHMAN;Initial Catalog=STUDENT;TrustServerCertificate=True; Trusted_Connection=True;";
            var configarationForDatabaseConnection = new Configuration();
            configarationForDatabaseConnection.DataBaseIntegration(d =>
            {
                d.ConnectionString = connectionString;
                d.Dialect<MsSql2012Dialect>();
                d.Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>();

            });

            configarationForDatabaseConnection.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = configarationForDatabaseConnection.BuildSessionFactory();



            if (option == 1)
            {
                PushTheValueToDatabase(sessionFactory);
            }
            else if (option == 2)
            {
                FetchDataFromDatabase(sessionFactory);
            }

        }

        public void PushTheValueToDatabase(NHibernate.ISessionFactory sessionFactory)
        {


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
                catch (Exception ex)
                {

                }
            }

        }

        public void FetchDataFromDatabase(NHibernate.ISessionFactory sessionFactory)
        {
            using (var session = sessionFactory.OpenSession())
            {
                try
                {
                    
                    var students = session.Query<Student>().ToList();

                    
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
