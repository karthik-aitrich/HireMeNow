using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AdminDashboards.Dto
{
    public class AdminDashboardsDto
    {
        public int TotalJobs { get; set; }
        public int PendingJobs { get; set; }
        public int ApprovedJobs { get; set; }
        public int RejectedJobs { get; set; }
        public int BlockedJobs { get; set; }
        public int TotalJobProviders { get; set; }
        public int TotalJobSeekers { get; set; }
    }
}
