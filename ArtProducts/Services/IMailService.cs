using Microsoft.Extensions.Logging;

namespace ArtProducts.Services
{
    public interface IMailService
    { 
        void SendMessage(string to, string subject, string body);
    }
}