namespace Applications.ViewModels
{
    public class CourseMajorViewModel
    {
        public string CourseMajorName { get; set; }
    }
    public class GetCourseMajorViewModel :CourseMajorViewModel
    {
        public int Id{ get; set; }
    }
}