using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MoneyManager.Infrastructure.DbContexts
{
    /// <summary>
    /// We need class to implement IDesignTimeDbContextFactory<T> - it is our context
    /// to create a Migrations
    /// </summary>
    public class MoneyManagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoneyManagerDbContext>
    {
        public MoneyManagerDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=Reservoom.db").Options;
            return new MoneyManagerDbContext(options);
        }
    }
}
