using System.ComponentModel.DataAnnotations;

namespace WebApiActores.DTOs
{
    public class AdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
