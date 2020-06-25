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
    public class SeminariosSociosController : ControllerBase
    {
        private readonly OnawaDecoDbContext _context;

        public SeminariosSociosController(OnawaDecoDbContext context)
        {
            _context = context;
        }

        // GET: api/SeminariosSocios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeminarioSocio>>> GetSocioSeminario()
        {
            return await _context.SocioSeminario.ToListAsync();
        }

        // GET: api/SeminariosSocios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeminarioSocio>> GetSeminarioSocio(int id)
        {
            var seminarioSocio = await _context.SocioSeminario.FindAsync(id);

            if (seminarioSocio == null)
            {
                return NotFound();
            }

            return seminarioSocio;
        }

        // PUT: api/SeminariosSocios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeminarioSocio(int id, SeminarioSocio seminarioSocio)
        {
            if (id != seminarioSocio.SocioId)
            {
                return BadRequest();
            }

            _context.Entry(seminarioSocio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarioSocioExists(id))
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

        // POST: api/SeminariosSocios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SeminarioSocio>> PostSeminarioSocio(SeminarioSocio seminarioSocio)
        {
            _context.SocioSeminario.Add(seminarioSocio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeminarioSocioExists(seminarioSocio.SocioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSeminarioSocio", new { id = seminarioSocio.SocioId }, seminarioSocio);
        }

        // DELETE: api/SeminariosSocios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeminarioSocio>> DeleteSeminarioSocio(int id)
        {
            var seminarioSocio = await _context.SocioSeminario.FindAsync(id);
            if (seminarioSocio == null)
            {
                return NotFound();
            }

            _context.SocioSeminario.Remove(seminarioSocio);
            await _context.SaveChangesAsync();

            return seminarioSocio;
        }

        private bool SeminarioSocioExists(int id)
        {
            return _context.SocioSeminario.Any(e => e.SocioId == id);
        }
    }
}
