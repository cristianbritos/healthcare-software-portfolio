using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    [Table("ObSocial")]
    public class ObSocial
    {
        [Key]
        public int obrcod { get; set; }
        public string obrnom { get; set; }
        public string obrabr { get; set; }
    }
}
