using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MedicoRepositorio
    {
        public List<Medicos> ObtenerMedicos()
        {
            using (var context = new AppDbContext())
            {
                return context.Medicos.ToList();
            }
        }
        public string ObtenerNombreMedico(int medmat)
        {
            using (var context = new AppDbContext())
            {
                var medico = context.Medicos.FirstOrDefault(m => m.medmat == medmat);
                return medico?.mednom ?? "Desconocido";
            }
        }
    }
}
