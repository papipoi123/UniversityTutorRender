using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Applications.ViewModels
{
    public class WeeklyTimeViewModel {
        public DayOfWeek DayOfWeek { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime EndTime { get; set; }
    }

    public class GetWeeklyTimeViewModel
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime EndTime { get; set; }
    }
}