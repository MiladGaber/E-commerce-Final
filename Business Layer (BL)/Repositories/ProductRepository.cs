using Business_Layer__BL_.Bases;
using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Repositories
{
    // created by... mark..ta7yate
    public  class ProductRepository : BaseRepository<product>
    {
        private DbContext EC_DbContext;
        public ProductRepository(DbContext EC_DBContext):base(EC_DBContext)
        {
            this.EC_DbContext = EC_DBContext;
        }

        //CRUD operations
        public List<product> GetAllProduct()
        {
            return GetAll().ToList();
        }

        public bool InsertProduct(product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }

        public bool CheckProductExists(product product)
        {
            return GetAny(l => l.Id == product.Id);
        }
        public product GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
    }
}
