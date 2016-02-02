using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleAPI.Models
{
    public class PostSubtitle
    {
        public int Strat { get; set; }
        public int End { get; set; }
        public List<SubDataAtribute> SubData { get; set; }

    }

    public class SubDataAtribute
    {
        public string Data { get; set; }
        public string Name { get; set; }
    }
}
