using Microsoft.Extensions.Logging;

namespace MyProject.Services
{
    public interface IMailService
    { 
        void SendMessage(string to, string subject, string body);
    }
}