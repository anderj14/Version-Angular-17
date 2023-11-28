
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InsurancesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsurancesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InsuranceDto>>> GetInsurances()
        {
            var insurances = await _unitOfWork.Repository<Insurance>().ListAllAsync();
            var data = _mapper.Map<IReadOnlyList<InsuranceDto>>(insurances);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceDto>> GetInsurance(int id)
        {
            var insurance = await _unitOfWork.Repository<Insurance>().GetByIdAsync(id);
            var data = _mapper.Map<InsuranceDto>(insurance);

            return Ok(data);

        }
    }
}