using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Core.Validation.Impl;
using LotteryDemo.Domain.BlProvider.Interface;
using LotteryDemo.Entities;
using LotteryDemoBackend.Model;
using Microsoft.AspNetCore.Cors;

namespace LotteryDemoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class DrawController : Controller
    {
        private readonly ILotteryDemoBlProvider _lotteryDemoBlProvider;

        public DrawController(ILotteryDemoBlProvider lotteryDemoBlProvider)
        {
            _lotteryDemoBlProvider = lotteryDemoBlProvider;
        }
        [HttpPost("SaveDraw")]
        public IActionResult SaveDraw([FromBody] DrawModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ValidationResult.ResultFailed($"Model is invalid. Errors count {ModelState.ErrorCount}"));
            try
            {
                var entity = MappingUtils.MapToNew<DrawModel, Draw>(data);
                var result = _lotteryDemoBlProvider.SaveDraw(entity);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(ValidationResult.ResultFailed(e.Message));
            }
            


        }
        [HttpGet("DrawHistory")]
        public IActionResult DrawHistory()
        {
            try
            {
                var list = _lotteryDemoBlProvider.GetHistoryDraw()
                    .Select(t => MappingUtils.MapToNew<Draw, DrawModel>(t)).ToList();
                return Json(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(ValidationResult.ResultFailed(e.Message));
            }

        }
    }
}
