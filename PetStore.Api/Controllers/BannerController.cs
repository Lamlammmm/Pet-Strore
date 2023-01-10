using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet("Get-List")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _bannerService.GetAll();
            if (item == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 404,
                    message = "Lấy dữ liệu không thành công"
                });
            }
            else
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Lấy dữ liệu thành công"
                });
            }
        }

        [HttpGet("Get-by-Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _bannerService.GetById(id);
            if (item == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 404,
                    message = "Lấy dữ liệu không thành công"
                });
            }
            else
            {
                return Ok(new XBaseResult
                {
                    success = true,
                    httpStatusCode = 200,
                    data = item,
                    message = "Lấy dữ liệu thành công"
                });
            }
        }

        [HttpPost("Create-Banner")]
        public async Task<IActionResult> Create(Banner model)
        {
            var item = await _bannerService.Create(model);
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
                    data = item,
                    message = "Create không thành công"
                });
            }
        }

        [HttpPut("Update-Banner")]
        public async Task<IActionResult> Update(Banner model)
        {
            var item = await _bannerService.Update(model);
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
                    data = item,
                    message = "Update không thành công"
                });
            }
        }

        [HttpDelete("Delete-Banner")]
        public async Task<IActionResult> Delete(IEnumerable<Guid> id)
        {
            var item = await _bannerService.DeleteById(id);
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
                    data = item,
                    message = "Delete không thành công"
                });
            }
        }
    }
}