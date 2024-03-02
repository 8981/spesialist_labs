using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_ReflectionLib_lab
{
    //[Table("Course")]
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public string? Description{ get; set; }

        public List<Teacher> Teachers { get; set; } = new();
        public List<Student> Students { get; set; } = new();
    }
}
