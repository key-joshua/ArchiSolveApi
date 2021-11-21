using ArchiSolveApi.Models;
using AutoMapper;
using Data.Repositories;
using Entities;
using WebFramework.Api;

namespace ArchiSolveApi.Controllers.v1
{
    public class SectionsController : CrudController<SectionDto, SectionSelectDto, Section, int>
    {
        public SectionsController(IRepository<Section> repository, IMapper mapper)
             : base(repository, mapper)
        {
        }
    }
}
