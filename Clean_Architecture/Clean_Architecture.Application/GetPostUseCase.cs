using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application
{
    public class GetPostUseCase
    {
        private readonly IExternalServiceAdapter<Post> _adapter;
        public GetPostUseCase(IExternalServiceAdapter<Post> adapter)
        {
            _adapter = adapter;
        }

        public async Task<IEnumerable<Post>> ExecuteAsync()
        {
            return await _adapter.GetDataAsync();
        }
    }
}
