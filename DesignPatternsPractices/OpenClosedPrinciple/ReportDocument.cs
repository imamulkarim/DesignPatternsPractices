using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.OpenClosedPrinciple
{
    //https://stackoverflow.com/questions/68763754/open-close-solid-principle-conditional-fails
    public class ReportFile
    {
        public string ReportName { get; init; }
        public string ReportHeader { get; set; } 
        public string ReportBody { get; set; } 
        public string ReportFooter { get; set; } 
    }

    public interface ReportDocument
    {
        ReportFile GenerateReport();
    }

    public class PdfReport : ReportDocument
    {
        public ReportFile GenerateReport()
        {
            return new ReportFile { ReportBody="Test pdf report", ReportFooter="f1", ReportHeader="h1", ReportName="pdf"};
        }
    }

    public class ExcelReport : ReportDocument
    {
        public ReportFile GenerateReport()
        {
            return new ReportFile { ReportBody = "Test Excel report", ReportFooter = "f1", ReportHeader = "h1", ReportName = "excel" };
        }
    }

    public enum ReportType
    {
        pdf, excel
    }

    public class ReportCreatorFactory
    {
        //ReportFile GenerateReport(string reportType);
        private static Dictionary<int, ReportDocument>
            reportsDoc = new Dictionary<int, ReportDocument>();

        public ReportCreatorFactory()
        {
            reportsDoc.Add((int)ReportType.excel, new ExcelReport());
            reportsDoc.Add((int)ReportType.pdf, new PdfReport());
        }

        public static ReportDocument GetReportDocuemnt(ReportType reportType)
        {
            return reportsDoc[(int)reportType];
        }
    }

    

}
