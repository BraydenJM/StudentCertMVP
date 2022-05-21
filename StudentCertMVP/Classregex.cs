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
        public string StudentID = null;
        /// <summary>
        /// iterates through all of the lists from the other methods, creating course objects from each
        /// </summary>
        /// <param name="classString">the string of classes from the main program</param>
        /// <returns></returns>
        public List<Course> createStudent(string classString)
        {
            List<Course> studentClasses = new List<Course>();
            //each one of these calls the other code from this file
            List<String> classCode = createClassCode(classString);
            //classString = removeFromString(classCode, classString);
            List<String> quarterCode = createQuarterCode(classString);
            //classString = removeFromString(quarterCode, classString);
            List<double> creditCode = createCreditCode(classString);
            //classString = removeFromStringDouble(creditCode, classString);
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
        /// <summary>
        /// runs regex on classString to spereate class codes and return them in a list
        /// </summary>
        /// <param name="classString">classString from createStudent</param>
        /// <returns></returns>
        private List<String> createClassCode(string classString)
        {
            string classPattern = @"\b[A-Za-z]{3,5}[&]{0,1}[ ]{0,1}[0-9]{3}\b";
            Regex classCodeRegex = new Regex(classPattern);
            var classCode = classCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
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
            string creditPattern = @"\b\d*\.\d+\b";
            Regex creditCodeRegex = new Regex(creditPattern);
            var creditCode = creditCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => double.Parse(m.Value))
                .ToList();
            return creditCode;
        }
        /// <summary>
        /// runs regex on classString to spereate quarter codes and return them in a list
        /// </summary>
        /// <param name="classString">classString from createStudent</param>
        /// <returns></returns>
        private List<String> createQuarterCode(string classString)
        {
            string quarterPattern = @"(?i)\bSP[0-9]{4}|WI[0-9]{4}|FA[0-9]{4}|SU[0-9]{4}\b";
            Regex quarterCodeRegex = new Regex(quarterPattern);
            var quarterCode = quarterCodeRegex.Matches(classString)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
            return quarterCode;
        }
        /// <summary>
        /// this program grabs the student id and checks if it is valid via regex, and then if it is, it returns the id, and if not, it returns an error
        /// </summary>
        /// <param name="studentID">student ID number from main program</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string studentIDValid(string studentID)
        {
            string iDPattern = @"\b[0-9]{8}\b";
            Regex iDRegex = new Regex(iDPattern);
            if (iDRegex.Match(studentID).Value != String.Empty)
            {
                studentID = iDRegex.Match(studentID).Value;
                if (studentID == string.Empty)
                {
                    studentID = null;
                }
                return studentID;
            }
            else
            {
                throw new Exception("ERROR: Student ID format invalid, please try again.");
            }
        }
    }
}
