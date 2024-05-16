using Domain.Base;

namespace Domain.Entities
{
    public class Certification : BaseEntity
    {
        public string CertificationName { get; set; }
        public string CertificationLink { get; set;}
        public bool IsAuthorize { get; set; }
        public int AuthorizeBy { get; set; }
        public int TutorId { get; set; }
        public Tutor? Tutor { get; set; }
    }
}
