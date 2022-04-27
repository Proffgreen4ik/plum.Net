using plumcourse.Data.Models;

namespace plumcourse.Data.Interfaces
{
    public interface ICourses
    {
        IEnumerable<Course> AllCourseses { get; }
        Course getObjectCourse(int courseId);
    }
}
