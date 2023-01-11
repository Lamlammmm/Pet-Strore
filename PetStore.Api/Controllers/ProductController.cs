using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Model.Product;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProducService _producService;

        public ProductController(IProducService producService)
        {
            _producService = producService;
        }

        [HttpGet("Get-List-Product")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _producService.GetAll();
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

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _producService.GetById(id);
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

        [HttpGet("Get-All-Paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] ProductSeachContext ctx)
        {
            var item = await _producService.GetAllPaging(ctx);
            return Ok(item);
        }

        [HttpPost("Create-Product")]
        public async Task<IActionResult> Create([FromForm] Product model)
        {
            var item = await _producService.Create(model);
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
                    success = true,
                    httpStatusCode = 200,
                    message = "Create không thành công"
                });
            }
        }

        [HttpPost("Update-Product")]
        public async Task<IActionResult> Update([FromForm] Product model)
        {
            var item = await _producService.Update(model);
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
                    success = true,
                    httpStatusCode = 200,
                    message = "Update không thành công"
                });
            }
        }

        [HttpPost("Delete-Product")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var item = await _producService.Delete(id);
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
                    success = true,
                    httpStatusCode = 200,
                    message = "Delete không thành công"
                });
            }
        }

        [HttpPost("Delete-Products")]
        public async Task<IActionResult> Deletes([Required] IEnumerable<Guid> id)
        {
            var item = await _producService.DeleteByIds(id);
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
                    success = true,
                    httpStatusCode = 200,
                    message = "Delete không thành công"
                });
            }
        }
    }
}