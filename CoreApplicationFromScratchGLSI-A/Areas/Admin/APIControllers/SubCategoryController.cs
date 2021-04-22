using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Areas.Admin.Services;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _isubcategoryservice;
        public SubCategoryController(ISubCategoryService _isubcategoryservice)
        {
            this._isubcategoryservice = _isubcategoryservice;
        }
        [HttpGet("GetByCat")]
        public async Task<IActionResult> GetSubCatByCat(Category category)
        {
            var subcategories = await _isubcategoryservice.GetSubCatByCategory(category);
            return Ok(subcategories);
        }

    }
}
