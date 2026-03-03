


using Domain.Models;
using Domain.Services.Interviews.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
    }

    public async Task SendInterviewScheduledEmailAsync(
        string toEmail,
        DateTime interviewDate,
        string mode,
        string? meetingLink = null,
        string? venue = null)
    {
        if (string.IsNullOrWhiteSpace(toEmail))
            throw new ArgumentException("Recipient email is required.", nameof(toEmail));

        var isOnline = mode?.Trim().ToLower() is "online" or "virtual" or "meet" or "zoom" or "teams";

        var sb = new StringBuilder();
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html>");
        sb.AppendLine("<head><meta charset='utf-8'><title>Interview Scheduled</title></head>");
        sb.AppendLine("<body style='font-family: Arial, Helvetica, sans-serif; line-height: 1.6; color: #333;'>");
        sb.AppendLine("<h2 style='color: #2c3e50;'>Interview Scheduled – Confirmation</h2>");
        sb.AppendLine($"<p>Dear Candidate,</p>");
        sb.AppendLine($"<p>We are pleased to inform you that your interview has been scheduled.</p>");
        sb.AppendLine("<ul style='margin: 16px 0; padding-left: 20px;'>");
        sb.AppendLine($"  <li><strong>Date & Time:</strong> {interviewDate:dddd, MMMM dd, yyyy 'at' hh:mm tt}</li>");
        sb.AppendLine($"  <li><strong>Mode:</strong> {mode ?? "Not specified"}</li>");

        if (isOnline && !string.IsNullOrWhiteSpace(meetingLink))
        {
            sb.AppendLine($"  <li><strong>Meeting Link:</strong> <a href='{WebUtility.HtmlEncode(meetingLink)}' style='color: #0066cc;'>{WebUtility.HtmlEncode(meetingLink)}</a></li>");
        }
        else if (!string.IsNullOrWhiteSpace(venue))
        {
            sb.AppendLine($"  <li><strong>Venue:</strong> {WebUtility.HtmlEncode(venue)}</li>");
        }

        sb.AppendLine("</ul>");
        sb.AppendLine("<p style='font-weight: bold; color: #e74c3c;'>Please arrive / join 10 minutes early.</p>");
        sb.AppendLine("<p>Kindly bring a copy of your resume (for in-person interviews).</p>");
        sb.AppendLine("<p>We look forward to meeting you!</p>");
        sb.AppendLine("<p>Best regards,<br>HR Team</p>");
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");

        var message = new MailMessage
        {
            From = new MailAddress(_settings.SenderEmail, "HR Department"),
            Subject = "Interview Scheduled – Confirmation",
            Body = sb.ToString(),
            IsBodyHtml = true
        };

        message.To.Add(toEmail.Trim());

        try
        {
            using var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.SenderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 30000 // 30 seconds
            };

            await smtp.SendMailAsync(message);
        }
        catch (SmtpException ex)
        {
            // In real apps: log exception (Serilog, ILogger, etc.)
            // Consider re-throwing or returning a result object instead of just throwing
            throw new InvalidOperationException("Failed to send interview confirmation email.", ex);
        }
    }
}