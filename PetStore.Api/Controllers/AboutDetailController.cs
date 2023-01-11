using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class AboutDetailController : BaseController
    {
        private readonly IAboutDetailService _aboutDetailService;

        public AboutDetailController(IAboutDetailService aboutDetailService)
        {
            _aboutDetailService = aboutDetailService;
        }

        [HttpGet("Get-List")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _aboutDetailService.GetAll();
            if (list != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = list,
                    message = "Lấy dữ liệu thành công",
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _aboutDetailService.GetById(id);
            if (item != null)
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Lấy dữ liệu thành công",
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
        [HttpPost("Create-AboutDetail")]
        public async Task<IActionResult> Create([FromBody] AboutDetail model)
        {
            var item = await _aboutDetailService.Create(model);
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
        [HttpPost("Update-AboutDetail")]
        public async Task<IActionResult> Update([FromBody] AboutDetail model)
        {
            var item = await _aboutDetailService.Update(model);
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

        [HttpPost("Delete-AboutDetail")]
        public async Task<IActionResult> Delete([Required] IEnumerable<Guid> id)
        {
            var item = await _aboutDetailService.DeleteById(id);
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