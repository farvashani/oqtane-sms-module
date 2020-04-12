using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.Smss.Models;
using Tres.Smss.Repository;

namespace Tres.Smss.Controllers
{
    [Route("{site}/api/[controller]")]
    public class SmsController : Controller
    {
        private readonly ISmsRepository _Smss;
        private readonly ILogManager _logger;

        public SmsController(ISmsRepository Smss, ILogManager logger)
        {
            _Smss = Smss;
            _logger = logger;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Roles = Constants.RegisteredRole)]
        public IEnumerable<Sms> Get(string moduleid)
        {
            return _Smss.GetSmss(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = Constants.RegisteredRole)]
        public Sms Get(int id)
        {
            return _Smss.GetSms(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public Sms Post([FromBody] Sms Sms)
        {
            if (ModelState.IsValid)
            {
                Sms = _Smss.AddSms(Sms);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Sms Added {Sms}", Sms);
            }
            return Sms;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public Sms Put(int id, [FromBody] Sms Sms)
        {
            if (ModelState.IsValid)
            {
                Sms = _Smss.UpdateSms(Sms);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Sms Updated {Sms}", Sms);
            }
            return Sms;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public void Delete(int id)
        {
            _Smss.DeleteSms(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Sms Deleted {SmsId}", id);
        }
    }
}
