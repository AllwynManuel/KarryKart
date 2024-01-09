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
    public class VendorsController : ControllerBase
    {
        private readonly IVendors _context;
        public VendorsController(IVendors context)
        {
            _context = context;
        }
        [HttpGet("GetVendors")]
        public async Task<IEnumerable<Vendors>> GetVendors()
        {
            var pro = await _context.GetVendors();
            return pro;
        }

        [HttpGet("GetVendorsId")]
        public async Task<ActionResult<Vendors>> GetPVendorsById(int vendorsid)
        {
            var pro = await _context.GetVendorsId(vendorsid);
            return pro;
        }

        [HttpPost("CreateVendors")]
        public async Task<ActionResult<Vendors>> CreateVendors(Vendors vendors)
        {
            var pro = await _context.AddVendors(vendors);
            return pro;
        }
        [HttpPut("UpdateVendors")]
        public async Task<ActionResult<Vendors>> UpdatePVendors(Vendors vendors)
        {
            var pro = await _context.UpdateVendors(vendors);
            return pro;
        }
        [HttpDelete("DeleteVendors")]
        public async Task<IActionResult> DeleteVendors(int id)
        {
            await _context.DeleteVendors(id);
            return NoContent();
        }
    }
}
