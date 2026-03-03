using AutoMapper;
using Domain.Models;
using Domain.Services.AuditLogs.DTO;
using Domain.Services.AuditLogs.Interface;

public class AuditLogsService : IAuditLogsService
{
    private readonly IAuditLogsRepository _repository;
    private readonly IMapper _mapper;

    public AuditLogsService(IAuditLogsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuditLogsDto>> GetAllLogsAsync()
    {
        var logs = await _repository.GetAllLogsAsync();
        return _mapper.Map<IEnumerable<AuditLogsDto>>(logs);
    }

    public async Task<IEnumerable<AuditLogsDto>> GetLogsByUserIdAsync(Guid userId)
    {
        var logs = await _repository.GetLogsByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<AuditLogsDto>>(logs);
    }

    public async Task AddLogAsync(AuditLogsDto auditLog)
    {
        var entity = _mapper.Map<AuditLog>(auditLog);

        //entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;

        await _repository.AddLogAsync(entity);
    }
}