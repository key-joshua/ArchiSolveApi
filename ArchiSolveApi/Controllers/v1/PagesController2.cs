using ArchiSolveApi.Models;
using AutoMapper;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace ArchiSolveApi.Controllers.v1
{
    public class PagesController2 : CrudController<PageDto, PageSelectDto, Page, int>
    {
        public PagesController2(IRepository<Page> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
