namespace SampleApi.Services.Interfaces {
    public interface IEnvironmentService {
        public string POSTGRES_DB { get; set; }
        public string POSTGRES_USER { get; set; }
        public string POSTGRES_PASSWORD { get; set; }
        public string POSTGRES_HOST { get; set; }
        public string POSTGRES_PORT { get; set; }

        public string POSTGRES_CONNECTION_STRING { get; }
    }
}