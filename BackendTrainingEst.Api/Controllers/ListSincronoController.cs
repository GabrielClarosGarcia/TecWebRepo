using BackendTrainingEst.Api.Helpers;
using BackendTrainingEst.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTrainingEst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListSincronoController : ControllerBase
    {
        private static List<Persona> personas =
            new()
            {
                new Persona { Id = 1, Nombre = "Juan", Edad = 20  },
                new Persona { Id = 2, Nombre = "Maria", Edad = 19  }
            };

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> GetAll()
        {
            return Ok(personas);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Persona>
            GetById(int id)
        {
            var persona = personas.FirstOrDefault(x => x.Id == id);
            if (persona is not null)
                return Ok(persona);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Persona> Create(
            Persona nueva)
        {
            try
            {
                //if(nueva.Edad > 100)
                //    throw new Exception("edades menores menores o iguales 100");

                nueva.Id = personas.Any() ?
                        personas.Max(a => a.Id) + 1 :
                        1;

                //if (personas.Any())
                //    nueva.Id = personas.Max(a => a.Id) + 1;
                //else
                //    nueva.Id = 1;

                

                personas.Add(nueva);

                return CreatedAtAction(nameof(GetById),
                    new { id = nueva.Id }, nueva);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update
            (int id, Persona actulizada)
        {
            var persona = personas.FirstOrDefault(a => a.Id == id);
            if (persona is null) return NotFound();

            persona.Nombre = actulizada.Nombre;
            persona.Edad = actulizada.Edad;
            return Ok(persona);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var persona = personas.FirstOrDefault(a => a.Id == id);
            if (persona is null) return NotFound();

            personas.Remove(persona);
            return NoContent();
        }
    }
}
