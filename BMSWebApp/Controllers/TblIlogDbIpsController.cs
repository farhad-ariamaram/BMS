using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggerWebApp.Models;

namespace LoggerWebApp.Controllers
{
    [Route("api/ip")]
    [ApiController]
    public class TblIlogDbIpsController : ControllerBase
    {
        private readonly ILogDBContext _context;

        public TblIlogDbIpsController(ILogDBContext context)
        {
            _context = context;
        }

        // GET: api/TblIlogDbIps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblIlogDbIp>>> GetTblIlogDbIps()
        {
            return await _context.TblIlogDbIps.ToListAsync();
        }

        // GET: api/TblIlogDbIps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblIlogDbIp>> GetTblIlogDbIp(int id)
        {
            var tblIlogDbIp = await _context.TblIlogDbIps.FindAsync(id);

            if (tblIlogDbIp == null)
            {
                return NotFound();
            }

            return tblIlogDbIp;
        }

        // PUT: api/TblIlogDbIps/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblIlogDbIp(int id, TblIlogDbIp tblIlogDbIp)
        //{
        //    if (id != tblIlogDbIp.FldIlogDbIpId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblIlogDbIp).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblIlogDbIpExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TblIlogDbIps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblIlogDbIp>> PostTblIlogDbIp(TblIlogDbIp tblIlogDbIp)
        {
            _context.TblIlogDbIps.Add(tblIlogDbIp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblIlogDbIp", new { id = tblIlogDbIp.FldIlogDbIpId }, tblIlogDbIp);
        }

        // DELETE: api/TblIlogDbIps/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblIlogDbIp(int id)
        //{
        //    var tblIlogDbIp = await _context.TblIlogDbIps.FindAsync(id);
        //    if (tblIlogDbIp == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblIlogDbIps.Remove(tblIlogDbIp);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblIlogDbIpExists(int id)
        //{
        //    return _context.TblIlogDbIps.Any(e => e.FldIlogDbIpId == id);
        //}
    }
}
