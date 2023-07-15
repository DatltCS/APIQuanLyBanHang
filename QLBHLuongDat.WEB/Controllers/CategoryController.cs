using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBHLuongDat.BLL;
using QLBHLuongDat.Common.Req;
using QLBHLuongDat.Common.Rsp;

namespace QLBHLuongDat.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult GetCategoryById([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(simpleReq.Id);
            return Ok(res);
        }
    }
}
