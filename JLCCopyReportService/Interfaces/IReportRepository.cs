using JLCCopyReportService.Models;
using System.Collections.Generic;

namespace JLCCopyReportService.Interfaces
{
    interface IReportRepository 
    {
        IEnumerable<Report> Get();
    }
}
