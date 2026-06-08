using CapaNegocio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class FrmPacientes : Form
    {
        Tool tool = new Tool();
        public event EventHandler<ParametrosEventArgs>? ShowFrmImprimirRequested;
        private PacienteServicio pacienteServicio = new PacienteServicio();
        private MedicoServicio medicoServicio = new MedicoServicio();
        private ObSocialServicio obSocialServicio = new ObSocialServicio();
        private CliInterEncServicio cliInterEncServicio = new CliInterEncServicio();
        public FrmPacientes(int s, int user, int usertipo)
        {
            InitializeComponent();
            if (s == 1)
            {
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
        }
        public void ObtenerPacientes()
        {
            dataGridView1.DataSource = medicoServicio.ObtenerMedico();
            var datos = cliInterEncServicio.ObtenerInternacionesAbiertas();
            dataGridView2.DataSource = datos.Select(x => new
            {
                x.NroInt,
                Paciente = x.Paciente.apeynom,
                Medico = x.Medico.mednom,
                ObraSocial = x.ObSocial.obrnom,                
                Estado = x.estado == 0 ? "Abierta" : "Cerrada"
            }).ToList();          
        }
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (tool.Mensaje("", "Desea Imprimir la Planilla Seleccionada?", 1) == 1)
            {
                int nroPla = 0;
                int nroInt = 0;
                string periodo = "10";
                int op = 5;

                var args = new ParametrosEventArgs(nroPla, nroInt, periodo, op);

                ShowFrmImprimirRequested?.Invoke(this, args);
            }
            else
                tool.Mensaje("", "OPERACION CANCELADA!!", 0);
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            ObtenerPacientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CliInterEnc internacion = new CliInterEnc();
            internacion = cliInterEncServicio.ObtenerPorNroInternacion(5476);
            txtNro.Text = internacion.NroInt.ToString();
            txtPac.Text = internacion.Paciente.apeynom.ToString();
            txtMed.Text = internacion.Medico.mednom.ToString();
            txtOSocial.Text = internacion.ObSocial.obrnom.ToString();
        }
    }
}
