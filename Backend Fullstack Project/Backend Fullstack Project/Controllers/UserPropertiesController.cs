using Backend_Fullstack_Project.Context;
using Backend_Fullstack_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Fullstack_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPropertiesController : ControllerBase
    {
        
        
        private readonly AppDbContext context; //Se importa primero el context para poder realizar las peticiones
        public UserPropertiesController(AppDbContext context)
        {
            this.context = context;
        }




        // GET: api/<UserPropertiesController>
        [HttpGet]
        public ActionResult Get()
        {
            try //El try-catch es para el manejo de errores, se necesita en cada petición por si hay alguna excpeción.
            {
                return Ok(context.User_properties.ToList()); //Esto le regresa al usuario lo solicitado usando LINQ
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //Esto le regresa al usuario un mensaje en caso de error
            }
        }

        // GET api/<UserPropertiesController>/5
        [HttpGet("{id}", Name = "GetUserProperties")]
        public ActionResult Get(int id)
        {
            try 
            {
                var property = context.User_properties.FirstOrDefault(p => p.id == id);
                return Ok(property);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UserPropertiesController>
        [HttpPost]
        public ActionResult Post([FromBody] UserProperties property)
        {
            try
            {
                context.User_properties.Add(property); //Inserta el registro en base de datos
                context.SaveChanges(); //Guarda los cambios
                return CreatedAtRoute("GetUserProperties", new { id = property.id }, property); //Muestra al usuario lo que se insertó incluyendo Id autoincrementable gracias al método GetUserProperties
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UserPropertiesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserProperties property)
        {
            try
            {
                if(property.id == id) //Se busca por id el registro que se quiere modificar
                {
                    context.Entry(property).State = EntityState.Modified; //Hace los cambios
                    context.SaveChanges(); //Guarda los cambios
                    return CreatedAtRoute("GetUserProperties", new { id = property.id }, property); //Lo regresa al usuario
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UserPropertiesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var property = context.User_properties.FirstOrDefault(p => p.id == id); //Con esto se busca si existe el registro
                if (property != null)
                {
                    context.User_properties.Remove(property); //Remueve el registro
                    context.SaveChanges(); //Guarda los cambios
                    return Ok(id); //Lo regresa al usuario
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
