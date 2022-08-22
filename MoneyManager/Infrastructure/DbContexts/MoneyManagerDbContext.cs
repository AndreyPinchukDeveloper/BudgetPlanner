using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.DTOs;

namespace MoneyManager.Infrastructure.DbContexts
{
    public class MoneyManagerDbContext:DbContext
    {
        //DbSet - remote collection(not from memory) behold separate table to us
        public DbSet<OperationDTO> Operations { get; set; }

        public MoneyManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        //we can redefine the method OnConfiguring to define
        //which db we want to bind with our context
    }
}
