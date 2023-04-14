using ShopStore.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.EntityDB
{
    public class DatabaseUnitOfWork : IDisposable
    {
        private dbMyOnlineShopStore DBEntity = new dbMyOnlineShopStore();

        public EntityDB<Tbl_EntityType> GetDatabaseInstance<Tbl_EntityType>()where Tbl_EntityType : class
        {
            return new GenerateEntityDB<Tbl_EntityType>(DBEntity);
        }

        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}