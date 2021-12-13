using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Search4Support.ViewModels
{
    public class AddServiceViewModel
    {
        [Required(ErrorMessage = "Name of service is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description of service is required.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Description must be at least 3 and no more than 500 characters.")]
        public string Description { get; set; }
    }
}