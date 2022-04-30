using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertMVP
{
    public class Course
    {
        public string className { get; }
        public string classCode { get; }
        public int credit { get; }
        public string quarter { get; }

        public Course(string className, string classCode, int credit, string quarter)
        {
            this.className = className;
            this.classCode = classCode;
            this.credit = credit;
            this.quarter = quarter;
        }
    }
}
