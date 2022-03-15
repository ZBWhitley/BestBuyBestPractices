using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _prodConn;

        public DapperProductRepository(IDbConnection prodConnection)
        {
            _prodConn = prodConnection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var prods = _prodConn.Query<Product>("Select * from products");
            return prods;
        }

        public void CreateProduct(int newProductID, string newProductName, double newPrice, int newCategoryID, int newOnSale, int newStockLevel) 
        {
            _prodConn.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName)",
            new { productName = newProductName });
        }
    }
}
