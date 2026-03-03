using Domain.Enums;
namespace Hire_Me_Now.API.JobProviderApplication.Dto.ResponseObject

{
    public class JobProviderApplicationResponse
    {
        public Guid ApplicationId { get; set; }
        public Guid? JobId { get; set; }
        public Guid? SeekerId { get; set; }
        public String Status { get; set; }
        public DateTime? AppliedDate { get; set; }
    }
}
