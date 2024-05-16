using Domain.Entities;

namespace Applications.ViewModels
{
    public class CertificationViewModel
    {
        public string CertificationName { get; set; }
        public string CertificationLink { get; set; }
        public bool IsAuthorize { get; set; }
        public int AuthorizeBy { get; set; }
        public int TutorId { get; set; }
    }

    public class GetCertificationViewModel
    {
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string CertificationLink { get; set; }
        public bool IsAuthorize { get; set; }
        public int AuthorizeBy { get; set; }
        public int TutorId { get; set; }
    }
}
