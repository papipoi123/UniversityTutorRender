namespace Applications.ViewModels
{
    public class TutorFeedbackViewModel
    {
        public string FeedbackContent { get; set; } = default!;
        public int RatingStar { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
    }

    public class GetTutorFeedbackViewModel
    {
        public int Id { get; set; }
        public string FeedbackContent { get; set; } = default!;
        public int RatingStar { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
    }
}
