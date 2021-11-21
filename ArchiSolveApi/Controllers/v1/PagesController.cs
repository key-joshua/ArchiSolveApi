// using ArchiSolveApi.Models;
// using AutoMapper;
// using AutoMapper.QueryableExtensions;
// using Data.Repositories;
// using Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MyApi.Models;
// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using WebFramework.Api;
// using WebFrameWork.Api;

// namespace ArchiSolveApi.Controllers.v1
// {
//     [EnableCors("_myAllowSpecificOrigins")]
//     public class PagesController : BaseController
//     {
//         private readonly IRepository<Page> _repository;
//         private readonly IMapper _mapper;
//         private readonly IPageRepository pageRepository;

//         public PagesController(IPageRepository pageRepository, IRepository<Page> repository, IMapper mapper)
//         {
//             _repository = repository;
//             _mapper = mapper;
//             this.pageRepository = pageRepository;
//         }

//         [HttpGet]
//         public async Task<ActionResult<List<PageSelectDto>>> Get(CancellationToken cancellationToken)
//         {


//             var list = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 //.Where(postDto => postDto.Title.Contains("test") || postDto.CategoryName.Contains("test"))
//                 .ToListAsync(cancellationToken);

//             return Ok(list);
//         }



//         [HttpGet("{code}")]
//         public async Task<ApiResult<PageSelectDto>> Get(string code, CancellationToken cancellationToken)
//         {
//             var dto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 .SingleOrDefaultAsync(p => p.Code == code, cancellationToken);

//             //Post post = null; //Find from database by Id (include)
//             //var resultDto = PostDto.FromEntity(post);

//             if (dto == null)
//                 return NotFound();

//             //dto.Category = "My custom value, not from mapping!";

//             #region old code
//             //var dto = new PostDto
//             //{
//             //    Id = model.Id,
//             //    Title = model.Title,
//             //    Description = model.Description,
//             //    CategoryId = model.CategoryId,
//             //    AuthorId = model.AuthorId,
//             //    AuthorFullName = model.Author.FullName,
//             //    CategoryName = model.Category.Name
//             //};
//             #endregion

//             return dto;
//         }


//         [HttpGet("single/{id:int}")]
//         public async Task<ApiResult<PageSelectDto>> Single(int id, CancellationToken cancellationToken)
//         {
//             var dto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

//             //Post post = null; //Find from database by Id (include)
//             //var resultDto = PostDto.FromEntity(post);

//             if (dto == null)
//                 return NotFound();

//             //dto.Category = "My custom value, not from mapping!";

//             #region old code
//             //var dto = new PostDto
//             //{
//             //    Id = model.Id,
//             //    Title = model.Title,
//             //    Description = model.Description,
//             //    CategoryId = model.CategoryId,
//             //    AuthorId = model.AuthorId,
//             //    AuthorFullName = model.Author.FullName,
//             //    CategoryName = model.Category.Name
//             //};
//             #endregion

//             return dto;
//         }

//         [HttpGet("getchild/{parentId:int}")]
//         public async Task<ActionResult<List<PageSelectDto>>> Get(int parentId, CancellationToken cancellationToken)
//         {
//             var list = await pageRepository.GetPagesByParentId(parentId, true, cancellationToken).ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 .ToListAsync(cancellationToken);
//             return Ok(list);
//         }

//         [HttpPost("create")]
       
//         public async Task<ApiResult<PageSelectDto>> Create([FromBody] PageDto dto, CancellationToken cancellationToken)
//         {
//             var oldPage = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
//             if (oldPage != null)
//             {
//                 return BadRequest("A page with the same code exist.");
//             }

//             var model = dto.ToEntity(_mapper);
//             await _repository.AddAsync(model, cancellationToken);
//             var resultDto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
//             return resultDto;
//         }

//         [HttpPost("edit")]
       
//         public async Task<ApiResult<PageSelectDto>> Update([FromBody] PageDto dto, CancellationToken cancellationToken)
//         {
//             var oldPage = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//               .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
//             if (oldPage != null)
//             {
//                 if (oldPage.Id != dto.Id)
//                 {
//                     return BadRequest("A page with the same code exist.");
//                 }
//             }

//             var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
//             model = dto.ToEntity(_mapper, model);
//             await _repository.UpdateAsync(model, cancellationToken);
//             var resultDto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
//                 .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
//             return resultDto;
//         }

//         [HttpDelete("delete/{pageid:int}")]
       
//         public async Task<ApiResult> Delete(int pageId, CancellationToken cancellationToken)
//         {
//             var model = await _repository.GetByIdAsync(cancellationToken, pageId);
//             await _repository.DeleteAsync(model, cancellationToken);

//             return Ok();
//         }
//     }
// }


using ArchiSolveApi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFrameWork.Api;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class PagesController : BaseController
    {
        private readonly IRepository<Page> _repository;
        private readonly IMapper _mapper;
        private readonly IPageRepository pageRepository;

        public PagesController(IPageRepository pageRepository, IRepository<Page> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this.pageRepository = pageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PageSelectDto>>> Get(CancellationToken cancellationToken)
        {


            var list = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                //.Where(postDto => postDto.Title.Contains("test") || postDto.CategoryName.Contains("test"))
                .ToListAsync(cancellationToken);

            return Ok(list);
        }

        [HttpGet("test")]
        public ApiResult Test()
        {
            return Ok();
           
        }


        [HttpGet("{code}")]
        public async Task<ApiResult<PageSelectDto>> Get(string code, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Code == code, cancellationToken);

            //Post post = null; //Find from database by Id (include)
            //var resultDto = PostDto.FromEntity(post);

            if (dto == null)
                return NotFound();

            //dto.Category = "My custom value, not from mapping!";

            #region old code
            //var dto = new PostDto
            //{
            //    Id = model.Id,
            //    Title = model.Title,
            //    Description = model.Description,
            //    CategoryId = model.CategoryId,
            //    AuthorId = model.AuthorId,
            //    AuthorFullName = model.Author.FullName,
            //    CategoryName = model.Category.Name
            //};
            #endregion

            return dto;
        }


        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<PageSelectDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            //Post post = null; //Find from database by Id (include)
            //var resultDto = PostDto.FromEntity(post);

            if (dto == null)
                return NotFound();

            //dto.Category = "My custom value, not from mapping!";

            #region old code
            //var dto = new PostDto
            //{
            //    Id = model.Id,
            //    Title = model.Title,
            //    Description = model.Description,
            //    CategoryId = model.CategoryId,
            //    AuthorId = model.AuthorId,
            //    AuthorFullName = model.Author.FullName,
            //    CategoryName = model.Category.Name
            //};
            #endregion

            return dto;
        }

        [HttpGet("getchild/{parentId:int}")]
        public async Task<ActionResult<List<PageSelectDto>>> Get(int parentId, CancellationToken cancellationToken)
        {
            var list = await pageRepository.GetPagesByParentId(parentId, true, cancellationToken).ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpPost("create")]
       
        public async Task<ApiResult<PageSelectDto>> Create([FromBody] PageDto dto, CancellationToken cancellationToken)
        {
            var oldPage = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
            if (oldPage != null)
            {
                return BadRequest("A page with the same code exist.");
            }

            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]
       
        public async Task<ApiResult<PageSelectDto>> Update([FromBody] PageDto dto, CancellationToken cancellationToken)
        {
            var oldPage = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
              .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
            if (oldPage != null)
            {
                if (oldPage.Id != dto.Id)
                {
                    return BadRequest("A page with the same code exist.");
                }
            }

            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<PageSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{pageid:int}")]
       
        public async Task<ApiResult> Delete(int pageId, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, pageId);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}

