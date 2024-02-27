using _3._2_GrpcService;


namespace _3._2_GrpcService.Services
{
    using Google.Protobuf.WellKnownTypes;
    using Grpc.Core;
    using GrpcService;
    using Microsoft.EntityFrameworkCore.Storage;

    public class CourseApiService : CoursesService.CoursesServiceBase
    {
        private readonly ILogger<CourseApiService> _logger;
        private readonly ApplicationContext _context;
        public CourseApiService(ILogger<CourseApiService> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<ListReply> ListCourses(Empty request, ServerCallContext context)
        {
            var listReply = new ListReply();
            var courseList = _context.Courses.Select(
                c => new CourseReply
                {
                    Id = c.Id,
                    Title = c.Title,
                    Duration = c.Duration,
                    Description = c.Description
                }).ToList();
            listReply.Courses.AddRange(courseList);
            return Task.FromResult(listReply);
        }

        public override Task<CourseReply> GetCourse(GetCourseRequest request, ServerCallContext context)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == request.Id);
            if (course == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));
            CourseReply reply = new CourseReply()
            {
                Id= course.Id,
                Title = course.Title,
                Duration = course.Duration,
                Description = course.Description
            };
            return Task.FromResult(reply);
        }

        public override Task<CourseReply> CreateCourse(CreateCourseRequest request, ServerCallContext context)
        {
            var course = new Course()
            {
                Title = request.Title,
                Duration = request.Duration,
                Description = request.Description
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            var replay = new CourseReply()
            {
                Id = course.Id,
                Title = course.Title,
                Duration = course.Duration,
                Description = course.Description
            };
            return Task.FromResult(replay);
        }

        public override Task<CourseReply> UpdateCourse(UpdateCourseRequest request, ServerCallContext context)
        {
            var course = _context.Courses.SingleOrDefault(uc => uc.Id == request.Id);
            if (course == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));

            course.Title = request.Title;
            course.Duration = request.Duration;
            course.Description = request.Description;
            _context.SaveChanges();

            var reply = new CourseReply()
            {
                Id = course.Id,
                Title = course.Title,
                Duration = course.Duration
            };
            return Task.FromResult(reply);
        }

        public override Task<CourseReply> DeleteCourse(DeleteCourseRequest request, ServerCallContext context)
        {
            var course = _context.Courses.SingleOrDefault(dc => dc.Id == request.Id);

            if (course == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));
            _context.Courses.Remove(course);
            _context.SaveChanges();
            var replay = new CourseReply()
            {
                Id = course.Id,
                Title = course.Title,
                Duration = course.Duration,
                Description = course.Description
            };
            return Task.FromResult(replay);
        }
    }
}
