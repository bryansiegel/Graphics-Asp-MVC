using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Graphics_Asp_MVC.Models;

namespace Graphics_Asp_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Graphics_Asp_MVC.Models.FormDownload> FormDownload { get; set; } = default!;
        public DbSet<Graphics_Asp_MVC.Models.IndexOfForms> IndexOfForms { get; set; } = default!;
        public DbSet<Graphics_Asp_MVC.Models.SiteBasedContracts> SiteBasedContracts { get; set; } = default!;
        public DbSet<Graphics_Asp_MVC.Models.CurrentEvaluations> CurrentEvaluations { get; set; } = default!;
    }
}
