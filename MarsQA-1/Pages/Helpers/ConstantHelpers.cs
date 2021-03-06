using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace MarsQA_1.Helpers
{
    public class ConstantHelpers
    {
        //Base Url
        public static string Url = "http://localhost:5000";

        //ScreenshotPath
        public static string ScreenshotPath = @"C:\Users\Nancy\Desktop\Competition - part2\Competition1\MarsQA-1\TestReports\Screenshots";

        //ExtentReportsPath
        public static string ReportsPath = @"C:\Users\Nancy\Desktop\Competition - part2\Competition1\MarsQA-1\TestReports\Screenshots\1" + "Report"+DateTime.Now.ToString("_dd-mm-yyyy_mss")+ ".html";

        //ReportXML Path
        public static string ReportXMLPath = @"C:\Users\Nancy\Desktop\Competition - part2\Competition1\MarsQA-1\TestReports\Screenshots\1" + DateTime.Now.ToString("_dd-mm-yyyy_mss") + ".xml";


    }
}