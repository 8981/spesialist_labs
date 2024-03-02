using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_ReflectionLib_lab
{
    //[Table("Teacher")]
    public class Teacher
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public List<Course> Courses { get; set; } = new();
    }
}
