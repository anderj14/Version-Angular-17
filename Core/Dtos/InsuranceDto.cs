using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class InsuranceDto
    {
        public int Id { get; set; }

        public string InsuranceName { get; set; }
        public decimal InsurancePrice { get; set; }
    }
}