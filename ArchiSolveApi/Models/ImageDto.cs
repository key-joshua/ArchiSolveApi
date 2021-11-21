using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string ObjectType { get; set; }
        public IFormFile FormFile { get; set; }
        //public List<IFormFile> FormFiles { get; set; }
    }

}
