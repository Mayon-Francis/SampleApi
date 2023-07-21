using SampleApi.Models;

namespace SampleApi.Dtos {
    public class AddContactDto {

        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}