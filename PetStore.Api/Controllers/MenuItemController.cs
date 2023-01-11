using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service.MenuItemService;
using System.ComponentModel.DataAnnotations;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet("Get-All")]
        public async Task<ActionResult> GetAll()
        {
            var list = await _menuItemService.GetAll();
            if (list != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = list,
                    message = "Lấy dữ liệu thành công"
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 404,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpGet("Get-By-Id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var item = await _menuItemService.GetById(id);
            if (item != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Lấy dữ liệu thành công"
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 404,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpPost("Create-MenuItem")]
        public async Task<IActionResult> Create([FromBody] MenuItem model)
        {
            var item = await _menuItemService.Create(model);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Create thành công"
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 400,
                    message = "Create không thành công"
                });
            }
        }

        [HttpPost("Update-MenuItem")]
        public async Task<ActionResult> Update([FromBody] MenuItem model)
        {
            var item = await _menuItemService.Update(model);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Update thành công"
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 400,
                    message = "Update không thành công"
                });
            }
        }

        [HttpPost("Delete-MenuItem")]
        public async Task<ActionResult> Delete([Required] IEnumerable<Guid> id)
        {
            var item = await _menuItemService.DeleteById(id);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Delete thành công"
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 401,
                    message = "Delete không thành công"
                });
            }
        }
    }
}