
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FuelsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FuelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FuelDto>>> GetFuels()
        {
            var fuels = await _unitOfWork.Repository<Fuel>().ListAllAsync();
            var data = _mapper.Map<IReadOnlyList<FuelDto>>(fuels);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuelDto>> GetFuel(int id)
        {
            var fuel = await _unitOfWork.Repository<Fuel>().GetByIdAsync(id);
            var data = _mapper.Map<FuelDto>(fuel);
            return Ok(data);
        }
    }
}