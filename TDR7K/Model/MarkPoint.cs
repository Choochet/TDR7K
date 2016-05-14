using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDR7K.Model
{
    public class MarkPoint
    {
        public int x { get; set; }
        public int y { get; set; }
        public static List<MarkPoint> SkillMark()
        {
            var skill = new List<MarkPoint>();
            skill.Add(new MarkPoint { x = 1002, y = 556 });
            skill.Add(new MarkPoint { x = 1097, y = 661 });
            skill.Add(new MarkPoint { x = 1099, y = 557 });
            return skill;
        }
        public static List<MarkPoint>MonsterChangeMark()
        {
            var mon = new List<MarkPoint>();
            mon.Add(new MarkPoint { x = 140, y = 228 });
            mon.Add(new MarkPoint { x = 138, y = 394 });
            mon.Add(new MarkPoint { x = 124, y = 555 });
            return mon;
        }
    }
}
