using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Core.ShoppersStore.ShoppersStoreDB.Models
{
    public class DiscountHistory
    {
        public int DiscountHistoryId { get; set; }
        public int ProductId { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime DiscountEffectiveBegin { get; set; }
        public DateTime? DiscountEffectiveEnd { get; set; }

        public Product Product { get; set; }

    }
}
