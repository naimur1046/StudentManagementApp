using FluentNHibernate.Mapping;
using StudentManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using StudentManagementApp.Model;

namespace StudentManagementApp.Mapping
{
    public class StudentDetails : ClassMap<Student>
    {
        public  StudentDetails()
        {
            Table("StudentDetails");
            Id(u => u.rollNumber).GeneratedBy.Assigned();
            Map(u => u.firstName);
            Map(u => u.lastName);
            Map(u => u.department);
            Map(u => u.mobileNumber);


        }
    }
}
