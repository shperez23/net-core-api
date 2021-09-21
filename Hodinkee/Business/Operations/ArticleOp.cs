using DataAccess.Repository;
using Entities;
using Services.Operations;
using System;
using System.Collections.Generic;

namespace Business.Operations
{
    public class ArticleOp : IArticle
    {
        public Article ConsultArticleById(int ArticleID)
        {
            Article Result = null;
            if (ArticleID > 0)
            {
                using var Repository = BlogRepositoryFactory.GetBlogRepository();
                Result = Repository.RetrieveByID<Article>(ArticleID);
            }
            return Result;
        }

        public List<Article> ConsultArticles()
        {
            List<Article> Result = null;

            using var Repository = BlogRepositoryFactory.GetBlogRepository();
            Result = Repository.GetAll<Article>();

            return Result;
        }

        public bool DeleteArticle(int ArticleID)
        {
            bool Result = false;
            using (var Repository = BlogRepositoryFactory.GetBlogRepository())
            {
                Result = Repository.Delete(new Article { ID = ArticleID });
            }

            return Result;
        }

        public Article RegisterArticle(Article Article)
        {
            if (!string.IsNullOrEmpty(Article.Title))
            {
                using var repository = BlogRepositoryFactory.GetBlogRepository();
                Article = repository.Create(Article);
            }
            else
            {
                Article = null;
            }

            return Article;
        }

        public bool UpdateArticle(Article Article)
        {
            bool Result = false;
            using (var Repository = BlogRepositoryFactory.GetBlogRepository())
            {
                Result = Repository.Update(Article);
            }

            return Result;
        }
    }
}
