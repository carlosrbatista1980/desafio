using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio.Data;
using Desafio.Models;
using Desafio.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimoniosController : ControllerBase
    {
        private readonly DesafioContext _context;

        public PatrimoniosController(DesafioContext context)
        {
            _context = context;
        }

        // GET: api/Patrimonios
        [HttpGet]
        public IEnumerable<Patrimonio> GetPatrimonio()
        {
            return _context.Patrimonio.ToList();
        }

        // GET: api/Patrimonios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatrimonio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patrimonio = await _context.Patrimonio.FindAsync(id);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        // PUT: api/Patrimonios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatrimonio([FromRoute] int id, [FromBody] Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patrimonio.Id)
            {
                return BadRequest();
            }

            _context.Entry(patrimonio).State = EntityState.Modified;
            
            try
            {
                if (!new PatrimonioValidator(_context).PatrimonioValidateNumeroTombo(patrimonio))
                {
                    return BadRequest($"Não é possivel alterar o numero do tombo {patrimonio.NumeroTombo}");
                }
                else
                {
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Accepted();
        }

        // POST: api/Patrimonios
        [HttpPost]
        public async Task<IActionResult> PostPatrimonio([FromBody] Patrimonio patrimonio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rnd = new Random();
            patrimonio.NumeroTombo = rnd.Next(100000, 999999);

            _context.Patrimonio.Add(patrimonio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatrimonio", new { id = patrimonio.Id }, patrimonio);
        }

        // DELETE: api/Patrimonios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatrimonio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patrimonio = await _context.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            _context.Patrimonio.Remove(patrimonio);
            await _context.SaveChangesAsync();

            return Ok(patrimonio);
        }

        private bool PatrimonioExists(int id)
        {
            return _context.Patrimonio.Any(e => e.Id == id);
        }
    }
}