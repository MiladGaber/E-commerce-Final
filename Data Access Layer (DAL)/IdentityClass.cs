using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer__DAL_
{
    public class AppIdentityUser : IdentityUser
    {
    }

    public class AppUserStore : UserStore<AppIdentityUser>
    {
        public AppUserStore() : base(new ApplicationDBContext()) { }
        public AppUserStore(DbContext d) : base(d) { }
    }

    public class AppUserManager : UserManager<AppIdentityUser>
    {
        public AppUserManager() : base(new AppUserStore()) { }
        public AppUserManager(DbContext d) : base(new AppUserStore(d)) { }
    }

    public class AppRoleManager : RoleManager<IdentityRole>
    {
        public AppRoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public AppRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public int totalPrice { get; set; }
        public int discount { get; set; }
        // public Category category { get; set; }  //(removed relation)..Y
        public virtual ICollection<Product> product { get; set; }
        public virtual AppIdentityUser appUser { get; set; }
    }

    public class Category   // updated from types to Categories  ..Milad
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public virtual ICollection<Product> product { get; set; }
    }

    public class Product 
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
        public string img { get; set; }
        public virtual Order order { get; set; } // Why ???  
        public virtual Category category { get; set; }

    }

    public class ApplicationDBContext : IdentityDbContext<AppIdentityUser>
    {
        //
        //"Data Source=.;Initial Catalog=Final-ECommerce;Integrated Security=True"

        public ApplicationDBContext() : base(@"Data Source=.;Initial Catalog='Final-eCommerce';Integrated Security=True")
        {

        }
        public virtual DbSet<Product> Products { get; set; }    //updated class Name from products to Products
        public virtual DbSet<Order> Orders { get; set; }    
        public virtual DbSet<Category> Categories { get; set; }  // updated from types to Categories  ..Milad
    }
}
