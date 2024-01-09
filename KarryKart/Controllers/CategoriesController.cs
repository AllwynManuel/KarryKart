using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Data;
using Entities.Models.CategoryClass;
using Entities.Models.ManufacturesClass;
using Microsoft.AspNetCore.Authorization;
using Contracts.IServices;

namespace KarryKart.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }
        [HttpGet("GetCategory")]
        public async Task<IEnumerable<Category>> GetCategory()
        {
            var category = await _category.GetCategory();
            return category;
        }
        [HttpGet("GetCategoryByID")]
        public async Task<ActionResult<Category>> GetCategoryId(int id)
        {
            var manufracturer = await _category.GetCategoryId(id);
            return manufracturer;
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<Category>> CreateManufacturer(Category category)
        {
            Category obj = new Category();
            if (category != null)
            {
                obj = await _category.AddCategory(category);
            }
            return obj;
        }
        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<Category>> UpdateManufacturer(Category category)
        {
            var update = await _category.UpdateCategory(category);
            return update;
        }

        [HttpDelete("DeletePlayer")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _category.DeleteCategory(id);
            return NoContent();
        }
    }
}
