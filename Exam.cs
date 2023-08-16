using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kursach_Ivan
{
    public class Exam
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        public int ExaminatorId { get; set; }
        public Examinator Examinator { get; set; }

        public override string ToString() => $"({Grade}) {Examinator.FullName}";
    }
}
