using _3._1_WebAPIClient_lab;


HttpClient httpClient = new HttpClient();
MyClient client = new MyClient("http://localhost:5251", httpClient);
var courses = await client.CoursesAllAsync();
foreach (var course in courses)
    Console.WriteLine($"{course.Title} - {course.Duration}\n{course.Description}\n");

var teachers = await client.FindByName2Async("S");
foreach (var teacher in teachers)
    Console.WriteLine($"{teacher.Name}\n");

var students = await client.FindByNameAsync("A");
foreach (var student in students)
    Console.WriteLine($"{student.Name}\n");