using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class UserRepositorio
    {
        public List<CliPlaUser> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.CliPlaUser.ToList();
            }
        }
    }
}
