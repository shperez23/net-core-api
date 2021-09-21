using Services;

namespace DataAccess.Repository
{
    public class BlogRepositoryFactory
    {
        public static IBlogRepository GetBlogRepository(bool IsUnitOfWork = false)
        {
            return new BlogRepository(IsUnitOfWork);
        }
    }
}
