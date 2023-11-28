using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class InvoiceSpecParams
    {

        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? CustomerId { get; set; }
        public int? ReservationId { get; set; }

        public DateTime? Date { get; set; }

        public string? Sort { get; set; }

        private string _search = string.Empty;
        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower() ?? string.Empty;
        }
    }
}