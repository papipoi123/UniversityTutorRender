using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Report : BaseEntity
    {
        public string ReportName { get; set; }
        public string ReportContent { get; set; }
        public RequestType RequestType { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int? ResolveBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
