using SampleApi.Models;

namespace SampleApi.Dtos {
    public class AddContactDto {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}