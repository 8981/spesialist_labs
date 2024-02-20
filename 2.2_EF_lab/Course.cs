using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_EF_lab
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }

        public  List<Teacher> Teachers { get; set; } = new();
        public  List<Student> Students { get; set; } = new();
    }
}
