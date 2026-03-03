namespace _Hire_Me_Now_.API.AdminDashboardss.Dto.ResponseObject
{
    public class AdminDashboardResponseObject
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
