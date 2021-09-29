using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggerWebApp.Models;

namespace LoggerWebApp.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class TblIlogDbLogsController : ControllerBase
    {
        private readonly ILogDBContext _context;

        public TblIlogDbLogsController(ILogDBContext context)
        {
            _context = context;
        }

        // GET: api/log
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblIlogDbLog>>> GetTblIlogDbLogs()
        {
            return await _context.TblIlogDbLogs.ToListAsync();
        }

        // GET: api/log/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblIlogDbLog>> GetTblIlogDbLog(long id)
        {
            var tblIlogDbLog = await _context.TblIlogDbLogs.FindAsync(id);

            if (tblIlogDbLog == null)
            {
                return NotFound();
            }

            return tblIlogDbLog;
        }

        //// PUT: api/log/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblIlogDbLog(long id, TblIlogDbLog tblIlogDbLog)
        //{
        //    if (id != tblIlogDbLog.FldIlogDbLogId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblIlogDbLog).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblIlogDbLogExists(id))
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

        // POST: api/log
        [HttpPost]
        public async Task<ActionResult<TblIlogDbLog>> PostTblIlogDbLog(TblIlogDbLog tblIlogDbLog)
        {
            _context.TblIlogDbLogs.Add(tblIlogDbLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblIlogDbLog", new { id = tblIlogDbLog.FldIlogDbLogId }, tblIlogDbLog);
        }

        //// DELETE: api/log/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblIlogDbLog(long id)
        //{
        //    var tblIlogDbLog = await _context.TblIlogDbLogs.FindAsync(id);
        //    if (tblIlogDbLog == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblIlogDbLogs.Remove(tblIlogDbLog);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TblIlogDbLogExists(long id)
        //{
        //    return _context.TblIlogDbLogs.Any(e => e.FldIlogDbLogId == id);
        //}
    }
}
