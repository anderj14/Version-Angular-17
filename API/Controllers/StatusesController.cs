
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatusesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StatusesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StatusDto>>> GetStatuses()
        {
            var statuses = await _unitOfWork.Repository<Status>().ListAllAsync();
            var data = _mapper.Map<IReadOnlyList<StatusDto>>(statuses);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        {
            var status = await _unitOfWork.Repository<Status>().GetByIdAsync(id);
            var data = _mapper.Map<StatusDto>(status);
            return Ok(data);
        }
    }
}