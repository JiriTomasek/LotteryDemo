using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Microsoft.VisualBasic;

namespace LotteryDemo.Entities
{
    public class Draw : BaseEntity
    {
        [Required]
        public DateTime DrawDateTime { get; set; }
        [Required]
        public int DrawNumber1 { get; set; }
        [Required]
        public int DrawNumber2 { get; set; }
        [Required]
        public int DrawNumber3 { get; set; }
        [Required]
        public int DrawNumber4 { get; set; }
        [Required]
        public int DrawNumber5 { get; set; }
    }
}