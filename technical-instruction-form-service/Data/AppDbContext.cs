using Microsoft.EntityFrameworkCore;
using technical_instruction_form_service.Models;

namespace technical_instruction_form_service.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<TechnicalInstruction> TechnicalInstructions { get; set; }
    }
}
