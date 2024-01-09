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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscount _context;
        public DiscountController(IDiscount context)
        {
            _context = context;
        }
        [HttpGet("GetDiscount")]
        public async Task<IEnumerable<Discount>> GetDiscount()
        {
            var pro = await _context.GetDiscount();
            return pro;
        }

        [HttpGet("GetDiscountId")]
        public async Task<ActionResult<Discount>> GetDiscountById(int discountid)
        {
            var pro = await _context.GetDiscountId(discountid);
            return pro;
        }

        [HttpPost("CreateDiscount")]
        public async Task<ActionResult<Discount>> CreateDiscount(Discount discount)
        {
            var pro = await _context.AddDiscount(discount);
            return pro;
        }
        [HttpPut("UpdateDiscount")]
        public async Task<ActionResult<Discount>> UpdateDiscount(Discount discount)
        {
            var pro = await _context.UpdateDiscount(discount);
            return pro;
        }
        [HttpDelete("DeleteDiscount")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _context.DeleteDiscount(id);
            return NoContent();
        }
    }
}
