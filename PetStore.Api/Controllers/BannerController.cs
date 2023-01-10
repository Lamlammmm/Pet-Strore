﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pet_Store.Data.Entities;
using PetStore.Service;
using WebAdmin_API.Common;

namespace PetStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
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
    }
}