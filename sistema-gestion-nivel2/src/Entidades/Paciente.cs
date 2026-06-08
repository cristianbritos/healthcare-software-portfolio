using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidades
{
    [Table("Paciente")]
    public class Paciente
    {
        public int Id { get; set; }
        public string apeynom { get; set; }
        public decimal? docnro { get; set; }
        public decimal? nroafil { get; set; }
        public string? telefono { get; set; }
        public DateTime? fechaNac { get; set; }
    }
}
