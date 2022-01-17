using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class AddProviderViewModel
    { 
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Name must be between 10 and 20 characters long.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required!")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Name must be between 20 and 100 characters long.")]
        public string Address { get; set; }

        public string MapLink { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters long.")]
        public string Description { get; set; }

        public AddProviderViewModel()
        {
            //empty constructor
        }
    }
}