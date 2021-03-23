using Core.Database;
using Microsoft.EntityFrameworkCore;

namespace LotteryDemo.Database.DbContext
{
    public class LotteryDemoDbContextFactory : AbstractDbContextFactory<LotteryDemoDbContext>
    {

        protected override LotteryDemoDbContext CreateNewInstance(
            DbContextOptions<LotteryDemoDbContext> options)
        {
            return new LotteryDemoDbContext(options);
        }
    }
}
