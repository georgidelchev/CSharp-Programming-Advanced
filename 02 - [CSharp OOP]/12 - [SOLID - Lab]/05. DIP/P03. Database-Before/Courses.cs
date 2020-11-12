namespace P03._Database
{
    public class Courses
    {
        public void PrintAll()
        {
            var database = new Data();
            var courses = database.CourseNames();

            //print courses
        }

        public void PrintIds()
        {
            var database = new Data();
            var courseIds = database.CourseIds();

            //print course ids
        }

        public void PrintById(int id)
        {
            var database = new Data();
            var course = database.GetCourseById(id);

            // print course
        }

        public void Search(string substring)
        {
            var database = new Data();
            var courses = database.Search(substring);

            // print courses
        }
    }
}
