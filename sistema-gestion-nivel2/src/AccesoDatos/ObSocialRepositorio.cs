using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;


namespace CapaDatos
{
    public class ObSocialRepositorio
    {
        public List<ObSocial> ObtenerObSocial()
        {
            using (var context = new AppDbContext())
            {
                return context.ObSocial.ToList();
            }
        }
        public ObSocial ObtenerObSocialPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.ObSocial.FirstOrDefault(os => os.obrcod == id);
            }
        }
        public void AgregarObSocial(ObSocial obSocial)
        {
            using (var context = new AppDbContext())
            {
                context.ObSocial.Add(obSocial);
                context.SaveChanges();
            }
        }
        public void ActualizarObSocial(ObSocial obSocial)
        {
            using (var context = new AppDbContext())
            {
                context.ObSocial.Update(obSocial);
                context.SaveChanges();
            }
        }
        public void EliminarObSocial(int id)
        {
            using (var context = new AppDbContext())
            {
                var obSocial = context.ObSocial.Find(id);
                if (obSocial != null)
                {
                    context.ObSocial.Remove(obSocial);
                    context.SaveChanges();
                }
            }
        }
    }
}
