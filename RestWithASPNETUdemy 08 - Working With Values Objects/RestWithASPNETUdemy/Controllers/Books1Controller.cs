using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/person/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    e expõe como endpoint REST
    */
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController
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
        [HttpGet("v1{id}")]
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
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
            return Ok();
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/person/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return BadRequest();
            return new ObjectResult(updatedPerson);
            return Ok();
        }

        //Mapeia as requisições DELETE para http://localhost:{porta}/api/person/{id}
        //recebendo um ID como no Path da requisição
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
            return Ok();
        }
    }
}
