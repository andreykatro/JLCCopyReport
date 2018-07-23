using JLCCopyReportService.Interfaces;
using JLCCopyReportService.Models;
using System.Collections.Generic;

namespace JLCCopyReportService.Repositories
{
    class ReportRepository : IReportRepository
    {
        public IEnumerable<Report> Get()
        {
            JLCCopyReportDBContext dBContext = new JLCCopyReportDBContext();
            return dBContext.Reports;
        }
    }
}
