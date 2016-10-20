using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataLab.Models
{
    public class Employment
    {
        public Employment()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Person person { get; set;}

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
