using LotteryDemo.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LotteryDemo.Database.DbContext
{
    public class LotteryDemoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LotteryDemoDbContext()
        {
        }
        
        public LotteryDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Draw> DrawHistory { get; set; }

       
    }
}