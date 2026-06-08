using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaDatos
{
    public class PacienteRepositorio
    {
        public List<Paciente> ObtenerPacientes()
        {
            using (var context = new AppDbContext())
            {
                return context.Pacientes.ToList();
            }
        }
        public Paciente ObtenerPacientePorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Pacientes.Find(id);
            }
        }
        public void AgregarPaciente(Paciente paciente)
        {
            using (var context = new AppDbContext())
            {
                context.Pacientes.Add(paciente);
                context.SaveChanges();
            }
        }
        public void ActualizarPaciente(Paciente paciente)
        {
            using (var context = new AppDbContext())
            {
                context.Pacientes.Update(paciente);
                context.SaveChanges();
            }
        }
        public void EliminarPaciente(int id)
        {
            using (var context = new AppDbContext())
            {
                var paciente = context.Pacientes.Find(id);
                if (paciente != null)
                {
                    context.Pacientes.Remove(paciente);
                    context.SaveChanges();
                }
            }
        }
    }
}
