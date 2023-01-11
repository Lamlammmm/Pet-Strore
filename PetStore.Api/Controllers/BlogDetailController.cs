using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class BlogDetailController : BaseController
    {
        private readonly IBlogDetailService _blogDetailService;

        public BlogDetailController(IBlogDetailService blogDetailService)
        {
            _blogDetailService = blogDetailService;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _blogDetailService.GetAll();
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _blogDetailService.GetById(id);
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
                    httpStatusCode = 400,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpPost("Create-BlogDetail")]
        public async Task<IActionResult> Create([FromBody] BlogDetail model)
        {
            var item = await _blogDetailService.Create(model);
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

        [HttpPost("Update-BlogDetail")]
        public async Task<IActionResult> Update([FromBody] BlogDetail model)
        {
            var item = await _blogDetailService.Update(model);
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

        [HttpPost("Delete-BlogDetail")]
        public async Task<IActionResult> Delete([Required] IEnumerable<Guid> id)
        {
            var item = await _blogDetailService.DeleteById(id);
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
    }
}