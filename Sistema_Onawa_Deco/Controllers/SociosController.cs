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
    public class SociosController : ControllerBase
    {
        private readonly OnawaDecoDbContext _context;

        public SociosController(OnawaDecoDbContext context)
        {
            _context = context;
        }

        // GET: api/socios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Socio>>> GetSocios()
        {
            return await _context.Socios.ToListAsync();
        }

        // GET: api/Socios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Socio>> GetSocio(int id)
        {
            var socio = await _context.Socios.FindAsync(id);

            if (socio == null)
            {
                return NotFound();
            }

            return socio;
        }

        //http de socios y seminarios
        [HttpGet]
        [Route("inscripciones/{id}")]
        public List<Seminario> GetSocioSeminarios(int id)
        {
            return _context.SocioSeminario
                   .Include("Seminarios")
                   .Where(s => s.SocioId == id).Select(m => m.Seminario).ToList();
        }

        // PUT: api/Socios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocio(int id, Socio socio)
        {
            if (id != socio.Id)
            {
                return BadRequest();
            }

            _context.Entry(socio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocioExists(id))
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

        // POST: api/socios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Socio>> PostSocio(Socio socio)
        {
            _context.Socios.Add(socio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocio", new { id = socio.Id }, socio);
        }

        // DELETE: api/Socios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Socio>> DeleteSocio(int id)
        {
            var socio = await _context.Socios.FindAsync(id);
            if (socio == null)
            {
                return NotFound();
            }

            _context.Socios.Remove(socio);
            await _context.SaveChangesAsync();

            return socio;
        }

        private bool SocioExists(int id)
        {
            return _context.Socios.Any(e => e.Id == id);
        }
    }
}
