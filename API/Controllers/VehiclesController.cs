
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Dtos;
using Core.Dtos.VehiclesDtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VehiclesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<VehicleDto>>> GetVehicles(
            [FromQuery] VehicleSpecParams vehicleSpecParams
        )
        {
            var spec = new VehicleWithAllSpecification(vehicleSpecParams);

            var countSpec = new VehicleWithFiltersForCountSpecification(vehicleSpecParams);
            var totalItems = await _unitOfWork.Repository<Vehicle>().CountAsync(countSpec);

            var vehicles = await _unitOfWork.Repository<Vehicle>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<VehicleDto>>(vehicles);

            return Ok(new Pagination<VehicleDto>(vehicleSpecParams.PageIndex,
            vehicleSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VehicleDto>> GetVehicle(int id)
        {
            var spec = new VehicleWithAllSpecification(id);

            var vehicle = await _unitOfWork.Repository<Vehicle>().GetEntityWithSpec(spec);

            if (vehicle == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Vehicle, VehicleDto>(vehicle);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Vehicle>> CreateVehicle(CreateVehicleDto createVehicle)
        {
            var vehicle = _mapper.Map<CreateVehicleDto, Vehicle>(createVehicle);

            _unitOfWork.Repository<Vehicle>().Add(vehicle);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem creating vehicle item"));

            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Vehicle>> UpdateVehicle(int id, CreateVehicleDto updateVehicle)
        {
            var vehicle = await _unitOfWork.Repository<Vehicle>().GetByIdAsync(id);

            _mapper.Map(updateVehicle, vehicle);

            _unitOfWork.Repository<Vehicle>().Update(vehicle);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem updating vehicle"));

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _unitOfWork.Repository<Vehicle>().GetByIdAsync(id);

            _unitOfWork.Repository<Vehicle>().Delete(vehicle);

            var result = await _unitOfWork.Complete();

            if (result <= 0) return BadRequest(new ApiResponse(400, "Problem deleting vehicle"));

            return Ok();
        }
    }
}