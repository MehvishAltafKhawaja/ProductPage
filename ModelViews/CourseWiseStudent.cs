using WebApp.Models;

namespace WebApp.ModelViews
{
    public class CourseWiseStudent
    {
        public Course crsDetails { get; set; }
        public List<Student> studDetails { get; set; }
    }
}
