using _2._2_EF_lab;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public class Program
{

    internal static IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

     static void Main(string[] args)
    {
        using (AppConfiguration db = new AppConfiguration())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var courses = db.Courses.ToList();
            db.Teachers.Find(1).Courses.AddRange(courses);
            db.Teachers.Find(2).Courses.AddRange(courses.GetRange(0, 2));
            db.Teachers.Find(3).Courses.AddRange(courses.GetRange(0, 1));

            for (int i = 1; i <= 3; i++)
                db.Students.Find(i).Courses.AddRange(courses.GetRange(0, i));

            db.SaveChanges();
        }

        using (AppConfiguration db = new AppConfiguration())
        {
            var r = from t in db.Teachers
                    orderby t.Name
                    select new { Teacher = t, Courses = t.Courses };

            foreach (var t in r.ToList())
            {
                Console.WriteLine(t.Teacher.Name);
                foreach (var c in t.Courses)
                {
                    Console.WriteLine($"\t{c.Title}");
                    var r2 = from s in db.Students
                             where s.Courses.Contains(c)
                             orderby s.Name
                             select s;
                    foreach (var s in r2)
                        Console.WriteLine($"\t\t{s.Name}");
                }
            }
        }

    }
}

