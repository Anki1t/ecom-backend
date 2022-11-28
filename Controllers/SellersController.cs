using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Majorproject.Models;
using Microsoft.AspNetCore.Cors;

namespace Majorproject.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly EcommerceDBContext _context;

        public SellersController(EcommerceDBContext context)
        {
            _context = context;
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSeller>>> GetTblSellers()
        {
            return await _context.TblSellers.ToListAsync();
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSeller>> GetTblSeller(int id)
        {
            var tblSeller = await _context.TblSellers.FindAsync(id);

            if (tblSeller == null)
            {
                return NotFound();
            }

            return tblSeller;
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSeller(int id, TblSeller tblSeller)
        {
            if (id != tblSeller.Sid)
            {
                return BadRequest();
            }

            _context.Entry(tblSeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSellerExists(id))
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

        // POST: api/Sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSeller>> PostTblSeller(TblSeller tblSeller)
        {
            _context.TblSellers.Add(tblSeller);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblSellerExists(tblSeller.Sid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblSeller", new { id = tblSeller.Sid }, tblSeller);
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSeller(int id)
        {
            var tblSeller = await _context.TblSellers.FindAsync(id);
            if (tblSeller == null)
            {
                return NotFound();
            }

            _context.TblSellers.Remove(tblSeller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSellerExists(int id)
        {
            return _context.TblSellers.Any(e => e.Sid == id);
        }
    }
}
