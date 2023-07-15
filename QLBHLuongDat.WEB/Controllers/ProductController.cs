using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBHLuongDat.BLL;
using QLBHLuongDat.Common.Req;
using QLBHLuongDat.Common.Rsp;

namespace QLBHLuongDat.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpPost("create-product")]
        public IActionResult CreateProuct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }

        [HttpPost("update-product")]
        public IActionResult UpdateProduct([FromBody] ProductReq reqProduct)
        {
            var res = new SingleRsp();
            res = productSvc.UpdateProduct(reqProduct);
            return Ok(res);
        }

        [HttpPost("get-by-name")]
        public IActionResult GetProdcutByName([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Read(simpleReq.Keyword);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult GetAllCategoies()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }
    }


}
