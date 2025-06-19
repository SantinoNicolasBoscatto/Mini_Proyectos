using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Mappers.DTOs.Request
{
    public class BeerResquestDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Style { get; set; }
        public decimal Alcohol { get; set; }
    }
}
