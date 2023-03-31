using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Forum : BaseEntity
    {
        public int OwnerId { get; set; }
        public User? Owner { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MinLength(1)]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
        public List<ForumMessage> Message { get; set; } = new List<ForumMessage>();
    }
}
