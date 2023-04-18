using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.OpenClosedPrinciple
{
    public class TempMainMethod
    {
        
        public void Main()
        {
            ReportDocument rd = ReportCreatorFactory.GetReportDocuemnt(ReportType.excel);
            var reportFile = rd.GenerateReport();

        }
    }
}
