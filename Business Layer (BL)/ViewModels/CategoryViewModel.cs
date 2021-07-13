using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<product> product { get; set; } //updated relation in data layer ..Y
    }
}
