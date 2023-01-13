using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pet_Store.Data.Entities;
using PetStore.Common.Extensions;
using PetStore.Model;
using PetStore.Model.Banner;
using PetStore.Model.Blog;
using PetStore.Model.Enums;
using PetStore.Model.MenuItem;
using PetStore.Service;
using System.ComponentModel.DataAnnotations;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var item = await _bannerService.GetAll();
            if (item == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 400,
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
            UpdataData(item);
            if (item == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = 400,
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

        [HttpGet("Get-All-Paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] BannerSeachContext cxt)
        {
            var item = await _bannerService.GetAllPaging(cxt);
            return Ok(item);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new BannerModel
            {
                AvailableTypeBanner = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = ((int)TypeBannerCode.system).ToString(),
                        Text = TypeBannerCode.system.GetEnumDescription()
                    },
                    new SelectListItem
                    {
                        Value = ((int)TypeBannerCode.category).ToString(),
                        Text = TypeBannerCode.category.GetEnumDescription()
                    }
                }
            };

            return Ok(new XBaseResult
            {
                data = model
            });
        }

        private async void UpdataData(BannerModel model)
        {
            model.AvailableTypeBanner = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = ((int)TypeBannerCode.system).ToString(),
                    Text = TypeBannerCode.system.GetEnumDescription()
                },
                new SelectListItem
                {
                    Value = ((int)TypeBannerCode.category).ToString(),
                    Text = TypeBannerCode.category.GetEnumDescription()
                }
            };
        }

        [HttpPost("Create-Banner")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BannerModel model)
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

        [HttpPost("Update-Banner")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] BannerModel model)
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

        [HttpPost("Delete-Banners")]
        public async Task<IActionResult> Deletes([Required] IEnumerable<Guid> id)
        {
            var item = await _bannerService.DeleteByIds(id);
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

        [HttpPost("Delete-Banner")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            var item = await _bannerService.Delete(id);
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