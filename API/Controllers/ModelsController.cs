
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ModelsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ModelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ModelDto>>> GetModels()
        {
            var spec = new ModelWithBrandSpecification();
            var models = await _unitOfWork.Repository<Model>().ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<ModelDto>>(models);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModelDto>> GetModel(int id)
        {
            var spec = new ModelWithBrandSpecification(id);
            var model = await _unitOfWork.Repository<Model>().GetEntityWithSpec(spec);
            var data = _mapper.Map<ModelDto>(model);

            return Ok(data);

        }
    }
}