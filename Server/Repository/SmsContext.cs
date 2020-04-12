using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Tres.Smss.Models;

namespace Tres.Smss.Repository
{
    public class SmsContext : DBContextBase, IService
    {
        public virtual DbSet<Sms> Sms { get; set; }

        public SmsContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
