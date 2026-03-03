using Domain.Services.Interviews.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interviews.Interface
{
    public interface IInterviewService
    {
        Task<InterviewDto> ScheduleInterviewAsync(Guid providerId, InterviewDto dto);

     
        Task<List<InterviewDto>> GetMyInterviewsAsync(Guid providerId);

  
        Task<InterviewDto?> GetInterviewByIdAsync(Guid interviewId, Guid providerId);

   
        Task<InterviewDto> UpdateInterviewAsync(Guid interviewId, Guid providerId, InterviewDto dto);

    
        Task DeleteInterviewAsync(Guid interviewId, Guid providerId);


        Task<IEnumerable<InterviewDto>> GetAllInterviewAsync();
    }
}
