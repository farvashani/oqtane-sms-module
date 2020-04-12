using System.Collections.Generic;
using System.Threading.Tasks;
using Tres.Smss.Models;

namespace Tres.Smss.Services
{
    public interface ISmsService 
    {
        Task<List<Sms>> GetSmssAsync(int ModuleId);

        Task<Sms> GetSmsAsync(int SmsId);

        Task<Sms> AddSmsAsync(Sms Sms);

        Task<Sms> UpdateSmsAsync(Sms Sms);

        Task DeleteSmsAsync(int SmsId);
    }
}
