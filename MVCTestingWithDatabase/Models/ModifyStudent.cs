using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTestingWithDatabase.Models
{
    public class ModifyStudent
    {
            [Required(ErrorMessage = "ID field is required")]
            public int ID { get; set; }
            [Required(ErrorMessage = "Name field is required")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Address field is required")]
            public string Addresss { get; set; }
            [Required(ErrorMessage = "Course field is required")]
            public string Course { get; set; }
            public string Image { get; set; }
    }
}