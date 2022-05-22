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
            //studentClasses = regex.createStudent("test 1, CIS 124, 5.00, FA1234, test 2, 3.50,CIS 246 Su2021, test 1,11.50 CIS144, , SP2134");
            string test = "New Window | Help | Personalize Page\nEnrollment Summary\nTerm Statistics\nPositive Service Indicators\nBrayden Meyer\n101015831\nTerm:\nCareer:\n2021 FALL\nUndergrad\nOlympic College\nPrint Study List\nReport Manager\nFind | View 3        First Show previous row(inactive button)(Alt +,) 1 - 5 of 5 Show next row(inactive button)(Alt +.) Last\nClass Nbr\nSubject\nCatalog\nSession\nSection\nStatus\nStatus / Reason\nAcad Prog\nGrading Basis\nUnits Taken\n13122\nACCT&\n201\nRegular\n04\nEnrolled\nEnrolled\nPRFTC\nGraded\n5.50\nCourse Detail\nPrinciples of Accounting I\nLecture\n15266\nCIS\n111\nRegular\n04\nEnrolled\nEnrolled\nPRFTC\nGraded\n4.00\nCourse Detail\nIntro To Operating Systs\nLecture\n15267\nCIS\n111\nRegular\n04L\nEnrolled\nEnrolled\nPRFTC\nNon-Graded\n\n\nCourse Detail\nIntro To Operating Systs\nLaboratory\n12210\nCIS\n155\nRegular\n01\nEnrolled\nEnrolled\nPRFTC\nGraded\n4.00\nCourse Detail\nWeb Development I\nLecture\n12212\nCIS\n155\nRegular\n01L\nEnrolled\nEnrolled\nPRFTC\nNon-Graded\n\n\nCourse Detail\nWeb Development I\nLaboratory\nEnrollment Summary | Term Statistics";
            studentClasses = regex.createStudent(test);


            /*string filepath = @"C:\Users\Brayden\Desktop\StuCert\StudentFiles";
            FileHandler files = new FileHandler(filepath);
            files.getFilePath("101015831");
            files.getExcelFilePaths();
            List<string> forms = files.getExcelFilePaths();
            Course course1 = new Course("test 1", "CIS 155", 5, "SU22");
            Course course2 = new Course("test 1", "SOC&101", 5, "SU22");
            Course course3 = new Course("test 1", "BUS&101", 5, "SU22");
            List<Course> courses = new List<Course>();
            courses.Add(course3);
            courses.Add(course1);
            courses.Add(course2);
            Tracker CSV = new Tracker(courses);
            CSV.matchClasses(forms);*/


        }
    }
}