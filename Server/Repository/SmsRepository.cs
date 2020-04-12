using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Tres.Smss.Models;

namespace Tres.Smss.Repository
{
    public class SmsRepository : ISmsRepository, IService
    {
        private readonly SmsContext _db;

        public SmsRepository(SmsContext context)
        {
            _db = context;
        }

        public IEnumerable<Sms> GetSmss(int ModuleId)
        {
            return _db.Sms.Where(item => item.ModuleId == ModuleId);
        }

        public Sms GetSms(int SmsId)
        {
            return _db.Sms.Find(SmsId);
        }

        public Sms AddSms(Sms Sms)
        {
            _db.Sms.Add(Sms);
            _db.SaveChanges();
            return Sms;
        }

        public Sms UpdateSms(Sms Sms)
        {
            _db.Entry(Sms).State = EntityState.Modified;
            _db.SaveChanges();
            return Sms;
        }

        public void DeleteSms(int SmsId)
        {
            Sms Sms = _db.Sms.Find(SmsId);
            _db.Sms.Remove(Sms);
            _db.SaveChanges();
        }
    }
}
