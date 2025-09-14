namespace Shared.Abstractions;

public interface INotificationSender
{
    Task SendEmailAsync(string to, string subject, string body);
    Task SendSmsAsync(string phoneNumber, string message);
    Task SendPushNotificationAsync(string userId, string title, string message);
    Task SendWhatsAppMessageAsync(string phoneNumber, string message);
}