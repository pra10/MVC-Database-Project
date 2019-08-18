using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MVCTestingWithDatabase.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Roll field is required")]
        public int Roll { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course field is required")]
        public string Course { get; set; }
    }

}