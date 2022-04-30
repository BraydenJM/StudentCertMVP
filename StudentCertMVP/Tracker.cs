using System;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace StudentCertMVP
{
    public class Tracker
    {
        private List<Course> classList { get; set; }
        public Tracker(List<Course> classList)
        {
            this.classList = classList;
        }
        public Tracker()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">directory file is located in</param>
        /// <param name="fileName">file name of file to build list from</param>
        /// <returns>Returns 2D list generated from CSV</returns>
        public string matchClasses(List<string> forms)
        {
            if(classList.Count == 0)
            {
                throw new Exception("ERROR: no classes contained in the classList parameter");
            }
            string result = string.Empty;
            foreach (string form in forms)
            {
                string[] fileExtension = form.Split('.');

                if (fileExtension[1].Equals("xls", StringComparison.OrdinalIgnoreCase))
                {
                    FileStream fileStream = new FileStream(form, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

                    //result = generateFromExcel(workbook);
                }
                else if (fileExtension[1].Equals("xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    result = matchClassesXSSF(form);
                }

                else
                {
                    throw new Exception($"ERROR: file extension for {form} is either missing or is and invalid extension.\n" +
                        $"valid extensions include: xls, xlsx and csv");
                }
            }

            return result;
        }
        /// <summary>
        /// iterates through provided XLSX formatted excel file. Checks each row for matching course code value and writes to adjacent cells
        /// </summary>
        /// <param name="excelBook">excel file to parse</param>
        /// <returns>string stating which classes had been entered to the excel file</returns>
        private string matchClassesXSSF(string formPath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); //XLSF files use a different encoding method
            FileStream fileStream = new FileStream(formPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //Column locations:
            //col 0 = full class name
            //col 1 = course code
            //col 2 = credit amount
            //col 3 = quarter taken
            //col 4 = notes
            XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
            List<string> matchedClasses = new List<string>();    
            ISheet x = workbook.GetSheet("Sheet1");
            for(int i = 22; i < x.LastRowNum; i++) //NOTE LOOP STARTS AT ROW 22 FOR TESTING ONLY
            {
                if(x.GetRow(i) == null)
                {
                    break;
                }
                else
                {
                    Course matchedClass = matchClass(x.GetRow(i).GetCell(1).StringCellValue);
                    if(matchedClass != null)
                    {
                        if (x.GetRow(i).GetCell(3) == null || x.GetRow(i).GetCell(3).StringCellValue == "") //verify cell is emtpy
                        {
                            x.GetRow(i).GetCell(3).SetCellValue(matchedClass.quarter);
                            matchedClasses.Add(matchedClass.classCode);
                        }
                    }               
                }
            }
            fileStream = new FileStream(formPath, FileMode.Open, FileAccess.Write, FileShare.Write); //change stream mode to write
            workbook.Write(fileStream);
            string result = "Matched classes:\n";
            foreach(string matchedClass in matchedClasses)
            {
                result += matchedClass + "\n";
            }

            return result;
        }
        /// <summary>
        /// iterates through parameter list of courses for matching course code provided in args
        /// </summary>
        /// <param name="cellValue">course value to match</param>
        /// <returns>course object matching the provided course code</returns>
        private Course matchClass(string cellValue)
        {
            foreach(Course course in classList){
                if(course.classCode.Equals(cellValue, StringComparison.OrdinalIgnoreCase))
                {
                    return course;
                }
            }
            return null;
        }

    }
} 