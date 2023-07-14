using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace CommanLayer.Models
{
    public class EmployeeModel
    {
        public readonly object employeeBL;

        public int EmpId { get; set; }
        [Required(ErrorMessage ="{0} Enter values")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public string Profile_Image { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        [Range(20000, 200000)]
        public double Salary { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
      
        public string Notes { get; set; }
        public bool IsTrash { get; set; }
        [Required(ErrorMessage = "{0} Enter values")]
        public DateTime UpdateDate { get; set; }

    }
}
