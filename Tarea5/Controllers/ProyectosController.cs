using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Tarea5.DAL;

namespace Tarea5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly Contexto _context;

        public ProyectosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyectos>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyectos>> GetProyectos(int id)
        {
            var proyectos = await _context.Proyectos.FindAsync(id);

            if (proyectos == null)
            {
                return NotFound();
            }

            return proyectos;
        }

        // PUT: api/Proyectos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyectos(int id, Proyectos proyectos)
        {
            if (id != proyectos.ProyectoId)
            {
                return BadRequest();
            }

            _context.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Proyectos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyectos>> PostProyectos(Proyectos proyectos)
        {
            if (proyectos.ProyectoId <= 0 || !ProyectosExists(proyectos.ProyectoId))
            {
                _context.Proyectos.Add(proyectos);
            }
            else
            {
                _context.Proyectos.Update(proyectos);
            }
            await _context.SaveChangesAsync();
            return Ok(proyectos);
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyectos(int id)
        {
            if (!_context.Proyectos.Any())
            {
                return NoContent();
            }
            var proyectos = await _context.Proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }
            _context.Proyectos.Remove(proyectos);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProyectosExists(int id)
        {
            return _context.Proyectos.Any(e => e.ProyectoId == id);
        }
    }
}
