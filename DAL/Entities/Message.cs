using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Message : BaseEntity
    {
        public DateTime DateOfDispath { get; set; } = DateTime.Now;
        public bool IsEditing { get; set; } = false;
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
    }
}
