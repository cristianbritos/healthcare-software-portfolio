using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class PacienteServicio
    {
        private readonly PacienteRepositorio pacienteRepositorio = new PacienteRepositorio();
        public List<Paciente> ObtenerPacientes()
        {
            try
            {
                return pacienteRepositorio.ObtenerPacientes();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, log o re-lanzar según sea necesario
                throw new Exception("Error al obtener los pacientes", ex);
            }
        }
    }
}
