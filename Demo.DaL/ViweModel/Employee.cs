using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DaL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
      
        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public Deparntment? Deparntment { get; set; }
        public int? DeparntmentId { get; set; }
        public DateTime HireDate { get;set; }




    }
}
