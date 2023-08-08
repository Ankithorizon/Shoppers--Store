using System;
using System.Collections.Generic;
using System.Text;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;
using ServiceLib.ShoppersStore.DTO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceLib.ShoppersStore.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Product> AddProduct(Product product);        
        Task<ProductFileAddResponse> ProductFileAdd(AddProductFile addProductFile);        
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<IEnumerable<ProductDTO>> SearchProducts(string searchValue, string categoryId);        
        Task<ProductDTO> GetProduct(int productId);        
        Task<ProductDTO> EditProduct(ProductDTO product);        
        Task<ProductFileEditResponse> ProductFileEdit(ProductFileEditResponse _productFile);        
        Task<ProductDiscountDTO> SetProductDiscount(ProductDiscountDTO discount);
        Task<bool> ResetProductDiscount(int productId);
    }
}
