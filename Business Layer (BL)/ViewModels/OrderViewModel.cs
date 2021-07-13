using Data_Access_Layer__DAL_;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.ViewModels
{
    public class OrderViewModel
    {   //need to adding some validations
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]//...mark
        public string date { get; set; }
        public string description { get; set; }
        [DataType(DataType.Currency)]//...mark
        public int totalPrice { get; set; } 
        public int? discount { get; set; }
        public ICollection<product> product { get; set; }

        //public Category category { get; set; } // (removed relation)...Y
    }
}
