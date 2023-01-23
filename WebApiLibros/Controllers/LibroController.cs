using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;


        public LibroController( DBLibrosContext context ) 
        {
            this.context = context;
        }


        [HttpGet] //TRAER TODOS LOS LIBROS GET api/libro
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }


        [HttpGet("{id}")]   //Get: api/libro/id
        public ActionResult<Libro> GetById(int id)
        {
            Libro libro = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();
            return libro;
        }


        [HttpGet("autor/{id}")]   //Get: api/libro/autorId

        public ActionResult<List<Libro>> GetByAutor(int id)
        {
            var libros = (from a in context.Libros
                          where a.AutorId == id
                          select a).ToList();
            return libros;
        }




        [HttpPost] // Post
        public ActionResult Post(Libro libro)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(libro);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]  //Put

        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }
            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]

        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from a in context.Libros
                         where a.Id == id
                         select a).SingleOrDefault();
            if (libro == null)
            {
                return NotFound();
            }
            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;


        }

    }
}
