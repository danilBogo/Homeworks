using Microsoft.EntityFrameworkCore;

namespace Homework10.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<CalculatorExpression> Expressions { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}