using PagedList;
using ShopStore.DATABASE;
using ShopStore.EntityDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopStore.Models.Home
{
    public class HomeIndexViewModel
    {
        public DatabaseUnitOfWork _unitOfWork = new DatabaseUnitOfWork();
        dbMyOnlineShopStore dbShop = new dbMyOnlineShopStore();

        public IPagedList<Tbl_Product> ListOffProducts { get; set; }


        public HomeIndexViewModel CreateModel(string SearchKey, int  pageSize,int? page)
        {

            SqlParameter[] paramSQL = new SqlParameter[]
            {
              new SqlParameter("@search", SearchKey??(object)DBNull.Value)
            };


            IPagedList<Tbl_Product> data = dbShop.Database.SqlQuery<Tbl_Product>("GetBySearch @search", paramSQL).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel()
            {
                ListOffProducts = data
            };
        }
    }
}