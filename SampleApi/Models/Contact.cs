namespace SampleApi.Models {
    public class Contact {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; }  = default!;
        public string Address { get; set; } = default!;
    }
}