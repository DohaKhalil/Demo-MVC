using Demo.DaL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DaL.ViweModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required ___")]
        [MaxLength(50)]
        [MinLength(4)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }
        [Range(18, 60)]
        public int Age { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public Deparntment? Deparntment { get; set; }
        public int? DeparntmentId { get; set; }
        public DateTime HireDate { get; set; }


    }
}
