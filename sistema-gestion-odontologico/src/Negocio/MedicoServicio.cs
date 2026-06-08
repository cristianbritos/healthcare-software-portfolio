using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MedicoServicio
    {
        private readonly MedicoRepositorio medicoRepositorio = new MedicoRepositorio();
        public List<Medicos> ObtenerMedico()
        {
            try 
            {
                return medicoRepositorio.ObtenerMedicos();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, log o re-lanzar según sea necesario
                throw new Exception("Error al obtener los médicos", ex);
            }
        }
        public string ObtenerNombreMedico(int medmat)
        {
            try
            {
                return medicoRepositorio.ObtenerNombreMedico(medmat);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, log o re-lanzar según sea necesario
                throw new Exception("Error al obtener el nombre del médico", ex);
            }
        }
    }
}
