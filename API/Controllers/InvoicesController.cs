
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InvoicesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InvoicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<InvoiceDto>>> GetInvoices(
            [FromQuery] InvoiceSpecParams invoiceSpecParams
        )
        {
            var spec = new InvoiceWithDetailsSpecification(invoiceSpecParams);

            var countSpec = new InvoiceWithFiltersForCountSpecification(invoiceSpecParams);
            var totalItems = await _unitOfWork.Repository<Invoice>().CountAsync(countSpec);

            var invoices = await _unitOfWork.Repository<Invoice>().ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<InvoiceDto>>(invoices);

            return Ok(new Pagination<InvoiceDto>(invoiceSpecParams.PageIndex,
                invoiceSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoice(int id)
        {
            var spec = new InvoiceWithDetailsSpecification(id);

            var invoice = await _unitOfWork.Repository<Invoice>().GetEntityWithSpec(spec);

            if (invoice == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Invoice, InvoiceDto>(invoice);

        }
    }
}