using JLCCopyReportService.Models;
using System.Data.Entity;

namespace JLCCopyReportService
{
    public class JLCCopyReportDBContext : DbContext
    {
        public JLCCopyReportDBContext() : base("name=JLCCopyReportDBContext")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<JLCCopyReportDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Report> Reports { get; set; }
    }
}
