using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    //类别类
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
