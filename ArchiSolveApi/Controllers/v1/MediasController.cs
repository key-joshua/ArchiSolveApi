using ArchiSolveApi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFrameWork.Api;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class MediasController : BaseController
    {
        private readonly IRepository<Media> _repository;
        private readonly IMapper _mapper;
        private readonly IMediaRepository mediaRepository;

        public MediasController(IMediaRepository mediaRepository, IRepository<Media> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this.mediaRepository = mediaRepository;
        }


        [HttpGet("listmedias/{type}/{refid}")]
        public async Task<ActionResult<List<MediaSelectDto>>> GetAll(ObjectType type, int refId, CancellationToken cancellationToken)
        {
            var list = await mediaRepository.GetObjectMedias(type, refId, cancellationToken).ProjectTo<MediaSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }


        //[HttpGet("getmedias/{type}")]
        //public async Task<ActionResult<List<MediaSelectDto>>> Get(MediaType type, CancellationToken cancellationToken)
        //{
        //    var list = await mediaRepository.GetMediasByType(type, true, cancellationToken).ProjectTo<MediaSelectDto>(_mapper.ConfigurationProvider)
        //        .ToListAsync(cancellationToken);
        //    return Ok(list);
        //}


        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<MediaDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<MediaDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (dto == null)
                return NotFound();
            return dto;
        }

        [HttpPost("create")]

        public async Task<ApiResult<MediaSelectDto>> Create(MediaDto dto, CancellationToken cancellationToken)
        {
            //var objectType = byte.Parse(dto.ObjectType);
            //var refId = int.Parse(dto.ReferenceId);
            //var addDto = new MediaDto
            //{
            //    Title = dto.Title,
            //    ObjectType = (ObjectType?)objectType,
            //    ReferenceId = refId,
            //    ShortDescription = dto.ShortDescription,
            //    SourceFileName = dto.SourceFileName
            //};

            var model = dto.ToEntity(_mapper);

            model.MediaType = MediaType.Image;
            model.SizeType = SizeType.Title;

            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<MediaSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]

        public async Task<ApiResult<MediaSelectDto>> Update([FromBody] MediaDto dto, CancellationToken cancellationToken)
        {
            //var objectType = byte.Parse(dto.ObjectType);
            //var refId = int.Parse(dto.ReferenceId);
            //var addDto = new MediaDto
            //{
            //    Id = dto.Id,
            //    Title = dto.Title,
            //    ObjectType = (ObjectType?)objectType,
            //    ReferenceId = refId,
            //    ShortDescription = dto.ShortDescription,
            //    SourceFileName = dto.SourceFileName
            //};


            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<MediaSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{id:int}")]

        public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, id);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }


        [HttpPost("upload")]
        public ActionResult Upload([FromForm] FileModel file)
        {
            try
            {

                string path = string.Empty;
                switch(file.ObjectType)
                {
                    case "1":
                        path = @"C:\(E)\TopFinance\ReactWebsite\exomac\public\images\page\" + file.FileName;
                        break;
                    case "2":
                       path = @"C:\(E)\TopFinance\ReactWebsite\exomac\public\images\blog\" + file.FileName;
                        break;
                    case "8":
                       path = @"C:\(E)\TopFinance\ReactWebsite\exomac\public\images\banner\" + file.FileName;
                        break;
                    case "9":
                        //path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);
                       path = @"C:\(E)\TopFinance\ReactWebsite\exomac\public\images\loan\" + file.FileName;
                        break;
                }
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
