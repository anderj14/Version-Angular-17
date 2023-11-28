using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class VehiclesTypeController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<VehicleTypeDto>>> GetVehicleTypes()
        {
            var vehiclesType = await _unitOfWork.Repository<VehicleType>().ListAllAsync();
            var data = _mapper.Map<IReadOnlyList<VehicleTypeDto>>(vehiclesType);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTypeDto>> GetVehicleType(int id)
        {
            var vehicleType = await _unitOfWork.Repository<VehicleType>().GetByIdAsync(id);
            var data = _mapper.Map<VehicleTypeDto>(vehicleType);

            return Ok(data);

        }
    }
}