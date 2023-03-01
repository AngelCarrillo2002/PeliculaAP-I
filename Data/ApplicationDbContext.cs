using Microsoft.EntityFrameworkCore;
using PeliculaAP_I.Models;
using PeliculaAPI.Models;
using System;

namespace PeliculaAPI
{ 
    //Concectarse a base de datos
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) 
        {

        }
        public DbSet<Categoria> Categorias { get; set; 
        }
        public DbSet<Pelicula> Peliculas { get; set; 
        }
        internal object Where(Func<object, bool> value) 
        { 
            throw new NotImplementedException(); 
        }
    }
}