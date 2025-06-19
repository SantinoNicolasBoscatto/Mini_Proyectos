using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Clean_Architecture.Mappers.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Mappers
{
    public class SaleMapper : IMapper<SaleRequestDTO, Sale>
    {
        public Sale ToEntity(SaleRequestDTO dto)
        {
            var concepts = new List<Concept>();
            foreach (var conceptDTO in dto.Concepts)
            {
                concepts.Add(new Concept(conceptDTO.IdBeer, conceptDTO.Quantity, conceptDTO.UnitPrice));
            }
            return new Sale(DateTime.Now, concepts);
        }
    }
}
