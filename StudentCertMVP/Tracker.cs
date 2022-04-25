using System;
using ExcelDataReader;

public class tracker
{
    public tracker()
    {

    }
    /*private readExcel(string filepath)
    {
        var stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            // Choose one of either 1 or 2:

            // 1. Use the reader methods
            List<List<String>> result = new List<List<String>>();
            do
            {
                while (reader.Read())
                {
                    // reader.GetDouble(0);
                }
            } while (reader.NextResult());

            // The result of each spreadsheet is in result.Tables
        }
    }*/
    /// <summary>
    /// From a CSV, xls or xlsx file builds a 2D list. List is structured with the colums as the outer list, with rows nested underneath. For example,
    /// selecting column 3 row 25 would look like; List[2][24].
    /// </summary>
    /// <param name="filePath">directory file is located in</param>
    /// <param name="fileName">file name of file to build list from</param>
    /// <returns>Returns 2D list generated from CSV</returns>
    public List<List<String>> buildListFromCSV(String filePath, String fileName)
    {
        string[] fileExtension = fileName.Split('.');
        List<List<String>> result = new List<List<String>>();
        if (fileExtension[1].Equals("xls", StringComparison.OrdinalIgnoreCase))
        {
            FileStream fileStream = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fileStream);
            result = generateFromExcel(reader);
        }
        else if (fileExtension[1].Equals("xlsx", StringComparison.OrdinalIgnoreCase))
        {
            FileStream fileStream = new FileStream(filePath + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            result = generateFromExcel(reader);
        }
        /*        else if (fileExtension[1].Equals("csv", StringComparison.OrdinalIgnoreCase))
                {
                    StreamReader streamReader = new StreamReader(filePath + fileName);
                    result = generateFromCSV(streamReader);
                }*/
        else
        {
            throw new Exception($"ERROR: file extension for {fileName} is either missing or is and invalid extension.\n" +
                $"valid extensions include: xls, xlsx and csv");
        }
        return result;
    }
    /// <summary>
    /// overloaded method. uses the file directory and file name in a single string rather than 2 seperate string
    /// </summary>
    /// <param name="filePath">directory and filename to parse to list</param>
    /// <returns>returns 2d list generated from provided file</returns>
    /// <exception cref="Exception"></exception>
    public List<List<String>> buildListFromCSV(String filePath)
    {
        string[] fileExtension = filePath.Split('.');
        List<List<String>> result = new List<List<String>>();
        if (fileExtension[1].Equals("xls", StringComparison.OrdinalIgnoreCase))
        {
            FileStream fileStream = new FileStream(filePath + filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fileStream);
            result = generateFromExcel(reader);
        }
        else if (fileExtension[1].Equals("xlsx", StringComparison.OrdinalIgnoreCase))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            result = generateFromExcel(reader);
        }
        else
        {
            throw new Exception($"ERROR: file extension for {filePath} is either missing or is and invalid extension.\n" +
                $"valid extensions include: xls, xlsx and csv");
        }
        return result;
    }
    /// <summary>
    /// iterates through provided CSV file to create 2d list. 
    /// </summary>
    /// <param name="streamReader">file to parse</param>
    /// <returns>returns 2d list generated from provided file</returns>
    private List<List<string>> generateFromCSV(StreamReader streamReader)
    {
        List<List<String>> result = new List<List<String>>();
        var reader = streamReader.ReadLine(); // read header line
        int colSelect = 0;
        if (reader != null)
        {
            //used to initialize lists to add to 2d array
            var firstRow = reader.Split(",");
            foreach (var row in firstRow)
            {
                List<String> row1 = new List<String>();
                string rowString = removeQuotesAndCommas(row.ToString());
                row1.Add(rowString);
                result.Add(row1);
                colSelect++;
            }
            reader = streamReader.ReadLine();
            while (reader != null)
            {
                colSelect = 0;
                string[] readerParse = reader.Split(",");
                foreach (string col in readerParse)
                {
                    string colString = removeQuotesAndCommas(col.ToString());
                    result[colSelect].Add(colString);
                    colSelect++;
                }
                reader = streamReader.ReadLine();
            }
            streamReader.Close();
        }
        return result;
    }
    /// <summary>
    /// iterates through provided excel formatted file to create 2d list. 
    /// </summary>
    /// <param name="reader">file to parse</param>
    /// <returns>eturns 2d list generated from provided file</returns>
    private List<List<String>> generateFromExcel(IExcelDataReader reader)
    {
        List<List<String>> result = new List<List<String>>();
        var ds = reader.AsDataSet(new ExcelDataSetConfiguration());
        //var csvContent = string.Empty;
        //bool hasRuss = false;
        int russDex = 0;
        /*while (russDex < ds.Tables.Count)
        {
            if (ds.Tables[russDex].TableName == "Russell 2000")
            {
                hasRuss = true;
                break;
            }
            russDex++;
        }*/
        //if (hasRuss == true)
        //{
        for (int j = 0; j < ds.Tables[russDex].Columns.Count; j++)
        {
            List<string> col = new List<string>();
            for (int k = 0; k < ds.Tables[russDex].Rows.Count; k++)
            {
                col.Add(ds.Tables[russDex].Rows[k][j].ToString());
            }
            result.Add(col);
        }
        //}

        return result;
    }

    /// <summary>
    /// Removes quotation marks and commas from string
    /// </summary>
    /// <param name="toRemove"></param>
    /// <returns>String with quotation marks and commas removed</returns>
    private string removeQuotesAndCommas(string toRemove)
    {
        string result = toRemove;
        result = result.Replace(",", "");
        result = result.Replace("\"", "");
        result = result.Replace("\\", "");
        return result;
    }
    //processes the schedule from the main program into seperate entries in a list, then calls parseForClasses
    //also gets the list from buildListFromCSV, using the filepath passed to it
    //returns whether the program successfully wrote to the excel file or not
    public bool scheduleInfoFromMenu(string newSchedule, string filePath)
    {
        char[] seperatorChars = { ',', '.', ':', '\t' };
        List<string> classes = newSchedule.Split(seperatorChars).ToList();
        List<List<String>> excelClasses = buildListFromCSV(filePath);
        bool complete = parseForClasses(classes, excelClasses);
        return complete;
    }
    //compares the classes in the excel sheet to the classes from the main program, and then if different, runs addToExcel
    //if the same, returns false
    private bool parseForClasses(List<string> classes, List<List<String>> excelClasses)
    {
        bool complete = false;
        foreach (List<string> subList in excelClasses)
        {
            foreach (string item in subList)
            {
                if (!classes.Contains(item))
                {
                    complete = addToExcel(item);
                    // call function to add to excel file
                }
            }
        }
        return complete;
    }
    //Still WIP
    private bool addToExcel(string item)
    {
        bool complete = false;
        return complete;
    }
}
