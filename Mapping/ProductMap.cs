using FluentNHibernate.Mapping;
using StudentManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp.Model;
using FluentNHibernate.Mapping;

namespace StudentManagementApp.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(u => u.Id).GeneratedBy.Assigned();
            Map(u => u.Name);
            Map(u => u.Units);
            Map(u => u.Price);


        }
    }
}
