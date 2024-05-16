namespace Applications.ViewModels
{
    public class RatingViewModel
    {
        public int RatingStar { get; set; }
        public string Feedback { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int TeachingCourseId { get; set; }
        public int StudentId { get; set; }
    }

    public class GetRatingViewModel
    {
        public int Id { get; set; }
        public int RatingStar { get; set; }
        public string Feedback { get; set; }
        public DateTime CreationDate { get; set; }
        public int TeachingCourseId { get; set; }
        public int StudentId { get; set; }
    }
}
