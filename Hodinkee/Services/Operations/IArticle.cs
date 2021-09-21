using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Operations
{
    public interface IArticle
    {
        Article RegisterArticle(Article Article);
        Article ConsultArticleById(int ArticleID);
        bool UpdateArticle(Article Article);
        bool DeleteArticle(int ArticleID);
        List<Article> ConsultArticles();

    }
}
