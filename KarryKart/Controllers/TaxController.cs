using Contracts.IServices;
using Entities.Models.ProductClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarryKart.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITax _context;
        public TaxController(ITax context)
        {
            _context = context;
        }
        [HttpGet("GetTax")]
        public async Task<IEnumerable<Tax>> GetTax()
        {
            var pro = await _context.GetTax();
            return pro;
        }

        [HttpGet("GetTaxId")]
        public async Task<ActionResult<Tax>> GetTaxById(int taxid)
        {
            var pro = await _context.GetTaxId(taxid);
            return pro;
        }

        [HttpPost("CreateTax")]
        public async Task<ActionResult<Tax>> CreateParentCatg(Tax tax)
        {
            var pro = await _context.AddTax(tax);
            return pro;
        }
        [HttpPut("UpdateTax")]
        public async Task<ActionResult<Tax>> UpdateParentCatg(Tax tax)
        {
            var pro = await _context.UpdateTax(tax);
            return pro;
        }
        [HttpDelete("DeleteTax")]
        public async Task<IActionResult> DeleteTax(int id)
        {
            await _context.DeleteTax(id);
            return NoContent();
        }
    }
}
