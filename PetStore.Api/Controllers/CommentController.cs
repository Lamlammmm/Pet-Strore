using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Model.Comment;
using PetStore.Service;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _commentService.GetAll();
            if(item != null)
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
                    httpStatusCode= 400,
                    message = "Lấy dữ liệu không thành công"
                });
            }
        }

        [HttpGet("Get-By-Id")]
        public async Task<IActionResult> GetById(Guid id) 
        {
            var item = await _commentService.GetById(id);
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
        public async Task<IActionResult> GetAllPaging([FromQuery] CommentSeachContext ctx)
        {
            var item = await _commentService.GetAllPaging(ctx);
            return Ok(item);
        }

        [HttpPost("Create-Comment")]
        public async Task<IActionResult> Create([FromBody] Comment model)
        {
            var item = await _commentService.Create(model);
            if(item > 0)
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
    }
}
