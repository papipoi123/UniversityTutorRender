using Domain.Base;

namespace Domain.Entities
{
    public class TutorFeedback : BaseEntity
    {
        public string FeedbackContent { get; set; }
        public int RatingStar { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
    }
}
