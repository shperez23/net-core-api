using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Operations;

namespace WebApiHodinkee.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IArticle iArticle;

        public ArticleController(IArticle ArticleOp)
        {
            this.iArticle = ArticleOp;
        }

        
        [HttpGet("ConsultArticles", Name = "ConsultArticles")]
        public ActionResult<IEnumerable<Article>> ConsultArticles()
        {
            List<Article> Result;
            Result = iArticle.ConsultArticles();
            if (!Result.Any())
            {
                return NotFound("Sin registros");
            }

            return Ok(Result);

        }

            
        [HttpGet("ConsultArticleById/{id}", Name = "ConsultArticleById")]
        public ActionResult<Article> ConsultArticleById(int id)
        {
            Article Result;
            Result = iArticle.ConsultArticleById(id);
            if (Result==null)
            {
                return NotFound(id);
            }
            return Ok(Result);
        }

        
        [HttpPost("RegisterArticle")]
        public ActionResult<Article> RegisterArticle([FromBody] Article value)
        {

            Article Result;
            Result = iArticle.RegisterArticle(value);
            if (Result == null)
            {
                return NotFound("No registrado");
            }

            return Ok(Result);
        }

        
        [HttpPut("UpdateArticle/{id}")]
        public ActionResult<bool> UpdateArticle([FromBody] Article value)
        {
            bool Result;
            Result = iArticle.UpdateArticle(value);
            if (!Result)
            {
                return NotFound("Registro no actualizado");
            }
            return Ok(Result);

        }

        
        [HttpDelete("DeleteArticle/{id}")]
        public ActionResult<bool> DeleteArticle(int id)
        {
            bool Result;
            Result = iArticle.DeleteArticle(id);
            if (!Result)
            {
                return NotFound("Registro no eliminado");
            }
            return Ok(Result);

        }



    }
}