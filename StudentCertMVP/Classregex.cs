using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentCertMVP
{
    internal class classRegex
    {
        private List<Course> createStudent(string classString)
        {
            List<Course> studentClasses = new List<Course>();
            List<String> classCode = createClassCode(classString);
            List<int> creditCode = createCreditCode(classString);
            List<String> quarterCode = createQuarterCode(classString);
            int j = 0;
            int lengthToLoop = classCode.Count;
            for (int i = 0; i < lengthToLoop; i++)
            {
                Course newCourse = new Course(String.Empty, classCode[j], creditCode[j], quarterCode[j]);
                studentClasses.Add(newCourse);
                j++;
            }
            return studentClasses;
            
        }
        private List<String> createClassCode(string classString)
        {
            string classPattern = "\b[A-Za-z]{3,4}[&]{0,1}{ }{0,1}[0-9]{3}\b";
            Regex classCodeRegex = new Regex(classPattern);
            var classCode = classCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            return classCode;
        }
        private List<int> createCreditCode(string classString)
        {
            string creditPattern = "\b[A-Za-z]{3,4}[&]{0,1}[0-9]{3}\b";
            Regex creditCodeRegex = new Regex(creditPattern);
            var creditCode = creditCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => int.Parse(m.Value))
                .ToList();
            return creditCode;
        }
        private List<String> createQuarterCode(string classString)
        {
            string quarterPattern = "\bSP[0-9]{4}|WI[0-9]{4}|FA[0-9]{4}|SU[0-9]{4}\b";
            Regex quarterCodeRegex = new Regex(quarterPattern);
            var quarterCode = quarterCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            return quarterCode;
        }
    }
}
