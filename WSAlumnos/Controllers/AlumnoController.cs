using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSAlumnos.Models;
using System.Linq;
namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado()
        {
            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno() { Id = 1, Apellido ="Perez", Nombre = "Damian" },
                new Alumno() { Id = 2, Apellido ="Gonzalez", Nombre = "Lucas"},
                new Alumno() { Id = 3, Apellido ="Álvarez", Nombre = "Delfina"}
            };
            return alumnos;
        }

        //GET api/Alumno

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return Listado();
        }

        //Get api/Alumno/3
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id)
        {
            Alumno alumno = (from a in Listado()
                         where a.Id == id
                         select a).SingleOrDefault();

            return alumno;
        }

    }
}
