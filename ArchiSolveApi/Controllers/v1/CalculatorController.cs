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
    public class CalculatorsController : BaseController
    {
        private readonly IRepository<Calculator> _repository;
        private readonly IMapper _mapper;
        private readonly ICalculatorRepository calculatorRepository;

        public CalculatorsController(ICalculatorRepository calculatorRepository, IRepository<Calculator> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this.calculatorRepository = calculatorRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<CalculatorDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await calculatorRepository.GetCalculatorsByPublishedStatus(true, cancellationToken).ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CalculatorDto>>> GetAll(CancellationToken cancellationToken)
        {
            var list = await calculatorRepository.GetCalculatorsByPublishedStatus(null, cancellationToken).ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }


        

        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<CalculatorDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
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

      
        [HttpPost("create")]
       
        public async Task<ApiResult<CalculatorDto>> Create([FromBody] CalculatorDto dto, CancellationToken cancellationToken)
        {
            var oldCalculator = await _repository.TableNoTracking.ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
            if (oldCalculator != null)
            {
                return BadRequest("A calculator with the same code exist.");
            }

            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]
       
        public async Task<ApiResult<CalculatorDto>> Update([FromBody] CalculatorDto dto, CancellationToken cancellationToken)
        {
            var oldCalculator = await _repository.TableNoTracking.ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
              .SingleOrDefaultAsync(p => p.Code == dto.Code, cancellationToken);
            if (oldCalculator != null)
            {
                if (oldCalculator.Id != dto.Id)
                {
                    return BadRequest("A calculator with the same code exist.");
                }
            }

            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<CalculatorDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{calculatorid:int}")]
       
        public async Task<ApiResult> Delete(int calculatorId, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, calculatorId);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}
