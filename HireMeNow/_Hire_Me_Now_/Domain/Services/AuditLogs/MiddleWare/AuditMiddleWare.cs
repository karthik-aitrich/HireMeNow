//using Domain.Models;
//using Domain.Services.AuditLogs.Interface;
//using Microsoft.AspNetCore.Http;
//using System.Security.Claims;

//public class AuditMiddleware
//{
//    private readonly RequestDelegate _next;

//    public AuditMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task InvokeAsync(HttpContext context, IAuditLogsService auditService)
//    {
//        var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

//        Guid? userId = null;

//        if (userIdClaim != null)
//            userId = Guid.Parse(userIdClaim.Value);

//        var endpoint = context.Request.Path;
//        var method = context.Request.Method;
//        var ip = context.Connection.RemoteIpAddress?.ToString();

//        await _next(context); // continue request

//        var statusCode = context.Response.StatusCode;

//        var log = new AuditLog
//        {
//            UserId = userId,
//            Action = "API_CALL",
//            Endpoint = endpoint,
//            Method = method,
//            StatusCode = statusCode,
//            IpAddress = ip
//        };

//        await auditService.LogAsync(log);
//    }
//}