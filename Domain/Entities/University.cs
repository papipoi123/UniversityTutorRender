using Domain.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class University : BaseEntity
    {
        public string UniversityName { get; set; }
        public UniversityArea UniversityArea { get; set; }
        public List<TeachingCourse>? TeachingCourses { get; set; }
        
    }
}
