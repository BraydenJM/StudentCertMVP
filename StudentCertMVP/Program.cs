namespace StudentCertMVP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            string filepath = @"C:\Users\Brayden\Desktop\StuCert\StudentFiles";
            FileHandler files = new FileHandler(filepath);
            files.getFilePath("101014791");
            files.getExcelFilePaths();
            List<string> forms = new List<string>();

            forms = files.getStudentForms();

            tracker CSV = new tracker();


        }
    }
}