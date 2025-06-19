using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Presentation.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeerController : ControllerBase
    {
        private readonly IRepository _beerRepository;
        public BeerController(IRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beer>>> GetAllBeers()
        {
            var list = await _beerRepository.GeAllAsync();
            return Ok(list);
        }
    }
}
