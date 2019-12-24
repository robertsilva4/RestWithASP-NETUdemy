using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    e expõe como endpoint REST
    */
    
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        //declaraçã do servidor usado
        //private IBookBusiness _bookBusiness;

        //injeção de uma instância IPersonBusiness ao criar
        //uma instancia de persons controllers
        //public PersonsController(IPersonBusiness personBusiness)
        //{
        //    _bookBusiness = bookBusiness;
        //}

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/
        //Get sem parâmetros para o FindAll --> Busca Todos
        // GET api/values
        [HttpGet("v1")]
        public IActionResult Get()
        {
            //return Ok(_bookBusiness.FindAll());
            return Ok();
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        // GET api/values/5
        [HttpGet("v1/{id}")]
        public IActionResult Get(long id)
        {
            /*var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);*/
            return Ok();
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        // POST api/values
        [HttpPost("v1")]
        public IActionResult Post([FromBody] Book book)
        {
            //if (book == null) return BadRequest();
            //return new ObjectResult(_bookBusiness.Create(book));
            return Ok();
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        // PUT api/values/5
        [HttpPut("v1")]
        public IActionResult Put([FromBody] Book book)
        {
            //if (book == null) return BadRequest();
            //var updatedBook = _bookBusiness.Update(person);
            //if (updatedBook == null) return BadRequest();
            //return new ObjectResult(updatedBook);
            return Ok();
        }

        //Mapeia as requisições DELETE para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        // DELETE api/values/5
        [HttpDelete("v1/{id}")]
        public IActionResult Delete(int id)
        {
            //_bookBusiness.Delete(id);
            //return NoContent();
            return Ok();
        }
    }
}
