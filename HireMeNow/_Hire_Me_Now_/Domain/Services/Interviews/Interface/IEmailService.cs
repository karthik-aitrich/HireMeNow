using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interviews.Interface
{
    public interface IEmailService
    {
        Task SendInterviewScheduledEmailAsync(string toEmail, DateTime interviewDate , string mode , string meetingLink , string venue );
    }
}
