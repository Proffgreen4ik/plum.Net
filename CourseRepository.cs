using plumcourse.Data.Interfaces;
using plumcourse.Data.Models;

namespace plumcourse.Data.Repository
{
    public class CourseRepository : ICourses
    {
        private readonly AppDBContent appDBContent;
        public CourseRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Course> AllCourseses => appDBContent.Course;
        public Course getObjectCourse(int courseId) => appDBContent.Course.FirstOrDefault(p => p.id == courseId);
    }
}
