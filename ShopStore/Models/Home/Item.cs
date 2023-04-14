using ShopStore.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models.Home
{
    public class Item
    {
        public Tbl_Product Product { get; set; }
        public int QuantityOfItem { get; set; }



    }
}