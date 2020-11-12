namespace P03._Database_After
{
    using Contracts;
    public class CoursesParameter
    {
        public void PrintAll(ICourseData data)
        {
            var courses = data.CourseNames();

            //print courses
        }

        public void PrintIds(ICourseData data)
        {
            var courseIds = data.CourseIds();

            //print course ids
        }

        public void PrintById(ICourseData data,int id)
        {
            var course = data.GetCourseById(id);

            // print course
        }

        public void Search(ICourseData data,string substring)
        {
            var courses = data.Search(substring);

            // print courses
        }
    }
}
