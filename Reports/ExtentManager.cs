using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ReplyRecruitmentTask;
    public class ExtentManager
    {
        private static ExtentReports _extent;
        private static readonly string ReportPath = @"C:\Coding\SeleniumCode\ReplyRecruitmentTask\Reports\ReportsDirectory\Report.html";

        public static ExtentReports GetInstance()
        {
            return _extent ??= CreateInstance();
        }

        private static ExtentReports CreateInstance()
        {
            var htmlReporter = new ExtentSparkReporter(ReportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            return _extent;
        }

    public static void FlushReport()
    {
        _extent.Flush();
    }

    public static ExtentTest CreateTest(string testName)
    {
        return _extent.CreateTest(testName);
    }
}
