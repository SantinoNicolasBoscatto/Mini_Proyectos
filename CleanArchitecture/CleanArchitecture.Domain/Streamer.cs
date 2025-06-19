using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string Nombre { get; set; } = null!;
        public string Url { get; set; } = null!;
        public ICollection<Video>? ListaVideos { get; set; }
    }
}
