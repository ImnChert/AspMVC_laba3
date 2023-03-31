namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Forum> Forums { get; set; } = new List<Forum>();
        public List<ForumMessage> Messages { get; set; } = new List<ForumMessage>();
    }
}
