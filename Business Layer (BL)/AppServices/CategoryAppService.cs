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
    public class CategoryAppService:AppServiceBase
    {
        //created ....mark
        //CURD

        public List<CategoryViewModel> GetAllCategory()
        {
            
            return Mapper.Map<List<CategoryViewModel>>(TheUnitOfWork.Category.GetAllCategory());
            Console.WriteLine("hi from CategoryAppService");
        }
        public CategoryViewModel GetCategory(int id)
        {
            return Mapper.Map<CategoryViewModel>(TheUnitOfWork.Category.GetCategoryById(id));
        }



        public bool SaveNewCategory(CategoryViewModel CategoryViewModel)
        {
            bool result = false;
            var category = Mapper.Map<Category>(CategoryViewModel);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCategory(CategoryViewModel CategoryViewModel)
        {
            var Category = Mapper.Map<Category>(CategoryViewModel);
            TheUnitOfWork.Category.Update(Category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(CategoryViewModel CategoryViewModel)
        {
            Category Category = Mapper.Map<Category>(CategoryViewModel);
            return TheUnitOfWork.Category.CheckCategoryExists(Category);
        }
    }
}
