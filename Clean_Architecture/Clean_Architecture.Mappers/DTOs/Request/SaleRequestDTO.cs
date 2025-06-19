using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Mappers.DTOs.Request
{
    public class SaleRequestDTO
    {
        public List<ConceptRequestDTO> Concepts { get; set; }
    }

    public class ConceptRequestDTO
    {
        public int IdBeer { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
