using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public ICollection<VideoActor>? ListActores { get; set; } = new List<VideoActor>();
        public Director? Director { get; set; }
    }
}
