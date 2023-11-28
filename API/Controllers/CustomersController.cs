
using API.Helpers;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<CustomerDto>>> GetCustomers(
            [FromQuery]CustomerSpecParams customerSpecParams)
        {
            var countSpec = new CustomerWithFilterForCountSpecification(customerSpecParams);

            var totalItems = await _unitOfWork.Repository<Customer>().CountAsync(countSpec);
            var models = await _unitOfWork.Repository<Customer>().ListAllAsync();

            var data = _mapper.Map<IReadOnlyList<CustomerDto>>(models);

            return Ok(new Pagination<CustomerDto>(customerSpecParams.PageIndex,
            customerSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var model = await _unitOfWork.Repository<Customer>().GetByIdAsync(id);
            var data = _mapper.Map<CustomerDto>(model);

            return Ok(data);

        }
    }
}