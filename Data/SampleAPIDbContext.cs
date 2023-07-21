using Microsoft.EntityFrameworkCore;
using SampleApi.Models;
namespace SampleApi.Data {
    public class SampleAPIDbContext: DbContext {

        public SampleAPIDbContext(DbContextOptions<SampleAPIDbContext> options): base(options) {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}