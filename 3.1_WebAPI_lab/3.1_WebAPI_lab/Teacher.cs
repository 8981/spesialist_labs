using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1_WebAPI_lab
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  List<Course> Courses { get; set; } = new();
    }
}
