using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace DAL.Data.Repositories
{
    internal class ForumMessageRepository : MainRepository<ForumMessage>, IForumMessageReposiotry
    {
        public ForumMessageRepository(ApplicationContext dbContext)
            : base(dbContext)
        {
        }
    }
}
