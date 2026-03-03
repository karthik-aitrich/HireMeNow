using Domain.Models;
using Domain.Services.Interviews.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

public class InterviewRepository : IInterviewRepository
{
    private readonly DbHireMeNowWebApiContext _context;

    public InterviewRepository(DbHireMeNowWebApiContext context)
    {
        _context = context;
    }


    public async Task<Interview> ScheduleInterviewAsync(Interview interview)
    {
        await _context.Interviews.AddAsync(interview);
        await _context.SaveChangesAsync();
        return interview;
    }

 
 

    public async Task<List<Interview>> GetInterviewByProviderIdAsync(Guid providerId)
    {
        return await _context.Interviews
            .Include(i => i.Application)
                .ThenInclude(a => a.JobPost)
            .Where(i => i.Application.JobPost.PostedBy == providerId)
            .ToListAsync();
    }




    public async Task<Interview> UpdateInterviewAsync(Interview interview)
    {
        _context.Interviews.Update(interview);
        await _context.SaveChangesAsync();
        return interview;
    }

 
    public async Task DeleteInterviewAsync(Interview interview)
    {
        _context.Interviews.Remove(interview);
        await _context.SaveChangesAsync();
    }




   public async Task<IEnumerable<Interview>> GetAllInterviewAsync()
    {
        return await _context.Interviews.ToListAsync();
    }



    public async Task<Interview?> GetInterviewByIdAsync(Guid interviewId)
    {
        return await _context.Interviews
            .Include(i => i.Application).ThenInclude(a => a.JobPost)
            .FirstOrDefaultAsync(i => i.InterviewId == interviewId);
    }


















    public async Task<List<Interview>> GetInterviewByApplicationIdAsync(Guid applicationId)
    {
        return await _context.Interviews
            .Where(i => i.ApplicationId == applicationId)
            .ToListAsync();
    }





    public async Task<Applicationn?> GetApplicationWithDetailsAsync(Guid applicationId)
    {
        return await _context.Applications
            .Include(a => a.JobPost)
            .Include(a => a.JobSeeker)
            .FirstOrDefaultAsync(a => a.ApplicationId == applicationId);
    }




   
}