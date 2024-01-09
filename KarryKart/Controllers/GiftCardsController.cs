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
    public class GiftCardsController : ControllerBase
    {
        private readonly IGiftCard _giftcardservice;
        public GiftCardsController(IGiftCard giftcard)
        {
            _giftcardservice = giftcard;
        }
        [HttpGet("GetGiftCard")]
        public async Task<IEnumerable<GiftCard>> GetGiftCard()
        {
            var pro = await _giftcardservice.GetGiftCard();
            return pro;
        }

        [HttpGet("GetGiftCardId")]
        public async Task<ActionResult<GiftCard>> GetGiftCardById(int giftCardid)
        {
            var pro = await _giftcardservice.GetGiftCardId(giftCardid);
            return pro;
        }

        [HttpPost("CreateGiftCard")]
        public async Task<ActionResult<GiftCard>> CreateGiftCard(GiftCard giftCard)
        {
            var pro = await _giftcardservice.AddGiftCard(giftCard);
            return pro;
        }
        [HttpPut("UpdateGiftCard")]
        public async Task<ActionResult<GiftCard>> UpdateGiftCard(GiftCard giftCard)
        {
            var pro = await _giftcardservice.UpdateGiftCard(giftCard);
            return pro;
        }
        [HttpDelete("DeleteGiftCard")]
        public async Task<IActionResult> DeleteGiftCard(int id)
        {
            await _giftcardservice.DeleteGiftCard(id);
            return NoContent();
        }
    }
}
