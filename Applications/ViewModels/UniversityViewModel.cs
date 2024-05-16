using Domain.Entities;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Applications.ViewModels
{
    public class UniversityViewModel
    {
        public string UniversityName { get; set; } = default!;
        public UniversityArea UniversityArea { get; set; }
    }

    public class GetUniversityViewModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; } = default!;
        public UniversityArea UniversityArea { get; set; }
    }
}