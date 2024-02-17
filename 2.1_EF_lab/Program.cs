using _2._1_EF_lab;
using Microsoft.Extensions.Configuration;

public class Program
{

    internal static IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

     static void Main(string[] args)
    {
        //Создание базы (если нет) и бобавление данных по курсам в нее
        using (AppConfiguration db = new AppConfiguration())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
            db.Courses.AddRange(
                new Course() { Title = "Programming", Duration = 40, Description = "Study C#" },
                new Course() { Title = "Language", Duration = 20, Description = "Study English" },
                new Course() { Title = "Administration", Duration = 30, Description = "Study administration" }
                );
            db.SaveChanges();
        }

        //вывод списка курсов
        using (AppConfiguration db = new AppConfiguration())
        {
            var courses = db.Courses.ToList();
            Console.WriteLine("Cources list");
            foreach (Course course in courses)
                Console.WriteLine($"{course.Id}.{course.Title} - {course.Description}\nCourse duration {course.Duration}");
        }

        //выод по условию
        using (AppConfiguration db = new AppConfiguration())
        {
            var courses = from course in db.Courses
                          where course.Duration < 40
                          select course;
            Console.WriteLine("Courses with duration < 40");
            foreach (Course course in courses)
                Console.WriteLine($"{course.Id}.{course.Title} - {course.Description}\nCourse duration {course.Duration}");
        }

        //удаление данных в базе
        using (AppConfiguration db = new AppConfiguration())
        {
            Course course = db.Courses.OrderBy(c => c.Duration).FirstOrDefault();
            db.Courses.Remove(course);
            db.SaveChanges();
            Console.WriteLine("Remove first elment:");
            Console.WriteLine($"{course.Id}.{course.Title} - {course.Description}\nCourse duration {course.Duration}");
        }

        //Добавление элемента
        using (AppConfiguration db = new AppConfiguration())
        {

            db.Courses.Add(
            new Course() { Title = "Professional programming", Duration = 40, Description = "Study Client-Service application" }
            );
            db.SaveChanges();
            var courses = db.Courses.ToList();
            Console.WriteLine("Added new cource:");
            foreach (Course course in courses)
                Console.WriteLine($"{course.Id}.{course.Title} - {course.Description}\nCourse duration {course.Duration}");
        }
    }
}

