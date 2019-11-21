using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name= "Name")]
        [Required(ErrorMessage = "Name must be given.")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Price")]
        [DataType(DataType.Currency)]
        [Range(0.1, double.MaxValue, ErrorMessage ="Price must be grater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Category must be given")]
        [Display(Name="Category")]
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
