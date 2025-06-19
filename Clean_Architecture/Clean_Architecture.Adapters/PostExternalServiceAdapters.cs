using Clean_Architecture.Adapters.Dtos;
using Clean_Architecture.Application;
using Clean_Architecture.Domain;

namespace Clean_Architecture.Adapters
{
    public class PostExternalServiceAdapters : IExternalServiceAdapter<Post>
    {
        private readonly IExternalService<PostServiceDTO> _service;
        public PostExternalServiceAdapters(IExternalService<PostServiceDTO> service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Post>> GetDataAsync()
        {
            var postsDTO = await _service.GetContentAsync();
            var list = postsDTO.Select(x => new Post()
            { 
                Body = x.Body,
                Id = x.Id,
                Title = x.Title
            });
            return list;
        }
    }
}
