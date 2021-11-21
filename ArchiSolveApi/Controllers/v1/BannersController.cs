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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFrameWork.Api;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]

    public class BannersController : BaseController
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        private readonly IBannerRepository bannerRepository;
        private readonly IMediaRepository mediaRepository;

        public BannersController(IBannerRepository bannerRepository, IRepository<Banner> repository, IMediaRepository mediaRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this.mediaRepository = mediaRepository;
            this.bannerRepository = bannerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BannerSelectDto>>> Get(CancellationToken cancellationToken)
        {


            var list = await _repository.TableNoTracking.ProjectTo<BannerSelectDto>(_mapper.ConfigurationProvider)
                //.Where(postDto => postDto.Title.Contains("test") || postDto.CategoryName.Contains("test"))
                .ToListAsync(cancellationToken);

            return Ok(list);
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<List<BannerDto>>> Get(int top, CancellationToken cancellationToken)
        {
            List<BannerDto> exportlist = new List<BannerDto>();
            var list = await _repository.TableNoTracking.ProjectTo<BannerDto>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);
            foreach (BannerDto row in list)
            {
                var exportRow = row;
                var mediaRow = mediaRepository.GetByRefrenceId(row.Id, ObjectType.Banner, MediaType.Image, SizeType.Title, cancellationToken);
                if (mediaRow.Count() > 0)
                {
                    exportRow.SourceFileName = mediaRow.First().SourceFileName;
                }
                exportlist.Add(exportRow);
            }
            return Ok(exportlist);
        }



        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<BannerSelectDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<BannerSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (dto == null)
                return NotFound();
            return dto;
        }

        [HttpPost("create")]
       
        public async Task<ApiResult<BannerSelectDto>> Create([FromBody] BannerDto dto, CancellationToken cancellationToken)
        {

            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<BannerSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]
       
        public async Task<ApiResult<BannerSelectDto>> Update([FromBody] BannerDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<BannerSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{bannerid:int}")]
       
        public async Task<ApiResult> Delete(int bannerId, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, bannerId);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}
