using System;
using System.Collections.Generic;
using System.Text;
using EF.Core.ShoppersStore.ShoppersStoreDB.Models;

namespace ServiceLib.ShoppersStore.Repositories
{
    public class DistinctProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.ProductId == y.ProductId;
        }

        public int GetHashCode(Product obj)
        {
            return obj.ProductId.GetHashCode();
        }
    }
}
