using SampleApi.Services.Interfaces;

namespace SampleApi.Helpers
{
    public class StartupHelper
    {
        private readonly IEnvironmentService _environmentService;
        public StartupHelper(IEnvironmentService environmentService)
        {
            _environmentService = environmentService;
        }
    }
}