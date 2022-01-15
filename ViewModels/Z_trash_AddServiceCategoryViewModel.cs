using System;
using System.ComponentModel.DataAnnotations;

namespace Search4Support.ViewModels
{
    public class Z_trash_AddServiceCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters long")]
        public string Name { get; set; }

        public Z_trash_AddServiceCategoryViewModel()
        {
            //empty constructor
        }
    }
}
