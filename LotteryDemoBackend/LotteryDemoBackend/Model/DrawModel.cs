using System;
using System.ComponentModel.DataAnnotations;

namespace LotteryDemoBackend.Model
{
    public class DrawModel
    {
        public DateTime DrawDateTime { get; set; }
        [Range(1,50)]
        public int DrawNumber1 { get; set; }
        [Range(1, 50)]
        public int DrawNumber2 { get; set; }
        [Range(1, 50)]
        public int DrawNumber3 { get; set; }
        [Range(1, 50)]
        public int DrawNumber4 { get; set; }
        [Range(1, 50)]
        public int DrawNumber5 { get; set; }
    }
}