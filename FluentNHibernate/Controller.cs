using StudentManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Inspections;
using StudentManagementApp.Model;
using StudentManagementApp.Logics;



namespace StudentManagementApp.FluentNHibernate
{
    public class Controller
    {
        public Controller() {
            using (var session = NHibernateHelper.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var product = new Product()
                    {
                        Id = 10,
                        Name = "Hi",
                        Units = 2,
                        Price = 3,
                    };
                    session.Save(product);
                    transaction.Commit(); // Commit transaction
                }
            }

        }

    }
}
