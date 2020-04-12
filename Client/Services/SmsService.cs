using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Tres.Smss.Models;

namespace Tres.Smss.Services
{
    public class SmsService : ServiceBase, ISmsService, IService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly SiteState _siteState;

        public SmsService(HttpClient http, SiteState siteState, NavigationManager navigationManager)
        {
            _http = http;
            _siteState = siteState;
            _navigationManager = navigationManager;
        }

         private string Apiurl
        {
            get { return CreateApiUrl(_siteState.Alias, _navigationManager.Uri, "Sms"); }
        }

        public async Task<List<Sms>> GetSmssAsync(int ModuleId)
        {
            List<Sms> Smss = await _http.GetJsonAsync<List<Sms>>(Apiurl + "?moduleid=" + ModuleId.ToString());
            return Smss.OrderBy(item => item.Name).ToList();
        }

        public async Task<Sms> GetSmsAsync(int SmsId)
        {
            return await _http.GetJsonAsync<Sms>(Apiurl + "/" + SmsId.ToString());
        }

        public async Task<Sms> AddSmsAsync(Sms Sms)
        {
            return await _http.PostJsonAsync<Sms>(Apiurl + "?entityid=" + Sms.ModuleId, Sms);
        }

        public async Task<Sms> UpdateSmsAsync(Sms Sms)
        {
            return await _http.PutJsonAsync<Sms>(Apiurl + "/" + Sms.SmsId + "?entityid=" + Sms.ModuleId, Sms);
        }

        public async Task DeleteSmsAsync(int SmsId)
        {
            await _http.DeleteAsync(Apiurl + "/" + SmsId.ToString());
        }
    }
}
