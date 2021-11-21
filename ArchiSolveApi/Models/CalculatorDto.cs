using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class CalculatorDto : BaseDto<CalculatorDto, Calculator, int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public CalculatorType? CalculatorType { get; set; }
        public string Icon { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public string Culture { get; set; }
    }
    public class CalculatorSelectDto : BaseDto<CalculatorSelectDto, Calculator, int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
    }



}
