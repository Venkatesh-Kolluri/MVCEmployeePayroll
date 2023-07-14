using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer.Models
{
    public class AdminModel
    {
        [Required(ErrorMessage = "{0} Enter values")]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public string Password { get; set; }
    }
}
