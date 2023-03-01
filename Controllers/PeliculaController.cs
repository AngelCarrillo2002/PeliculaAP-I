using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculaAPI;
using PeliculaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ApplicationDbContext _db; 
        public PeliculaController(ApplicationDbContext db)
        { 
            _db = db;
        }
        //Mostrar TODAS las peliculas        
        [HttpGet]       
        [ProducesResponseType(200, Type = typeof(List<Pelicula>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPeliculas()
        {
            var lista = await _db.Peliculas.OrderBy(p => p.NombrePelicula).Include(p => p.Categoria).ToListAsync();


            return Ok(lista);
        }
        //BuscarId Pelicula
        [HttpGet("{id:int}")]

        [ProducesResponseType(200, Type = typeof(Pelicula))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)] //Codigos de error, no encontrado y bien ejecutado
        public async Task<IActionResult> GetPeliculas(int id)
        {
            var obj = await _db.Peliculas.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        //Creacion de nueva pelicula       
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CrearPelicula([FromBody] Pelicula pelicula)
        {
            if (pelicula == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _db.AddAsync(pelicula);
            await _db.SaveChangesAsync();
            return Ok();
        }
        //Busqueda por Genero     
        [HttpGet("GetPorCategoria")]
        public async Task<IActionResult> GetPeliculasPorCategoria(int idcategoria)
        {
            var peliculas = await _db.Peliculas.Where(p => p.CategoriaId == idcategoria).ToListAsync();
            if (peliculas == null || peliculas.Count == 0)
            {
                return NotFound();
            }
            return Ok(peliculas);
        }
    }
}


