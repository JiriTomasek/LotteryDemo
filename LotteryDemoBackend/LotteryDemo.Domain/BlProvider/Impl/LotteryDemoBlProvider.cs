using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.DAO;
using Core.Validation.Impl;
using Core.Validation.Interface;
using LotteryDemo.Domain.BlProvider.Interface;
using LotteryDemo.Entities;

namespace LotteryDemo.Domain.BlProvider.Impl
{
    public class LotteryDemoBlProvider : ILotteryDemoBlProvider
    {
        private readonly ICommonDao<Draw> _drawDao;

        public LotteryDemoBlProvider(IBaseDaoFactory daoFactory)
        {
            _drawDao = daoFactory.GetDao<Draw>();
        }
        

        public IValidationResult SaveDraw(Draw draw)
        {
            try
            {
                _drawDao.AddItem(draw);
                return ValidationResult.ResultOk();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ValidationResult.ResultFailed(e.Message);
            }
        }

        public IEnumerable<Draw> GetHistoryDraw()
        {
            try
            {
                return _drawDao.GetCollection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}