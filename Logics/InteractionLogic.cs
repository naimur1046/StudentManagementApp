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
using NHibernate;
using static System.Collections.Specialized.BitVector32;
using System.Transactions;
using StudentManagementApp.UI;

namespace StudentManagementApp.Logics
{

    public class InteractionLogic
    {
        private int option;
        private int rollNumber;
        private string firstName;
        private string lastName;
        private string department;
        private string mobileNumber;
        string connectionString;
        private static ISessionFactory _sessionFactory;



        public InteractionLogic(int option, int rollNumber, string firstName, string lastName, string department, string mobileNumber)
        {
            this.option = option;
            this.rollNumber = rollNumber;
            this.firstName = firstName;
            this.lastName = lastName;
            this.department = department;
            this.mobileNumber = mobileNumber;


            InteractionWithDatabase();




        }

        public void InteractionWithDatabase()
        {
            using (var session = NHibernateHelper.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    

                    if (option == 1)
                    {
                        PushTheValueToDatabase(session, transaction);
                    }
                    else if (option == 2)
                    {
                        FetchDataFromDatabase(session, transaction);
                    }
                   
                }
            }



           

        }

        public void PushTheValueToDatabase(ISession session, ITransaction transaction)
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

        public void FetchDataFromDatabase(ISession session, ITransaction transaction)

              
        {
            var students = session.Query<Student>().ToList();
            StudentUI.showTheSearchResult(students);
}
    }
}
