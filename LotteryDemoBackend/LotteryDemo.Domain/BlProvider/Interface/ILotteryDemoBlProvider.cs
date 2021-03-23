using System.Collections.Generic;
using Core.Validation.Interface;
using LotteryDemo.Entities;

namespace LotteryDemo.Domain.BlProvider.Interface
{
    public interface ILotteryDemoBlProvider
    {
        IValidationResult SaveDraw(Draw draw);
        IEnumerable<Draw> GetHistoryDraw();
    }
}