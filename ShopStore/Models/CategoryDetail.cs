using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Models
{
    public class CategoryDetail
    {

            public int CategoryId { get; set; }
            [Required(ErrorMessage = "Nazwa kategorii jest Wymagana")]
            [StringLength(100,ErrorMessage = "Dopuszczalne są minimum 3 i maksimum 100 znaków", MinimumLength = 3)]
            public string CategoryName { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDelete { get; set; }

    }

    public class ProductDetail
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [StringLength(100, ErrorMessage = "Dopuszczalne są minimum 3 i maksimum 100 znaków", MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        [Range(1,50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        public Nullable<System.DateTime> Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }

        [Required]
        [Range(typeof(int),"1","500" , ErrorMessage = "Nieprawidłowa ilość")]
        public Nullable<int> Quantity { get; set; }

        [Required]
        [Range(typeof(decimal),"1","20000" , ErrorMessage ="NiePrawidłowa cena")]
        public Nullable<decimal> Price { get; set; }

        public SelectList Categories { get; set; }

    }
    
}

