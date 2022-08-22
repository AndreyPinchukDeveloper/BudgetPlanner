using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Infrastructure.DbContexts
{
    public class MoneyManagerDbContextFactory
    {
        private readonly string _connectionString;
        public MoneyManagerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MoneyManagerDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new MoneyManagerDbContext(options);
        }
    }
}
