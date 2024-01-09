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
    public class RentalController : ControllerBase
    {
        private readonly IRental _iRentalRepository;
        public RentalController(IRental iRentalRepository)
        {
            _iRentalRepository = iRentalRepository;
        }

        [HttpGet(" GetRental")]
        public async Task<IEnumerable<Rental>> GetRental()
        {
            var Rental = await _iRentalRepository.GetRental();
            return Rental;
        }
        [HttpGet("GetRentalbyId")]
        public async Task<ActionResult<Rental>> GetRentalbyId(int Id)
        {
            var rental = await _iRentalRepository.GetRentalbyId(Id);
            return rental;
        }
        [HttpPost("AddRental")]
        public async Task<ActionResult<Rental>> AddRental(Rental rental)
        {
            Rental Response = new Rental();
            if (rental != null)
            {
                rental.Id = 0;
                Response = await _iRentalRepository.AddRental(rental);
            }

            return Response;
        }
        [HttpPut("UpdateRental/{id}")]
        public async Task<ActionResult<Rental>> UpdateRental(Rental rental)
        {


            var update = await _iRentalRepository.UpdateRental(rental);


            return update;
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {


            await _iRentalRepository.DeleteRental(id);
            return NoContent();
        }
    }
}
