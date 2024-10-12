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
    public class TareasController : ControllerBase
    {
        private readonly Contexto _context;

        public TareasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tareas>>> GetTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tareas>> GetTareas(int id)
        {
            var tareas = await _context.Tareas.FindAsync(id);

            if (tareas == null)
            {
                return NotFound();
            }

            return tareas;
        }

        // PUT: api/Tareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTareas(int id, Tareas tareas)
        {
            if (id != tareas.TareaId)
            {
                return BadRequest();
            }

            _context.Entry(tareas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareasExists(id))
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

        // POST: api/Tareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tareas>> PostTareas(Tareas tareas)
        {
            if (tareas.TareaId <= 0 || !TareasExists(tareas.TareaId))
            {
                _context.Tareas.Add(tareas);
            }
            else
            {
                _context.Tareas.Update(tareas);
            }
            await _context.SaveChangesAsync();
            return Ok(tareas);
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTareas(int id)
        {
            if (!_context.Tareas.Any())
            {
                return NoContent();
            }
            var tareas = await _context.Tareas.FindAsync(id);
            if (tareas == null)
            {
                return NotFound();
            }
            _context.Tareas.Remove(tareas);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TareasExists(int id)
        {
            return _context.Tareas.Any(e => e.TareaId == id);
        }
    }
}
