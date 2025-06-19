using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class AdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
