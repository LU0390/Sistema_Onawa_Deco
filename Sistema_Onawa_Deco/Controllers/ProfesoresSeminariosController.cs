using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Onawa_Deco.Models;

namespace Sistema_Onawa_Deco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresSeminariosController : ControllerBase
    {
        private readonly OnawaDecoDbContext _context;

        public ProfesoresSeminariosController(OnawaDecoDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfesoresSeminarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorSeminario>>> GetProfesorSeminarios()
        {
            return await _context.ProfesorSeminarios.ToListAsync();
        }

        // GET: api/ProfesoresSeminarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorSeminario>> GetProfesorSeminario(int id)
        {
            var profesorSeminario = await _context.ProfesorSeminarios.FindAsync(id);

            if (profesorSeminario == null)
            {
                return NotFound();
            }

            return profesorSeminario;
        }

        // PUT: api/ProfesoresSeminarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesorSeminario(int id, ProfesorSeminario profesorSeminario)
        {
            if (id != profesorSeminario.ProfesorDni)
            {
                return BadRequest();
            }

            _context.Entry(profesorSeminario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorSeminarioExists(id))
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

        // POST: api/ProfesoresSeminarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProfesorSeminario>> PostProfesorSeminario(ProfesorSeminario profesorSeminario)
        {
            _context.ProfesorSeminarios.Add(profesorSeminario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfesorSeminarioExists(profesorSeminario.ProfesorDni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfesorSeminario", new { id = profesorSeminario.ProfesorDni }, profesorSeminario);
        }



     /*  [HttpGet]
        [Route("inscripciones/{id}")]
        public List<Seminario> GetProfesorSeminario(int id)
        {
            return _context.ProfesorSeminarios
                   .Include("Seminario")
                   .Where(p => p.ProfesorDni == id).Select(m => m.Seminario).ToList();
        }


        */
        // DELETE: api/ProfesoresSeminarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfesorSeminario>> DeleteProfesorSeminario(int id)
        {
            var profesorSeminario = await _context.ProfesorSeminarios.FindAsync(id);
            if (profesorSeminario == null)
            {
                return NotFound();
            }

            _context.ProfesorSeminarios.Remove(profesorSeminario);
            await _context.SaveChangesAsync();

            return profesorSeminario;
        }

        private bool ProfesorSeminarioExists(int id)
        {
            return _context.ProfesorSeminarios.Any(e => e.ProfesorDni == id);
        }
    }
}
