using Common;
using Entities;
using ArchiSolveApi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFrameWork.Api;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class ContentsController : BaseController
    {
        private readonly IRepository<Content> _repository;
        private readonly IMapper _mapper;
        private readonly IContentRepository contentRepository;
        private readonly IMediaRepository mediaRepository;

        public ContentsController(IContentRepository contentRepository, IRepository<Content> repository, IMediaRepository mediaRepository, IMapper mapper)
        {
            _repository = repository;
            this.contentRepository = contentRepository;
            this.mediaRepository = mediaRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ContentGridSelect>>> Get(CancellationToken cancellationToken)
        {
            var list = await contentRepository.GetContentsByPublishedStatus(true, cancellationToken).ProjectTo<ContentGridSelect>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ContentGridSelect>>> GetAll(CancellationToken cancellationToken)
        {
            var list = await contentRepository.GetContentsByPublishedStatus(null, cancellationToken).ProjectTo<ContentGridSelect>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<List<ContentGridSelect>>> Get(int top, CancellationToken cancellationToken)
        {
            List<ContentGridSelect> exportlist = new List<ContentGridSelect>();
            var list = await contentRepository.GetLastContents(top, true, cancellationToken).ProjectTo<ContentGridSelect>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            foreach (ContentGridSelect row in list)
            {
                var exportRow = row;
                var mediaRow = mediaRepository.GetByRefrenceId(row.Id, ObjectType.Content, MediaType.Image, SizeType.Title, cancellationToken);
                if (mediaRow.Count() > 0)
                {
                    exportRow.SourceFileName = mediaRow.First().SourceFileName;
                }
                exportlist.Add(exportRow);
            }
            return Ok(exportlist);
        }


        [HttpGet("details/{id:int}")]
        public async Task<ApiResult<ContentSelectDto>> GetDetails(int id, ObjectType type, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking
                //.Include(e => e.Medias.Where(p => p.ReferenceId == id))
                .ProjectTo<ContentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id && p.IsPublished == true, cancellationToken);

            var mediaRow = mediaRepository.GetByRefrenceId(id, ObjectType.Content, MediaType.Image, SizeType.Title, cancellationToken);
            if (mediaRow.Count() > 0)
            {
                dto.BodyImage = mediaRow.First().SourceFileName;
            }

            if (dto == null)
                return NotFound();
            return dto;
        }


        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<ContentSelectDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<ContentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (dto == null)
                return NotFound();
            

            return dto;
        }



        [HttpPost("create")]
       
        public async Task<ApiResult<ContentSelectDto>> Create(ContentSelectDto dto, CancellationToken cancellationToken)
        {
            var date = System.DateTime.Now;
            dto.PublishedDateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<ContentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]
       
        public async Task<ApiResult<ContentSelectDto>> Update([FromBody] ContentSelectDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            dto.PublishedDateTime = model.PublishedDateTime.Value;

            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<ContentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{contentid:int}")]
        public async Task<ApiResult> Delete(int contentId, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, contentId);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}
