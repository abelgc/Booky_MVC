using Microsoft.EntityFrameworkCore;

namespace BookyWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
