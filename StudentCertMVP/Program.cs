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
            Application.Run(new StudentDegreeTrackingProgram());

            string filepath = @"C:\Users\Brayden\Desktop\StuCert\StudentFiles";
            FileHandler files = new FileHandler(filepath);
            files.getFilePath("101015831");
            files.getExcelFilePaths();
            List<string> forms = files.getExcelFilePaths();
            Course course1 = new Course("test 1", "CIS 124", 5, "SU22");
            Course course2 = new Course("test 1", "CIS 142", 5, "SU22");
            Course course3 = new Course("test 1", "CIS 160", 5, "SU22");
            List<Course> courses = new List<Course>();
            courses.Add(course3);
            courses.Add(course1);
            courses.Add(course2);
            Tracker CSV = new Tracker(courses);
            CSV.matchClasses(forms);


        }
    }
}
