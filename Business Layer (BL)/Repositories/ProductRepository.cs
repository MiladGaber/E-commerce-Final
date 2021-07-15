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
    public  class ProductRepository : BaseRepository<Product>
    {
        private DbContext EC_DbContext;
        public ProductRepository(DbContext EC_DBContext):base(EC_DBContext)
        {
            this.EC_DbContext = EC_DBContext;
        }

        //CRUD operations
        public List<Product> GetAllProduct()
        {
            return GetAll().ToList();
        }

        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void DeleteProduct(int id)
        {
            Delete(id);
        }

        public bool CheckProductExists(Product product)
        {
            return GetAny(l => l.Id == product.Id);
        }
        public Product GetProductById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
    }
}
