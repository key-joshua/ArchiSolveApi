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
    public class LoansController : BaseController
    {
        private readonly IRepository<Loan> _repository;
        private readonly IMapper _mapper;
        private readonly ILoanRepository loanRepository;
        private readonly IMediaRepository mediaRepository;

        public LoansController(ILoanRepository loanRepository, IRepository<Loan> repository, IMediaRepository mediaRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this.mediaRepository = mediaRepository;
            this.loanRepository = loanRepository;
        }


        [HttpGet("listloans/{type}")]
        public async Task<ActionResult<List<LoanSelectDto>>> GetAll(LoanType type, CancellationToken cancellationToken)
        {
            var list = await loanRepository.GetLoansByType(type, null, cancellationToken).ProjectTo<LoanSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }


        [HttpGet("getloans/{type}")]
        public async Task<ActionResult<List<LoanSelectDto>>> Get(LoanType type, CancellationToken cancellationToken)
        {
            var list = await loanRepository.GetLoansByType(type, true, cancellationToken).ProjectTo<LoanSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }


        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<LoanSelectDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<LoanSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            var mediaRow = mediaRepository.GetByRefrenceId(id, ObjectType.Loan, MediaType.Image, SizeType.Title, cancellationToken);
            if (mediaRow.Count() > 0)
            {
                dto.SourceFileName = mediaRow.First().SourceFileName;
            }

            if (dto == null)
                return NotFound();
            return dto;
        }

        [HttpPost("create")]
       
        public async Task<ApiResult<LoanSelectDto>> Create(LoanDto dto, CancellationToken cancellationToken)
        {
            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<LoanSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }


        [HttpPost("edit")]
       
        public async Task<ApiResult<LoanSelectDto>> Update(LoanDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<LoanSelectDto>(_mapper.ConfigurationProvider)
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
    }
}
