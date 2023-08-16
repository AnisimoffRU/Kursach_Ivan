using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kursach_Ivan
{
    public class Examinator
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

        public override string ToString() => $"{FullName}";
    }
}
