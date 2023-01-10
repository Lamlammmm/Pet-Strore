using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.Service;

namespace PetStore.Api.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        //public async task<iactionresult> getall()
        //{
        //    var list = await _blogservice.getall();
        //    if(list != null)
        //    {
        //        return ok(new xbaseresult);
        //    }
        //}
    }
}
