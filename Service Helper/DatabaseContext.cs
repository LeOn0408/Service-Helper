using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Service_Helper
{
    class DatabaseContext : DbContext
    {
        public DbSet<CheckList> CheckLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=servicehelper.db");
        }
        
    }
}
