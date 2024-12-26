using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DiaryApp.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

         public DbSet<DiaryEntry> DiaryEntries { get; set; }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<DiaryEntry>().HasData(
             new DiaryEntry { 
                 Id =1, 
                 Title="Went Hiking", 
                 Content="Hiking inamo", 
                 Created=DateTime.Now},

             new DiaryEntry {
                 Id = 2,
                 Title = "Went Joging", 
                 Content = "Jogs", 
                 Created = DateTime.Now }

             );
     }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }*/

    }
}
 