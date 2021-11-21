using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class LoanDto : BaseDto<LoanDto, Loan, int>
    {
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public LoanType? LoanType { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string SourceFileName { get; set; }
        public string Resources { get; set; }
        public string ExtraDescription { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string Culture { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
    }

    public class LoanSelectDto : BaseDto<LoanSelectDto, Loan, int>
    {
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public LoanType? LoanType { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string SourceFileName { get; set; }
        public bool? IsPublished { get; set; }
        public string ExtraDescription { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
    }
}
