using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{   
    [Table("tblDepartment")]
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}