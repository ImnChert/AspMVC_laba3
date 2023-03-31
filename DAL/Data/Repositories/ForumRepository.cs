using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace DAL.Data.Repositories
{
    internal class ForumRepository : MainRepository<Forum>, IForumRepository
    {
        public ForumRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
