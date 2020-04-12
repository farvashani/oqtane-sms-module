using System.Collections.Generic;
using Tres.Smss.Models;

namespace Tres.Smss.Repository
{
    public interface ISmsRepository
    {
        IEnumerable<Sms> GetSmss(int ModuleId);
        Sms GetSms(int SmsId);
        Sms AddSms(Sms Sms);
        Sms UpdateSms(Sms Sms);
        void DeleteSms(int SmsId);
    }
}
