using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibros.Data; //AGREGAR
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //Inyección de dependencias Inicia


        // Propiedades

        private readonly DBLibrosContext context;


        //constructor

        public AutorController(DBLibrosContext context)
        {
            this.context = context;
        }


        //Inyección de dependecia Termina

        //GET: api/autor
        [HttpGet]

        public ActionResult<IEnumerable<Autor>> Get()
        {
            //return context.Autores.ToList();
            var result = context.Autores.Include(x => x.Libros).ToList();
            return result;
        }


        //GET: api/autor/5
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();
            return autor;
        }

        // Get: api/autor/{edad}
        [HttpGet("listado/{edad}")]       // Ruta Personalizada

        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
             List<Autor> autores = (from a in context.Autores
                                 where a.Edad == edad
                                 select a).ToList();
            return autores;
        }




         //Post api/autor
          [HttpPost]

        public ActionResult Post(Autor autor) 
        {   
            if(!ModelState.IsValid)
            {
                return BadRequest(autor);
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }

        //Put
        //Put api/autor/2

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Autor autor) 
        {
            if(id != autor.IdAutor) 
            {
                return BadRequest();
            }
            context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //Delete  api/autor/3

        [HttpDelete("{id}")]

        public ActionResult<Autor> Delete(int id)
        {
            var autor = (from a in context.Autores
                         where a.IdAutor == id
                         select a).SingleOrDefault();
            if(autor ==null)
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;

            
        }

    }
}
