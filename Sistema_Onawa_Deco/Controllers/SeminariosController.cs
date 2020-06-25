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
    public class SeminariosController : ControllerBase
    {
        private readonly OnawaDecoDbContext _context;

        public SeminariosController(OnawaDecoDbContext context)
        {
            _context = context;
        }

        // GET: api/Seminarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminario>>> GetSeminarios()
        {
            return await _context.Seminarios.ToListAsync();
        }

        // GET: api/Seminarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seminario>> GetSeminario(int id)
        {
            var seminario = await _context.Seminarios.FindAsync(id);

            if (seminario == null)
            {
                return NotFound();
            }

            return seminario;
        }

        // PUT: api/Seminarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeminario(int id, Seminario seminario)
        {
            if (id != seminario.Id)
            {
                return BadRequest();
            }

            _context.Entry(seminario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarioExists(id))
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

        // POST: api/Seminarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Seminario>> PostSeminario(Seminario seminario)
        {
            _context.Seminarios.Add(seminario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeminario", new { id = seminario.Id }, seminario);
        }

        // DELETE: api/Seminarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seminario>> DeleteSeminario(int id)
        {
            var seminario = await _context.Seminarios.FindAsync(id);
            if (seminario == null)
            {
                return NotFound();
            }

            _context.Seminarios.Remove(seminario);
            await _context.SaveChangesAsync();

            return seminario;
        }

        private bool SeminarioExists(int id)
        {
            return _context.Seminarios.Any(e => e.Id == id);
        }
    }
}
