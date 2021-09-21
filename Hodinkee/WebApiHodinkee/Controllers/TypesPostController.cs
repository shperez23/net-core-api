using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Operations;

namespace WebApiHodinkee.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TypesPostController : ControllerBase
    {
        private readonly ITypesPost iTypesPost;

        public TypesPostController(ITypesPost TypesPostOp)
        {
            this.iTypesPost = TypesPostOp;
        }


        [HttpGet("ConsultTypesPost", Name = "ConsultTypesPost")]
        public ActionResult<IEnumerable<TypesPost>> ConsultTypesPost()
        {
            List<TypesPost> Result;
            Result = iTypesPost.ConsultTypesPost();
            if (!Result.Any())
            {
                return NotFound("Sin registros");
            }

            return Ok(Result);

        }


        [HttpGet("ConsultTypesPostById/{id}", Name = "ConsultTypesPostById")]
        public ActionResult<TypesPost> ConsultTypesPostById(int id)
        {
            TypesPost Result;
            Result = iTypesPost.ConsultTypesPostById(id);
            if (Result == null)
            {
                return NotFound(id);
            }
            return Ok(Result);
        }


        [HttpPost("RegisterTypesPost")]
        public ActionResult<TypesPost> RegisterTypesPost([FromBody] TypesPost value)
        {

            TypesPost Result;
            Result = iTypesPost.RegisterTypesPost(value);
            if (Result == null)
            {
                return NotFound("No registrado");
            }

            return Ok(Result);
        }


        [HttpPut("UpdateTypesPost/{id}")]
        public ActionResult<bool> UpdateTypesPost([FromBody] TypesPost value)
        {
            bool Result;
            Result = iTypesPost.UpdateTypesPost(value);
            if (!Result)
            {
                return NotFound("Registro no actualizado");
            }
            return Ok(Result);

        }


        [HttpDelete("DeleteTypesPost/{id}")]
        public ActionResult<bool> DeleteTypesPost(int id)
        {
            bool Result;
            Result = iTypesPost.DeleteTypesPost(id);
            if (!Result)
            {
                return NotFound("Registro no eliminado");
            }
            return Ok(Result);

        }

    }
}