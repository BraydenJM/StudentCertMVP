using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentCertMVP
{
    public class classRegex
    {
        public string StudentID = null;
        /// <summary>
        /// iterates through all of the lists from the other methods, creating course objects from each
        /// </summary>
        /// <param name="classString">the string of classes from the main program</param>
        /// <returns></returns>
        public List<Course> createStudent(string classString)
        {
            List<Course> studentClasses = new List<Course>();
            List<Course> studentClassesExit = new List<Course>();
            //each one of these calls the other code from this file
            List<String> classCode = createClassCode(classString);
            //classString = removeFromString(classCode, classString);
            String quarterCode = createQuarterCode(classString);
            //classString = removeFromString(quarterCode, classString);
            List<double> creditCode = createCreditCode(classString);
            //classString = removeFromStringDouble(creditCode, classString);
            int j = 0;
            int lengthToLoop = classCode.Count;
            for (int i = 0; i < lengthToLoop; i++)
            {
                if (OverrideQuarter.OverrideValue != null)
                {
                        Course overrideCourse = new Course(String.Empty, classCode[j], creditCode[j], OverrideQuarter.OverrideValue);
                        studentClasses.Add(overrideCourse);
                        studentClassesExit.Add(overrideCourse);
                }
                else
                {
                    Course newCourse = new Course(String.Empty, classCode[j], creditCode[j], quarterCode);
                    studentClasses.Add(newCourse);
                    studentClassesExit.Add(newCourse);
                }
                j++;
            }
            foreach (Course c in studentClasses)
            {
                if (c.credit == -1)
                {
                    studentClassesExit.Remove(c);
                }
            }
            return studentClassesExit;
            
        }
        /// <summary>
        /// runs regex on classString to spereate class codes and return them in a list
        /// </summary>
        /// <param name="classString">classString from createStudent</param>
        /// <returns></returns>
        private List<String> createClassCode(string classString)
        {
            string atPattern = @"[A-Za-z]{3,5}";
            Regex atPatternRegex = new Regex(atPattern);
            string atPattern2 = @"[0-9]{3}";
            Regex atPattern2Regex = new Regex(atPattern2);
            string classPattern = @"\b[A-Za-z]{3,5}[&]{0,1}[ ]{0,1}[\n\r]{0,1}[0-9]{3}\b";
            Regex classCodeRegex = new Regex(classPattern);
            var classCode = classCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            for (int i = 0; i < classCode.Count; i++)
            {
                classCode[i] = classCode[i].Replace("\n", "");
                if (!classCode[i].Contains("&"))
                {
                    string part1 = atPatternRegex.Match(classCode[i]).ToString();
                    string part2 = atPattern2Regex.Match(classCode[i]).ToString();
                    classCode[i] = part1 + " " + part2;
                }
            }

            return classCode;
        }
        //removeFromString and removeFromStringDouble are no longer necessary
        /*private string removeFromString(List<string> classCode, string classString)
        {
            foreach (string classCodeItem in classCode)
            {
                classString = classString.Replace(classCodeItem, String.Empty, true, null);
            }
            return classString;
        }
        private string removeFromStringDouble(List<double> classCode, string classString)
        {
            foreach (double classCodeItem in classCode)
            {
                classString = classString.Replace(classCodeItem.ToString("N1"), String.Empty, true, null);
            }
            return classString;
        }*/

        /// <summary>
        /// runs regex on classString to spereate credit amounts and return them in a list
        /// </summary>
        /// <param name="classString">classString from createStudent</param>
        /// <returns></returns>
        private List<double> createCreditCode(string classString)
        {
            int creditLocation = 0;
            string creditPattern = @"\b\d*\.\d+\b|\bNon-Graded\b";
            Regex creditCodeRegex = new Regex(creditPattern, RegexOptions.Multiline);
            var creditCode = creditCodeRegex.Matches(classString)
                .Cast<Match>()
                //.Select(m => double.Parse(m.Value))
                .Select(m => m.Value)
                .ToList();
            /*if (creditCode.Contains("Non-Graded"))
            {
                creditCode[creditCode.IndexOf("Non-Graded")] = "-1";
            }*/
            for (int i = 0; i < creditCode.Count; i++)
            {
                if (creditCode[i] == "Non-Graded");
                creditCode[i] = creditCode[i].Replace("Non-Graded", "-1");
            }
            /*int index = creditCode.FindIndex(s => s == "Non-Graded");

            if (index != -1)
                creditCode[index] = "-1";*/
            /*foreach (var credit in creditCode)
                //(creditCode.Contains("Non-Graded"))
            {
                creditLocation++;
                if (credit == "Non-Graded")
                {
                    creditCode.Insert(creditLocation, "-1");
                }
            }*/
            List<double> exitList = creditCode.Select(double.Parse).ToList();
            return exitList;
        }
        /// <summary>
        /// runs regex on classString to spereate quarter codes and return them in a list
        /// </summary>
        /// <param name="classString">classString from createStudent</param>
        /// <returns></returns>
        private String createQuarterCode(string classString)
        {
            string year = null;
                string quarterPattern = @"(?i)\b[0-9]{4}[ ]{0,1}SPRING|[0-9]{4}[ ]{0,1}WINTER|[0-9]{4}[ ]{0,1}FALL|[0-9]{4}[ ]{0,1}SUMMER\b";
                Regex quarterCodeRegex = new Regex(quarterPattern);
            string quarterCode = quarterCodeRegex.Match(classString).Value;
            string quarterPattern2 = @"[0-9]{4}";
            Regex quarterCode2Regex = new Regex(quarterPattern2);
            //string quarterPattern3 = @"(?i)SPRING|WINTER|FALL|SUMMER";
            if (quarterCode.Contains("FALL"))
            {
                year = quarterCode2Regex.Match(quarterCode).ToString();
                string yearNumber = year.Remove(0, 2);
                year = "FA" + yearNumber;
            }
            else if (quarterCode.Contains("WINTER"))
            {
                year = quarterCode2Regex.Match(quarterCode).ToString();
                string yearNumber = year.Remove(0, 2);
                year = "W" + yearNumber;
            }
            else if (quarterCode.Contains("SUMMER"))
            {
                year = quarterCode2Regex.Match(quarterCode).ToString();
                string yearNumber = year.Remove(0, 2);
                year = "SU" + yearNumber;
            }
            else if (quarterCode.Contains("SPRING"))
            {
                year = quarterCode2Regex.Match(quarterCode).ToString();
                string yearNumber = year.Remove(0, 2);
                year = "SP" + yearNumber;
            }
                /*var quarterCode = quarterCodeRegex.Matches(classString)
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToList();*/
                return year;
        }
        /// <summary>
        /// this program grabs the student id and checks if it is valid via regex, and then if it is, it returns the id, and if not, it returns an error
        /// </summary>
        /// <param name="studentID">student ID number from main program</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string studentIDValid(string studentID)
        {
            string iDPattern = @"\b[0-9]{9}\b";
            Regex iDRegex = new Regex(iDPattern);
            if (iDRegex.Match(studentID).Value != String.Empty)
            {
                studentID = iDRegex.Match(studentID).Value;
                if (studentID == string.Empty)
                {
                    studentID = null;
                }
                this.StudentID = studentID;
                return studentID;
            }
            else
            {
                throw new Exception("ERROR: Student ID format invalid, please try again.");
            }
        }
    }
}
