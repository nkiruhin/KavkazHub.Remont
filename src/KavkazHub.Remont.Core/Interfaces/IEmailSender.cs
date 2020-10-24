using System.Threading.Tasks;

namespace KavkazHub.Remont.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
