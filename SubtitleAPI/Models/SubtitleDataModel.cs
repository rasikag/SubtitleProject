using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleAPI.Models
{
    public class SubtitleDataModel
    {
        public List<string> SubDataList { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }
}
