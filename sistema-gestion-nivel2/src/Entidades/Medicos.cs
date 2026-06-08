using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    [Table("Medicos")]
    public class Medicos
    {
        [Key]
        public int medmat { get; set; }
        public string mednom { get; set; }
        public int? meddoc { get; set; }
    }
}
