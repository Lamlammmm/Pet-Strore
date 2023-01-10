﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using Service.AboutService;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
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
                    httpStatusCode = 404
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
                    httpStatusCode = 404
                });
            }
        }
        [HttpPost("Create-About")]
        public async Task<IActionResult> Create([FromForm] About model)
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
                    httpStatusCode = 404
                });
            }
        }
        [HttpPut("Update-About")]
        public async Task<IActionResult> Update([FromForm] About model)
        {
            var item = await _aboutService.Update(model);
            if(item > 0)
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
                    httpStatusCode = 404
                });
            }
        }
        [HttpDelete("Delete-About")]
        public async Task<IActionResult> Delete([Required]IEnumerable<Guid> id)
        {
            var item = await _aboutService.DeleteById(id);
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
                    httpStatusCode = 404
                });
            }
        }
    }
}