using Business.Operations;
using Services.Operations;
using System;

namespace Business
{
    public class BlogOperationsFactory
    {
        public static IArticle GetArticleOperations()
        {
            return new ArticleOp();
        }

        public static ITypesPost GetTypesPostOperations()
        {
            return new TypesPostOp();
        }

    }
}
