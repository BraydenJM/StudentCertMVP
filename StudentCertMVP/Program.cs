using ExcelDataReader;
namespace StudentCertMVP
{
    internal class Program
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

            //testing code, remove later
            tracker Trackertest = new tracker();
            Trackertest.scheduleInfoFromMenu("Nothing, Test,Information Systems Concepts,Testing", @"C:\Users\Steven\Desktop\Class Assignments\Student Files\Meyer, Brayden 101015831 CH33  D\[backfill][primary] CIS AAST-SW DEV.xlsx");
        }
    }
}