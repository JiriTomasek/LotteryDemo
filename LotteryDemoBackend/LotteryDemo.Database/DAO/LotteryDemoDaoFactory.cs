using Core.Database.DAO;
using Core.Entities.DAO;
using LotteryDemo.Database.DbContext;

namespace LotteryDemo.Database.DAO
{
    public class LotteryDemoDaoFactory : IBaseDaoFactory
    {
        private readonly LotteryDemoDbContext _context;

        public LotteryDemoDaoFactory(LotteryDemoDbContext context)
        {
            _context = context;
        }

        public ICommonDao<T> GetDao<T>() where T : class
        {
            return new CommonDao<T>(_context);
        }

        public ICommonDao<T> GetDifferentContextDao<T>() where T : class
        {
            return new CommonDao<T>(new LotteryDemoDbContextFactory().Create());
        }
    }
}