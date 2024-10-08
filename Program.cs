using StudentManagementApp.View;
using System.Reflection;
using System;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using StudentManagementApp.UI;


namespace StudentManagementApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            

            Screen normalScreen = new Screen();



            //normalScreen.MainScreen();

            StudentUI studentUI = new StudentUI();
            

        }

    }
}