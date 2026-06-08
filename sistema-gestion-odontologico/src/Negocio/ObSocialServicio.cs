using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ObSocialServicio
    {
        private readonly ObSocialRepositorio obSocialRepositorio = new ObSocialRepositorio();
        public List<ObSocial> ObtenerObSocial()
        {
            try
            {
                return obSocialRepositorio.ObtenerObSocial();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, log o re-lanzar según sea necesario
                throw new Exception("Error al obtener las obras sociales", ex);
            }
        }
    }
}
