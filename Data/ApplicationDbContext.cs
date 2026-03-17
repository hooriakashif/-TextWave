using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TextWave.Models;
namespace TextWave.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<PricingPlan> PricingPlans { get; set; }
        public DbSet<TextWave.Models.Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
