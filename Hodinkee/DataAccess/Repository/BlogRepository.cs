using Services;
using System;

namespace DataAccess.Repository
{
    public class BlogRepository: EFCoreBlogRepository, IBlogRepository
    {
        public BlogRepository(bool isUnitOfWork = false)
          : base(new BlogContext(), isUnitOfWork) { }



        public override void HandleException(Exception ex)
        {
            //base.HandleException(ex);
        }
    }
}
