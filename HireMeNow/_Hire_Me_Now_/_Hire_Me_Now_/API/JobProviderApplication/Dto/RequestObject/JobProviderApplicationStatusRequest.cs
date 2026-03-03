using Domain.Enums;

namespace Hire_Me_Now.API.JobProviderApplication.Dto.RequestObject;

public class JobProviderApplicationStatusRequest
{
    public Guid ApplicationId { get; set; }
    public Guid ProviderId { get; set; }
    public string Status { get; set; }

}


