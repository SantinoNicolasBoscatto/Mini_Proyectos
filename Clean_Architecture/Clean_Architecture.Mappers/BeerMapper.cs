using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Clean_Architecture.Mappers.DTOs.Request;

namespace Clean_Architecture.Mappers
{
    public class BeerMapper : IMapper<BeerResquestDTO, Beer>
    {
        public Beer ToEntity(BeerResquestDTO dto)
        {
            var beer = new Beer()
            {
                Alcohol = dto.Alcohol,
                Id = dto.Id,
                Name = dto.Name,
                Style = dto.Style,
            };
            return beer;
        }
    }
}
