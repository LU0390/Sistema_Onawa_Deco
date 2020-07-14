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

        // GET: api/SeminariosSocios/5
        [HttpGet("{id}")]
        public List<Seminario> GetSocioSeminario(int id)

        {
            return _context.SocioSeminario
                   .Include("Seminario")
                   .Where(p => p.SocioId == id).Select(m => m.Seminario).ToList();
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
        public async Task<ActionResult<ProfesorSeminario>> PostSocioSeminario(int socioId, int seminarioID)
        {
            SeminarioSocio socioSeminario = new SeminarioSocio();
            socioSeminario.SocioId = socioId;
            socioSeminario.SeminarioId = seminarioID;
            _context.SocioSeminario.Add(socioSeminario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeminarioSocioExists(socioSeminario.SocioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSocioSeminario", new { id = socioSeminario.SocioId }, socioSeminario);
        }


        // DELETE: api/SeminariosSocios/5
        [HttpDelete]
        public async Task<ActionResult<SeminarioSocio>> DeleteRelacionSocioSeminario(int socioId, int seminarioID)
        {
            var socioSeminario = await _context.SocioSeminario.FindAsync(socioId, seminarioID);
            if (socioSeminario == null)
            {
                return NotFound();
            }

            _context.SocioSeminario.Remove(socioSeminario);
            await _context.SaveChangesAsync();

            return socioSeminario;
        }
        private bool SeminarioSocioExists(int id)
        {
            return _context.SocioSeminario.Any(e => e.SocioId == id);
        }
    }
}
