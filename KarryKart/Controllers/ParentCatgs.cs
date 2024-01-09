using Contracts.IServices;
using Entities.Models.ParentCatgoriesClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KarryKart.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParentCatgs : ControllerBase
    {
        private readonly IParentCategory _context;
        public ParentCatgs(IParentCategory context)
        {
                _context = context;
        }
        [HttpGet("GetParentCatg")]
        public async Task<IEnumerable<Parent_Catg>> GetParentCatg()
        {
            var pro = await _context.GetParentCat();
            return pro;
        }
        
        [HttpGet("GetParentCatgId")]
        public async Task<ActionResult<Parent_Catg>> GetParentById(int parcatgId)
        {
            var pro = await _context.GetParentCatId(parcatgId);
            return pro;
        }

        [HttpPost("CreateParentCatg")]
        public async Task<ActionResult<Parent_Catg>> CreateParentCatg(Parent_Catg parent_Catg)
        {
            var pro = await _context.AddParentCat(parent_Catg);
            return pro;
        }
        [HttpPut("UpdateParentCatg")]
        public async Task<ActionResult<Parent_Catg>> UpdateParentCatg(Parent_Catg parent_Catg)
        {
            var pro = await _context.UpdateParentCat(parent_Catg);
            return pro;
        }
        [HttpDelete("DeleteParentCatg")]
        public async Task<IActionResult> DeleteParentCatg(int id)
        {
            await _context.DeleteParentCat(id);
            return NoContent();
        }
    }
}
