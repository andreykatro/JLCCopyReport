using JLCCopyReportAPI.Helpers;
using JLCCopyReportService;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace JLCCopyReportAPI.Controllers
{
    [Route("report")]
    public class ReportController : ApiController
    {
        ReportService report;
        
        public ReportController()
        {
            report = new ReportService();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var listReports = report.GetReport();
            var excel = ExcelHelper.GetExcelReport(listReports);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            var stream = new MemoryStream(excel);//do not use a "using (var stream = …)" block. Web API will dispose the stream.
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_report.xlsx"
            };
            return result;
        }
    }
}
