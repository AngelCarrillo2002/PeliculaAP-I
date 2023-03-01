using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculaAP_I.Models;
using PeliculaAPI;
using PeliculaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PeliculaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Mostrar todos los GENEROS
        [HttpGet("/generos")]
        [ProducesResponseType(200, Type = typeof(List<Categoria>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCategorias()
        {
            var lista = await _db.Categorias.OrderBy(c => c.Nombre).ToListAsync();
            return Ok(lista);
        }

        //Buscar IdCategoria 
        [HttpGet("/generos/{id}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //Codigos de buen reultado, no encontrado y error
        public async Task<IActionResult> GetCategoria(int id)
        {
            var obj = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        //Crear una nueva Categoria
        [HttpPost("/generos")]
       /* [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]*/
        public async Task<IActionResult> CrearCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(categoria);
            await _db.SaveChangesAsync();
           return Ok(categoria);    
            //return CreatedAtRoute("GetCategoria", new{id=categoria.Id },categoria);
        }

        //Actualizacion de campo "CATEGORIA"

        [HttpPut("/generos/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Categoria categoria)
        {
            var obj = await _db.Categorias.FindAsync(id); if (obj == null)
            {
                return NotFound();
            }
            obj.Nombre = categoria.Nombre;
            obj.Estado = categoria.Estado;
            _db.Categorias.Update(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        //Borrar Categoria

        [HttpDelete("/generos/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var obj = await _db.Categorias.FindAsync(id); if (obj == null)
            {
                return NotFound();
            }
            _db.Categorias.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }







    }
}

