using Oqtane.Models;
using Oqtane.Modules;

namespace Tres.Smss.Modules
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Sms",
            Description = "Sms",
            Version = "1.0.0",
            Dependencies = "Tres.Smss.Module.Shared",
            ServerAssemblyName = "Tres.Smss.Module.Server"
        };
    }
}
