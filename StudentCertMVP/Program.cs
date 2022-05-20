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

            classRegex regex = new classRegex();
            List<Course> studentClasses = new List<Course>();
            studentClasses = regex.createStudent("test 1, CIS 124, 5.00, FA1234, test 2, 3.50,CIS 246 Su2021, test 1,11.50 CIS144, , SP2134");
            regex.studentIDValid("11111111");
            regex.studentIDValid("1111");
            /*string filepath = @"C:\Users\Brayden\Desktop\StuCert\StudentFiles";
            FileHandler files = new FileHandler(filepath);
            files.getFilePath("101015831");
            files.getExcelFilePaths();
            List<string> forms = files.getExcelFilePaths();
            Course course1 = new Course("test 1", "CIS 124", 5, "FA42");
            Course course2 = new Course("test 1", "CIS 142", 5, "FA42");
            Course course3 = new Course("test 1", "CIS 160", 5, "FA42");
            List<Course> courses = new List<Course>();
            courses.Add(course3);
            courses.Add(course1);
            courses.Add(course2);
            Tracker CSV = new Tracker(courses);
            CSV.matchClasses(forms);*/


        }
    }
}
