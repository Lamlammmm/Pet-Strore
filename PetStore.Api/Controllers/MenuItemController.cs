using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pet_Store.Data.Entities;
using PetStore.Common.Extensions;
using PetStore.Model.Enums;
using PetStore.Model.MenuItem;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
using System.Data;
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

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new MenuItemModel
            {
                AvailableTypeMenu = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = ((int)TypeMenuCode.system).ToString(),
                        Text = TypeMenuCode.system.GetEnumDescription()
                    },
                    new SelectListItem
                    {
                        Value = ((int)TypeMenuCode.category).ToString(),
                        Text = TypeMenuCode.category.GetEnumDescription()
                    }
                }
            };

            return Ok(new XBaseResult
            {
                data = model
            });
        }

        private async void UpdataData(MenuItemModel model)
        {
            model.AvailableTypeMenu = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = ((int)TypeMenuCode.system).ToString(),
                    Text = TypeMenuCode.system.GetEnumDescription()
                },
                new SelectListItem
                {
                    Value = ((int)TypeMenuCode.category).ToString(),
                    Text = TypeMenuCode.category.GetEnumDescription()
                }
            };
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
                    httpStatusCode = 400,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpGet("Get-menu-system")]
        public async Task<ActionResult> GetMenuSystem()
        {
            var list = await _menuItemService.GetMenuSystem();
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
                    httpStatusCode = 400,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpGet("Get-menu-category")]
        public async Task<ActionResult> GetMenuCategory()
        {
            var list = await _menuItemService.GetMenuCategory();
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
                    httpStatusCode = 400,
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
                UpdataData(item);
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
                    httpStatusCode = 400,
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

        [HttpPost("Delete-MenuItems")]
        public async Task<ActionResult> Deletes([Required] IEnumerable<Guid> id)
        {
            var item = await _menuItemService.DeleteByIds(id);
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
                    httpStatusCode = 400,
                    message = "Delete không thành công"
                });
            }
        }

        [HttpPost("Delete-MenuItem")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _menuItemService.Delete(id);
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
                    httpStatusCode = 400,
                    message = "Delete không thành công"
                });
            }
        }

        [HttpGet("Get-All-Paging")]
        public async Task<ActionResult> GetAllPaging([FromQuery] MenuItemSeachContext ctx)
        {
            var item = await _menuItemService.GetAllPaging(ctx);
            return Ok(item);
        }
    }
}