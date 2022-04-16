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
    public class PassagemsController : ControllerBase
    {
        private readonly AndreAirLines_APIContext _context;

        public PassagemsController(AndreAirLines_APIContext context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.Include(voo => voo.Voo)
                                          .Include(passageiro => passageiro.Passageiro)
                                          .Include(valor => valor.ValorPassagem)
                                          .Include(classe => classe.Classe)
                                          .Include(precoBase => precoBase.PrecoBase)
                                          //.Include(promocaoPorcentagem => promocaoPorcentagem.PrecoBase)
                                          .ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.Include(voo => voo.Voo)
                                          .Include(passageiro => passageiro.Passageiro)
                                          .Include(valor => valor.ValorPassagem)
                                          .Include(classe => classe.Classe)
                                          .Include(precoBase => precoBase.PrecoBase)
                                          //.Include(promocaoPorcentagem => promocaoPorcentagem.PromocaoPorcentagem)
                                          .Where(idPassagem => idPassagem.IdPassagem == id).FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.IdPassagem)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            var voo = await _context.Voo.FindAsync(passagem.Voo.IdVoo);
            if (voo != null)
            {
                passagem.Voo = voo;
            }
            var passageiro = await _context.Passageiro.FindAsync(passagem.Passageiro.Cpf);
            if (passageiro != null)
            {
                passagem.Passageiro = passageiro;
            }
            var classe = await _context.Classe.FindAsync(passagem.Classe.IdClasse);
            if (classe != null)
            {
                passagem.Classe = classe;
            }
            var precoBase = await _context.PrecoBase.FindAsync(passagem.PrecoBase.IdPrecoBase);
            if (precoBase != null)
            {
                passagem.PrecoBase = precoBase;
            }
            var promocaoPorcentagem = await _context.PrecoBase.FindAsync(passagem.PrecoBase.PromocaoPorcentagem);
            if (promocaoPorcentagem != null)
            {
                passagem.PrecoBase = promocaoPorcentagem;
            }

            passagem.ValorPassagem = (passagem.Classe.Valor + passagem.PrecoBase.Valor) * (1 - passagem.PrecoBase.PromocaoPorcentagem);

            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.IdPassagem }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.IdPassagem == id);
        }



    }
}
