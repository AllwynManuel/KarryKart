using Contracts.IServices;
using Entities.Models.ProductClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parentcategory;

namespace KarryKart.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShipping _iShippingRepository;
        public ShippingController(IShipping iShippingRepository)
        {
            _iShippingRepository = iShippingRepository;
        }
        [HttpGet(" GetShipping")]
        public async Task<IEnumerable<Shipping>> GetShipping()
        {
            var shippings = await _iShippingRepository.GetShipping();
            return shippings;
        }
        [HttpGet("GetShippingbyId")]
        public async Task<ActionResult<Shipping>> GetShippingbyId(int id)
        {
            var Shipping = await _iShippingRepository.GetShippingId(id);
            return Shipping;
        }

        [HttpPost("AddShipping")]
        public async Task<ActionResult<Shipping>> AddShipping(Shipping shipping)
        {
            Shipping Response = new Shipping();
            if (shipping != null)
            {
                shipping.Id = 0;
                Response = await _iShippingRepository.AddShipping(shipping);
            }

            return Response;
        }
        [HttpPut("UpdateShipping/{id}")]
        public async Task<ActionResult<Shipping>> UpdateCategory(Shipping shipping)
        {


            var update = await _iShippingRepository.UpdateShipping(shipping);


            return update;
        }
        [HttpDelete("DeleteShipping/{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {


            await _iShippingRepository.DeleteShipping(id);
            return NoContent();
        }
    }
}
