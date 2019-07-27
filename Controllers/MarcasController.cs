using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio.Data;
using Desafio.Models;
using Desafio.Validators;
using Newtonsoft.Json;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DesafioContext _context;

        public MarcasController(DesafioContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet]
        public IEnumerable<Marca> GetMarca()
        {
            return _context.Marca.ToList();
        }

        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.Id == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpGet("{id}/patrimonios")]
        public async Task<IActionResult> GetMarcaPatrimonio([FromRoute] int id)
        {
            var marca = await _context.Patrimonio.Where(m => m.MarcaId == id).ToListAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        // PUT: api/Marcas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca([FromRoute] int id, [FromBody] Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.Id)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        [HttpPost]
        public async Task<IActionResult> PostMarca([FromBody] Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!new MarcaValidator(_context).MarcaValidateNomeDuplicado(marca))
                    return BadRequest($"Já existe uma marca com esse nome {marca.Nome}");
                else
                {
                    _context.Marca.Add(marca);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }

            return CreatedAtAction("GetMarca", new { id = marca.Id }, marca);
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();

            return Ok(marca);
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.Id == id);
        }
    }
}