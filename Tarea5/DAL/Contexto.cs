using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarea5.DAL;

public class Contexto : DbContext
{
    public DbSet<Proyectos> Proyectos { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    public DbSet<Tareas> Tareas { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}
