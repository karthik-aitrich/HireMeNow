using AutoMapper;
using Domain.Models;
using Domain.Services.Interviews.Dto;
using Domain.Services.Interviews.Interface;
using MailKit;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public InterviewService(
        IInterviewRepository repository,
        IMapper mapper,
        IEmailService emailService)
    {
        _repository = repository;
        _mapper = mapper;
        _emailService = emailService;
    }

   
    public async Task<InterviewDto> ScheduleInterviewAsync(Guid providerId, InterviewDto dto)
    {
        var application = await _repository.GetApplicationWithDetailsAsync(dto.ApplicationId);

        if (application == null)

            throw new Exception("Application not found");




        if (application.JobPost.PostedBy != providerId)

            throw new UnauthorizedAccessException("You cannot schedule this interview");



        var existing = await _repository.GetInterviewByApplicationIdAsync(dto.ApplicationId);
        if (existing.Any())
            throw new Exception("Interview already scheduled for this application");




        var interview = _mapper.Map<Interview>(dto);
        interview.InterviewId = Guid.NewGuid();

        var created = await _repository.ScheduleInterviewAsync(interview);

        
        try
        {
            await _emailService.SendInterviewScheduledEmailAsync(
                application.JobSeeker.Email,
                interview.InterviewDate ?? DateTime.Now,
                interview.Mode.ToString(),
                interview.MeetingLink,
                interview.Venue
            );
        }
        catch
        {
            
        }

        return _mapper.Map<InterviewDto>(created);
    }






  public async  Task<List<InterviewDto>> GetMyInterviewsAsync(Guid providerId)
    {
        var interview = await _repository.GetInterviewByProviderIdAsync(providerId);

       

        return _mapper.Map<List<InterviewDto>>(interview);
    }

 



    public async Task<InterviewDto> UpdateInterviewAsync(Guid interviewId, Guid providerId, InterviewDto dto)
    {
        var interview = await _repository.GetInterviewByIdAsync(interviewId);

        if (interview == null)
            throw new Exception("Interview not found");



        if (interview.Application.JobPost.PostedBy != providerId)
            throw new UnauthorizedAccessException();



        interview.InterviewDate = dto.InterviewDate;
        interview.Mode = dto.Mode;
        interview.MeetingLink = dto.MeetingLink;
        interview.Venue = dto.Venue;
        interview.Remark = dto.Remark;
        interview.Status = dto.Status;
     

        var updated = await _repository.UpdateInterviewAsync(interview);

        return _mapper.Map<InterviewDto>(updated);
    }

   

    public async Task DeleteInterviewAsync(Guid interviewId, Guid providerId)
    {
        var interview = await _repository.GetInterviewByIdAsync(interviewId);

        if (interview == null)
            throw new Exception("Interview not found");

        if (interview.Application.JobPost.PostedBy != providerId)
            throw new UnauthorizedAccessException();

        await _repository.DeleteInterviewAsync(interview);
    }



   public async Task<IEnumerable<InterviewDto>> GetAllInterviewAsync()
    {
        var interview = await _repository.GetAllInterviewAsync();
        return  _mapper.Map<IEnumerable<InterviewDto>>(interview);
    }





    public async Task<InterviewDto?> GetInterviewByIdAsync(Guid interviewId, Guid providerId)
    {
        var interview = await _repository.GetInterviewByIdAsync(interviewId);

        if (interview == null)
            return null;

        if (interview.Application.JobPost.PostedBy != providerId)
            throw new UnauthorizedAccessException();

        return _mapper.Map<InterviewDto>(interview);
    }





}