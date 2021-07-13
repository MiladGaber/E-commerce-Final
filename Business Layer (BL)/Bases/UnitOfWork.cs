using Business_Layer__BL_.Interfaces;
using Business_Layer__BL_.Repositories;
using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Bases

    //created...mark
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }

        #endregion

        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();//
            // Avoid load navigation properties
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }

        public OrderRepository order;//=> throw new NotImplementedException();
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        public AccountRepository account;//=> throw new NotImplementedException();
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext);
                return account;
            }
        }

        public RoleRepository role;//=> throw new NotImplementedException();
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }

       public ProductRepository product;  // => throw new NotImplementedException();
        public ProductRepository Product
        {
            get
            {
                if (Product == null)
                {
                    product = new ProductRepository(EC_DbContext);
                }
                return Product;
            }
        }

        public CategoryRepository category;  // => throw new NotImplementedException();
        public CategoryRepository Category
        {
            get
            {
                if (Category == null)
                {
                    category = new CategoryRepository(EC_DbContext);
                }
                return Category;
            }
        }


    }
}
