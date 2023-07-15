using QLBHLuongDat.Common.BLL;
using QLBHLuongDat.Common.Req;
using QLBHLuongDat.Common.Rsp;
using QLBHLuongDat.DAL;
using QLBHLuongDat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBHLuongDat.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        ProductRep req = new ProductRep();

        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Read(String name)
        {
            var res = new SingleRsp();
            var m = _rep.Read(name);
            res.Data = m;
            return res;
        }
        public ProductSvc()
        {
            productRep = new ProductRep();
        }

        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;
        }

        public SingleRsp SearchProduct(SearchProductReq s)
        {
            var res = new SingleRsp();
            //Lấy danh sách sãn phẩm theo từ khóa
            var products = productRep.SaearchProduct(s.Keyword);
            //Xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount = products.Count;
            totalPages = (pCount % s.Size == 0) ? pCount / s.Size : 1 + (pCount / s.Size);

            var p = new
            {
                Data = products.Skip(offset).Take(s.Size).ToList(),
                Page = s.Page,
                Size = s.Size
            };
            res.Data = p;
            return res;
        }

        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = req.UpdateProduct(product);
            return res;
        }
    }
}
