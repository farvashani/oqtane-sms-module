using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Tres.Smss.Models;
using Tres.Smss.Repository;

namespace Tres.Smss.Modules
{
    public class SmsManager : IPortable
    {
        private ISmsRepository _Smss;

        public SmsManager(ISmsRepository Smss)
        {
            _Smss = Smss;
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Sms> Smss = _Smss.GetSmss(module.ModuleId).ToList();
            if (Smss != null)
            {
                content = JsonSerializer.Serialize(Smss);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Sms> Smss = null;
            if (!string.IsNullOrEmpty(content))
            {
                Smss = JsonSerializer.Deserialize<List<Sms>>(content);
            }
            if (Smss != null)
            {
                foreach(Sms Sms in Smss)
                {
                    Sms _Sms = new Sms();
                    _Sms.ModuleId = module.ModuleId;
                    _Sms.Name = Sms.Name;
                    _Smss.AddSms(_Sms);
                }
            }
        }
    }
}