using System;

namespace JLCCopyReportService.Models
{
    public class Report
    {
        public int Id { get; set; }
        public Nullable<long> AccountNumber { get; set; }
        public string BusinessName { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string StaticNotes { get; set; }
        public string OpenHours { get; set; }
        public Nullable<long> StartMeter { get; set; }
        public Nullable<long> EndMeter { get; set; }
        public Nullable<long> Value { get; set; }
        public string CallBack { get; set; }
        public string Notes { get; set; }
        public string Model { get; set; }
        public string MeterLocation { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Year { get; set; }
    }
}
