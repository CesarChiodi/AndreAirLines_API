using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLines_API.Data;
using AndreAirLines_API.Model;

namespace AndreAirLines_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoBasesController : ControllerBase
    {
        private readonly AndreAirLines_APIContext _context;

        public PrecoBasesController(AndreAirLines_APIContext context)
        {
            _context = context;
        }

        // GET: api/PrecoBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrecoBase>>> GetPrecoBase()
        {
            return await _context.PrecoBase.Include(destino => destino.Destino)
                                           .Include(origem => origem.Origem)
                                           .ToListAsync();
        }

        // GET: api/PrecoBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoBase>> GetPrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase.Include(destino => destino.Destino)
                                           .Include(origem => origem.Origem)
                                           .Where(idPreco => idPreco.IdPrecoBase == id).FirstOrDefaultAsync();

            if (precoBase == null)
            {
                return NotFound();
            }

            return precoBase;
        }

        // PUT: api/PrecoBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrecoBase(int id, PrecoBase precoBase)
        {
            if (id != precoBase.IdPrecoBase)
            {
                return BadRequest();
            }

            _context.Entry(precoBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecoBaseExists(id))
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

        // POST: api/PrecoBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrecoBase>> PostPrecoBase(PrecoBase precoBase)
        {
            var destino = await _context.Aeroporto.Where(aeroporto => aeroporto.Sigla == precoBase.Destino.Sigla).FirstOrDefaultAsync();
            if (destino != null)
            {
                precoBase.Destino = destino;
            }

            var origin = await _context.Aeroporto.Where(airport => airport.Sigla == precoBase.Origem.Sigla).FirstOrDefaultAsync();
            if (origin != null)
            {
                precoBase.Origem = origin;
            }

            _context.PrecoBase.Add(precoBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrecoBase", new { id = precoBase.IdPrecoBase }, precoBase);
        }

        // DELETE: api/PrecoBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase.FindAsync(id);
            if (precoBase == null)
            {
                return NotFound();
            }

            _context.PrecoBase.Remove(precoBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrecoBaseExists(int id)
        {
            return _context.PrecoBase.Any(e => e.IdPrecoBase == id);
        }
    }
}
