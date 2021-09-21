using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Operations
{
    public interface ITypesPost
    {
        TypesPost RegisterTypesPost(TypesPost TypesPost);
        TypesPost ConsultTypesPostById(int TypesPostID);
        bool UpdateTypesPost(TypesPost TypesPost);
        bool DeleteTypesPost(int TypesPostID);
        List<TypesPost> ConsultTypesPost();
    }
}
