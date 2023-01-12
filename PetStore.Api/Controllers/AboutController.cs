using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Model.About;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("Get-All-Index")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllIndex()
        {
            var list = await _aboutService.GetAll();
            if (list != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = list,
                    message = "Lấy dữ liệu thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Lấy dữ liệu không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpGet("Get-by-Id")]
        public async Task<IActionResult> GetById([Required] Guid id)
        {
            var item = await _aboutService.GetById(id);
            if (item != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = item,
                    message = "Lấy dữ liệu thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Lấy dữ liệu không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpGet("Get-List-About")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _aboutService.GetAll();
            if (list != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = list,
                    message = "Lấy dữ liệu thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Lấy dữ liệu không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpGet("Get-All-Paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] AboutSeachContext ctx)
        {
            var item = await _aboutService.GetPaging(ctx);
            return Ok(item);
        }

        [HttpPost("Create-About")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] AboutModel model)
        {
            var item = await _aboutService.Create(model);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = item,
                    message = "Create thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Create không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpPost("Update-About")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] AboutModel model)
        {
            var item = await _aboutService.Update(model);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = item,
                    message = "Update thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Update không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpPost("Delete-Abouts")]
        public async Task<IActionResult> Deletes([Required] IEnumerable<Guid> id)
        {
            var item = await _aboutService.DeleteByIds(id);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = item,
                    message = "Delete thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Delete không thành công",
                    httpStatusCode = 400
                });
            }
        }

        [HttpPost("Delete-About")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var item = await _aboutService.Delete(id);
            if (item > 0)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    data = item,
                    message = "Delete thành công",
                    httpStatusCode = 200
                });
            }
            else
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    message = "Delete không thành công",
                    httpStatusCode = 400
                });
            }
        }
    }
}