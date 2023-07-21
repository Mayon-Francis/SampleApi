using SampleApi.Services.Interfaces;

namespace SampleApi.Services
{
    public class EnvironmentService: IEnvironmentService
    {
        public string POSTGRES_DB { get; set; } = default!;
        public string POSTGRES_USER { get; set; } = default!;
        public string POSTGRES_PASSWORD { get; set; } = default!;
        public string POSTGRES_HOST { get; set; } = default!;
        public string POSTGRES_PORT { get; set; } = default!;

        public string POSTGRES_CONNECTION_STRING
        {
            get
            {
                return $"Host={POSTGRES_HOST};Port={POSTGRES_PORT};Database={POSTGRES_DB};Username={POSTGRES_USER};Password={POSTGRES_PASSWORD}";
            }
        }

        public EnvironmentService()
        {
            string? Database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            string? User = Environment.GetEnvironmentVariable("POSTGRES_USER");
            string? Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            string? Host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            string? Port = Environment.GetEnvironmentVariable("POSTGRES_PORT");

            List<string> missingEnvs = new List<string>();
            if (string.IsNullOrEmpty(Database))
                missingEnvs.Add("POSTGRES_DB");
            if (string.IsNullOrEmpty(User))
                missingEnvs.Add("POSTGRES_USER");
            if (string.IsNullOrEmpty(Password))
                missingEnvs.Add("POSTGRES_PASSWORD");
            if (string.IsNullOrEmpty(Host))
                missingEnvs.Add("POSTGRES_HOST");
            if (string.IsNullOrEmpty(Port))
                missingEnvs.Add("POSTGRES_PORT");

            if (missingEnvs.Count() > 0)
            {
                throw new Exception($"Missing environment variables: {string.Join(", ", missingEnvs)}");
            }
            else
            {
                POSTGRES_DB = Database!;
                POSTGRES_USER = User!;
                POSTGRES_PASSWORD = Password!;
                POSTGRES_HOST = Host!;
                POSTGRES_PORT = Port!;
            }
        }
    }
}