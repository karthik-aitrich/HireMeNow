using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interviews.Interface
{

    public interface IInterviewRepository
    {
        
        Task<Interview> ScheduleInterviewAsync(Interview interview);

      
        Task<Interview?> GetInterviewByIdAsync(Guid interviewId);

        Task<List<Interview>> GetInterviewByProviderIdAsync(Guid providerId);

        Task<List<Interview>> GetInterviewByApplicationIdAsync(Guid applicationId);
        Task<Applicationn?> GetApplicationWithDetailsAsync(Guid applicationId);


        Task<Interview> UpdateInterviewAsync(Interview interview);

      
        Task DeleteInterviewAsync(Interview interview);



        Task<IEnumerable<Interview>> GetAllInterviewAsync();
    }
}
