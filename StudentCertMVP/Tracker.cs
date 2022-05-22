using System;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace StudentCertMVP
{
    public class Tracker
    {
        private List<Course> classList { get; set; }
        private string alertString { get; set; }
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
                alertString = "";

                if (fileExtension[1].Equals("xls", StringComparison.OrdinalIgnoreCase))
                {
                    FileStream fileStream = new FileStream(form, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

                    //result = generateFromExcel(workbook);
                }
                else if (fileExtension[1].Equals("xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    string[] formName = form.Split("\\");
                    formName = formName[formName.Length - 1].Split(".");
                    result += $"Results for {formName[0]}";
                    result += matchClassesXSSF(form);
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
            fileStream.Close();
            List<string> matchedClasses = new List<string>();    
            ISheet x = workbook.GetSheet("Sheet1");
            //verify sheet is in the updated format
            if(x.GetRow(2).GetCell(0).StringCellValue.Contains("Course Name", StringComparison.OrdinalIgnoreCase) &&
               x.GetRow(2).GetCell(1).StringCellValue.Contains("Course ID", StringComparison.OrdinalIgnoreCase) &&
               x.GetRow(2).GetCell(2).StringCellValue.Contains("Credits", StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 3; i < x.LastRowNum; i++)
                {

                    if (x.GetRow(i) == null)
                    {
                        break;
                    }
                    else
                    {
                        if(x.GetRow(i).GetCell(0).StringCellValue.Contains("Required Courses", StringComparison.OrdinalIgnoreCase) &&
                           !int.TryParse(x.GetRow(i).GetCell(2).StringCellValue, out int value))
                        {
                            i++;
                            matchRequired(ref i, ref x, ref matchedClasses);
                        }
                        //!int.TryParse(x.GetRow(i).GetCell(2).StringCellValue, out int vals) &&
                        else if (x.GetRow(i).GetCell(0).StringCellValue.Contains("CR", StringComparison.OrdinalIgnoreCase) ||
                                 x.GetRow(i).GetCell(0).StringCellValue.Contains("Credits", StringComparison.OrdinalIgnoreCase))
                        {
                            double maxCredits = 0;
                            for (int k = 0; k < x.GetRow(i).GetCell(0).ToString().Length; k++)
                            {
                                if (Char.IsDigit(x.GetRow(i).GetCell(0).ToString()[k]))
                                {
                                    char intChar = x.GetRow(i).GetCell(0).ToString()[k];
                                    int temp = intChar - '0';
                                    if(maxCredits != 0)
                                    {
                                        maxCredits = (maxCredits * 10) + temp;
                                    }
                                    else
                                    {
                                        maxCredits += temp;
                                    }
                                    
                                }
                            }
                            i++;
                            matchRequiredElectives(ref i, ref x, ref matchedClasses, maxCredits);

                        }

                    }
                }
                fileStream = new FileStream(formPath, FileMode.Create, FileAccess.Write, FileShare.Write);
                workbook.Write(fileStream);
                fileStream.Close();
                string result = "Added Classes:\n";
                foreach (string matchedClass in matchedClasses)
                {
                    result += matchedClass + "\n";
                }
                result += "Classes unable to fit into declared degree programs:\n";
                if(classList.Count > 0)
                {
                    foreach (Course course in classList)
                    {
                        result += course.classCode + "\n";
                    }
                }
                else
                {
                    result += "N/A\n";
                }

                result += "Additional notes: \n";
                result += alertString;
                return result;
            }
            else
            {
                throw new Exception("ERROR: Incorrect file tracker format");
            }
            
        }
        private void matchRequired(ref int row, ref ISheet x, ref List<string> matchedClasses)
        {
            //Column locations:
            //col 0 = full class name
            //col 1 = course code
            //col 2 = credit amount
            //col 3 = quarter taken
            //col 4 = notes
            while (x.GetRow(row).GetCell(0).StringCellValue != "" && x.GetRow(row).GetCell(0).StringCellValue != null)
            {
                Course matchedClass = matchClass(x.GetRow(row).GetCell(1).StringCellValue);
                if (matchedClass != null)
                {
                    if (x.GetRow(row).GetCell(3) == null || x.GetRow(row).GetCell(3).StringCellValue == "") //verify cell is emtpy
                    {
                        x.GetRow(row).GetCell(3).SetCellValue(matchedClass.quarter); //set course code
                        x.GetRow(row).GetCell(2).SetCellValue(matchedClass.credit); //set credit amount
                        matchedClasses.Add(matchedClass.classCode);
                    }
                    //course has been taken previously, handle note appending
                    else
                    {
                        string cellValue = handleNotes(x.GetRow(row).GetCell(4).ToString());
                        alertString += $"Note appended to class {matchedClass.classCode}:\n" +
                            $"{cellValue}\n";
                        x.GetRow(row).GetCell(4).SetCellValue(cellValue);
                        x.GetRow(row).GetCell(3).SetCellValue(matchedClass.quarter); //set course code
                        x.GetRow(row).GetCell(2).SetCellValue(matchedClass.credit); //set credit amount
                        matchedClasses.Add(matchedClass.classCode);
                    }
                }
                row++;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="x"></param>
        /// <param name="matchedClasses"></param>
        /// <param name="maxCredits"></param>
        private void matchRequiredElectives(ref int row, ref ISheet x, ref List<string> matchedClasses, double maxCredits)
        {
            //Column locations:
            //col 0 = full class name
            //col 1 = course code
            //col 2 = credit amount
            //col 3 = quarter taken
            //col 4 = notes
            double creditsTaken = 0;
            int creditCheckRow = row;
            //iterate through electives section. get current amount of credits already taken based on quarter attendance
            while (x.GetRow(creditCheckRow).GetCell(0).StringCellValue != "" && x.GetRow(row).GetCell(0).StringCellValue != null)
            {
                if (x.GetRow(creditCheckRow).GetCell(3).StringCellValue != "")
                {
                    double temp = double.Parse(x.GetRow(creditCheckRow).GetCell(2).ToString());
                    creditsTaken += temp;
                }
                creditCheckRow++;
            }
            if(creditsTaken <= maxCredits)
            {
                while (x.GetRow(row).GetCell(0).StringCellValue != "" && x.GetRow(row).GetCell(0).StringCellValue != null)
                {
                    Course matchedClass = matchClass(x.GetRow(row).GetCell(1).StringCellValue);
                    if (matchedClass != null)
                    {

                        if (x.GetRow(row).GetCell(3) == null || x.GetRow(row).GetCell(3).StringCellValue == "") //verify cell is emtpy
                        {
                            //quarter cell is empty, new class is being added. check if max credits have been exceeded before changing cell values
                            creditsTaken += matchedClass.credit;
                            if (creditsTaken <= maxCredits)
                            {
                                x.GetRow(row).GetCell(3).SetCellValue(matchedClass.quarter); //set course code
                                x.GetRow(row).GetCell(2).SetCellValue(matchedClass.credit); //set credit amount
                                matchedClasses.Add(matchedClass.classCode);
                            }
                            else
                            {
                                classList.Add(matchedClass);
                                alertString += $"ALERT: Elective credit amount exceeded, unable to add {matchedClass.classCode}\n" +
                                    $"Maxiumum allowed credits: {maxCredits} Credit amount with non-fit course: {creditsTaken}";
                                break;
                            }

                        }
                        //course has been taken previously, handle note appending
                        else
                        {
                            //class has been taken previously and credits are not added to total
                            string cellValue = handleNotes(x.GetRow(row).GetCell(4).ToString());
                            alertString += $"Note appended to class {matchedClass.classCode}:\n" +
                                $"{cellValue}\n";
                            x.GetRow(row).GetCell(4).SetCellValue(cellValue);
                            x.GetRow(row).GetCell(3).SetCellValue(matchedClass.quarter); //set course code
                            x.GetRow(row).GetCell(2).SetCellValue(matchedClass.credit); //set credit amount
                            matchedClasses.Add(matchedClass.classCode);

                        }

                    }
                    row++;
                }
            }
            else
            {
                alertString += $"ALERT: Elective credit amount exceeded, unable to add additional courses\n" +
                    $"Maxiumum allowed credits: {maxCredits} Credit amount with non-fit course: {creditsTaken}";
            }

        }
            /// <summary>
            /// Appends, inserts or increments the notes section string of the student tracker. If cell value is blank method return defaults to "Attempt 2"
            /// if an attempt has already been made method will increment the attempt number. If other notes already exist, method appends attempt number to
            /// the end of the note.
            /// </summary>
            /// <param name="noteValue">cell value of the tracker</param>
            /// <returns>Incremented, appended, or newly created string to write to notes section</returns>
            private string handleNotes(string noteValue)
        {
            //-----------------------------
            //abandon hope all ye who enter
            //-----------------------------
            //verify something is actually contained in the notes other than a blank space or an accidental whitespace char
            if(noteValue.Length > 1)
            {
                //check if an "attempt" note has already been added
                if (noteValue.Contains("attempt", StringComparison.OrdinalIgnoreCase))
                {
                    //set attempt number to 0 as placeholder, split notes by whitespace
                    int attempt = 0;
                    string[] noteWords = noteValue.Split(" ");
                    bool noteChanged = false;
                    //iterate through each word in notes
                    int i = 0;
                    while (i < noteWords.Length && noteChanged == false)
                    {
                        //check if word is or contains "attempt"
                        if (noteWords[i].Contains("attempt", StringComparison.OrdinalIgnoreCase))
                        { 
                            //handle situations where there is no whitespace preceeding the attempt number
                            for (int k = 0; k < noteWords[i].Length; k++)
                            {
                                if (Char.IsDigit(noteWords[i][k]))
                                {
                                    char intChar = noteWords[i][k];
                                    attempt = intChar - '0';
                                    noteWords[i].Replace(",", "");
                                    noteWords[i] = $"Attempt {attempt + 1}";
                                    k = noteValue.Length + 100;
                                    noteChanged = true;
                                }
                            }
                            //white space preceeds the attempt number
                            if (noteChanged == false)
                            {
                                //try catch blocks in case the attempt number was omitted entirely
                                try
                                {
                                    //attempt to parse using existing functions
                                    try
                                    {
                                        attempt = int.Parse(noteWords[i + 1]);
                                        noteWords[i + 1] = $"{attempt + 1}";
                                        noteChanged = true;
                                    }
                                    //invalid syntax. Typically caught when "nd" or "rd" is appended to the end of integers
                                    catch
                                    {
                                        for (int k = 0; k < noteWords[i + 1].Length; k++)
                                        {
                                            if (Char.IsDigit(noteWords[i + 1][k]))
                                            {
                                                attempt = noteWords[i + 1][k];
                                                noteWords[i + 1] = $"{attempt + 1}";
                                                k = noteValue.Length + 1;
                                                noteChanged = true;
                                            }
                                        }
                                    }

                                }
                                catch
                                {
                                    //if all else fails, use Attempt 2 as default
                                    return "Attempt 2";
                                }
                            }

                        }
                        i++;
                    }
                    //rebuild string and return
                    if (noteChanged == true)
                    {
                        string result = "";
                        for (int j = 0; j < noteWords.Length - 1; j++)
                        {
                            noteWords[j].Replace(" ", "");
                            noteWords[j].Replace(",", "");
                            noteWords[j].Replace(".", "");
                            noteWords[j].Replace("_", "");
                            result += noteWords[j] + " ";
                        }
                        result += noteWords[noteWords.Length - 1];
                        return result;
                    }
                    //note was not changed for some reason change to default value
                    else
                    {
                        return  "Attempt 2";
                    }
                }
                //misc note already in cell. append default return value
                else
                {
                    return noteValue += ", Attempt 2";
                }
            }
            //empty cell value, return default
            else
            {
                return  "Attempt 2";
            }
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
                    classList.Remove(course);
                    return course;
                }
            }
            return null;
        }

    }
} 