using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursach_Ivan
{
    public class Matriculant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int SchoolNumber { get; set; }
        public string? ImageUri { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
