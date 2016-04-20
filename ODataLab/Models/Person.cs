using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataLab.Models
{
    public class Person
    {
        public Person()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid EmploymentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
