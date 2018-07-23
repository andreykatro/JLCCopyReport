using System.Collections.Generic;

namespace JLCCopyReportService.Interfaces
{
    public interface IReportService<Report>
    {
        IEnumerable<Report> GetReport();
    }
}
