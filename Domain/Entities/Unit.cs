using Domain.Base;

namespace Domain.Entities
{
    public class Unit : BaseEntity
    {
        public string UnitName { get; set; }
        public int MinuteTime { get; set; }
        public string Content { get; set; }
        public string HomeWorkFile { get; set; }
        public string TeachingMaterialFile { get; set; }
        public int TeachingCourseId { get; set; }
        public TeachingCourse? TeachingCourse { get; set; }
    }
}
