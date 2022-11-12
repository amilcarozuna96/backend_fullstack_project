using Backend_Fullstack_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Fullstack_Project.Context
{
    public class AppDbContext : DbContext //Desde aquí se hace la representación de la tabla, vamos a llamar el modelo
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Este es un constructor
        {

        }
        public DbSet<UserProperties> User_properties { get; set; }
    }
}
