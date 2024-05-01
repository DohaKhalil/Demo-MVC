using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DaL.Model
{
    public class Deparntment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 50)]
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Employee> Employees { get; set;} = new List<Employee>();

    }
}
