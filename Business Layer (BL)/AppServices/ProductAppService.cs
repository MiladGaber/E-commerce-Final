using Business_Layer__BL_.Bases;
using Business_Layer__BL_.ViewModels;
using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.AppServices
{
    public class ProductAppService:AppServiceBase
    {
        //Created...mark
        //CURD

        public List<ProductViewModel> GetAllProduct()
        {

            return Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetAllProduct());
        }
        public ProductViewModel GetProduct(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetProductById(id));
        }



        public bool SaveNewOrder(ProductViewModel ProductViewModel)
        {
            bool result = false;
            var Product = Mapper.Map<Product>(ProductViewModel);
            if (TheUnitOfWork.Product.Insert(Product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrder(ProductViewModel ProductViewModel)
        {
            var Product = Mapper.Map<Product>(ProductViewModel);
            TheUnitOfWork.Product.Update(Product);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrder(int id)
        {
            bool result = false;

            TheUnitOfWork.Order.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(ProductViewModel ProductViewModel)
        {
            Product product = Mapper.Map<Product>(ProductViewModel);
            return TheUnitOfWork.Product.CheckProductExists(product);
        }
    }
}
