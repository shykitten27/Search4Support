using System;
using System.ComponentModel.DataAnnotations;

namespace Search4Support.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string Name { get; set; }

        public AddCategoryViewModel()
        {
            //empty constructor
        }
    }
}