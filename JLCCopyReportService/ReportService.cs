using JLCCopyReportService.Interfaces;
using JLCCopyReportService.Models;
using JLCCopyReportService.Repositories;
using System.Collections.Generic;

namespace JLCCopyReportService
{
    public class ReportService : IReportService<Report>
    {
        IReportRepository repository;

        public ReportService()
        {
            repository = new ReportRepository();
        }

        public IEnumerable<Report> GetReport()
        {
            return repository.Get();
        }
    }
}
