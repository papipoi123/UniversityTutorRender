using Domain.Entities;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Applications.ViewModels
{
    public class ReportViewModel
    {
        public string ReportName { get; set; }
        public string ReportContent { get; set; }
        public RequestType RequestType { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int? ResolveBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        [JsonPropertyOrder(2)]
        public int UserId { get; set; }
    }
}
