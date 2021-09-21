using DataAccess.Repository;
using Entities;
using Services.Operations;
using System;
using System.Collections.Generic;

namespace Business.Operations
{
    public class TypesPostOp : ITypesPost
    {
        public List<TypesPost> ConsultTypesPost()
        {
            List<TypesPost> Result = null;

            using var Repository = BlogRepositoryFactory.GetBlogRepository();
            Result = Repository.GetAll<TypesPost>();

            return Result;
        }

        public TypesPost ConsultTypesPostById(int TypesPostID)
        {
            TypesPost Result = null;
            if (TypesPostID > 0)
            {
                using var Repository = BlogRepositoryFactory.GetBlogRepository();
                Result = Repository.RetrieveByID<TypesPost>(TypesPostID);
            }
            return Result;
        }

        public bool DeleteTypesPost(int TypesPostID)
        {
            bool Result = false;
            using (var Repository = BlogRepositoryFactory.GetBlogRepository())
            {
                Result = Repository.Delete(new TypesPost { ID = TypesPostID });
            }

            return Result;
        }

        public TypesPost RegisterTypesPost(TypesPost TypesPost)
        {
            if (!string.IsNullOrEmpty(TypesPost.Name))
            {
                using var repository = BlogRepositoryFactory.GetBlogRepository();
                TypesPost = repository.Create(TypesPost);
            }
            else
            {
                TypesPost = null;
            }

            return TypesPost;
        }

        public bool UpdateTypesPost(TypesPost TypesPost)
        {
            bool Result = false;
            using (var Repository = BlogRepositoryFactory.GetBlogRepository())
            {
                Result = Repository.Update(TypesPost);
            }

            return Result;
        }
    }
}
