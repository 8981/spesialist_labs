using Grpc.Net.Client;
using GrpcServiceClient;

using var channel = GrpcChannel.ForAddress("http://localhost:5035");

var client = new CoursesService.CoursesServiceClient(channel);

var replayCourses = await client.ListCoursesAsync(new Google.Protobuf.WellKnownTypes.Empty());

foreach(var course in replayCourses.Courses)
    Console.WriteLine($"Course - {course.Id}.{course.Title} with duration {course.Duration} - {course.Description}\n");
