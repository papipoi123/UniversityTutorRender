using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.ViewModels
{
    public class UnitViewModel
    {
        public string UnitName { get; set; }
        public int MinuteTime { get; set; }
        public string Content { get; set; }
        public string HomeWorkFile { get; set; }
        public string TeachingMaterialFile { get; set; }
    }
    public class GetUnitViewModel : UnitViewModel
    {
        public int Id { get; set; }
    }
}
