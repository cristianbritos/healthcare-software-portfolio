using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UserServicio
    {
        private readonly UserRepositorio userRepositorio = new UserRepositorio();

        public List<CliPlaUser> ObtenerTodos()
        {
            try
            {
                return userRepositorio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, log o re-lanzar según sea necesario
                throw new Exception("Error al obtener los usuarios", ex);
            }
        }
    }
}
