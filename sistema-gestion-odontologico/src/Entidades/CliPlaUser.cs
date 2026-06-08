using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    [Table("CliPlaUser")]
    public class CliPlaUser
    {
        public int Id { get; set; }

        public string usuario { get; set; }
        public string password { get; set; }
        public int tipo { get; set; }
        public string? apeYnom { get; set; }
        public string? email { get; set; }
        public int? mat { get; set; }
        public int? estado { get; set; }
    }
}
