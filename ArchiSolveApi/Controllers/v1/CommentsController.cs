using ArchiSolveApi.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFrameWork.Api;

namespace ArchiSolveApi.Controllers.v1
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CommentsController : BaseController
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        private readonly ICommentRepository commentRepository;

        public CommentsController(ICommentRepository commentRepository, IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            this.commentRepository = commentRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<CommentSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var list = await commentRepository.GetCommentsByPublishedStatus(true, cancellationToken).ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CommentSelectDto>>> GetAll(CancellationToken cancellationToken)
        {
            var list = await commentRepository.GetCommentsByPublishedStatus(null, cancellationToken).ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("{top}")]
        public async Task<ActionResult<List<CommentSelectDto>>> Get(int top, CancellationToken cancellationToken)
        {
            var list = await commentRepository.GetLastComments(top, true, cancellationToken).ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return Ok(list);
        }

        [HttpGet("single/{id:int}")]
        public async Task<ApiResult<CommentSelectDto>> Single(int id, CancellationToken cancellationToken)
        {
            var dto = await _repository.TableNoTracking.ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (dto == null)
                return NotFound();
            return dto;
        }


        [HttpPost("create")]
       
        public async Task<ApiResult<CommentSelectDto>> Create([FromBody] CommentDto dto, CancellationToken cancellationToken)
        {
            var model = dto.ToEntity(_mapper);
            await _repository.AddAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpPost("edit")]
       
        public async Task<ApiResult<CommentSelectDto>> Update([FromBody] CommentDto dto, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, dto.Id);
            model = dto.ToEntity(_mapper, model);
            await _repository.UpdateAsync(model, cancellationToken);
            var resultDto = await _repository.TableNoTracking.ProjectTo<CommentSelectDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == model.Id, cancellationToken);
            return resultDto;
        }

        [HttpDelete("delete/{commentid:int}")]
        public async Task<ApiResult> Delete(int commentId, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(cancellationToken, commentId);
            await _repository.DeleteAsync(model, cancellationToken);

            return Ok();
        }
    }
}
