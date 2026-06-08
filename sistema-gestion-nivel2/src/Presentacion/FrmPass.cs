using CapaPresentacion.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmPass : Form
    {
        private LoginManager loginManager;
        Tool tools = new Tool();
      
        public FrmPass()
        {
            InitializeComponent();
            loginManager = new LoginManager();
            loginManager.LoginResultado += OnLoginResultado;
        }

        private void OnLoginResultado(string usuario, int resultado)
        {
            if (resultado == 0)
            {
                MessageBox.Show("Límite de intentos superado.");
                Application.Exit();
            }
            else if (resultado == -1)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
            else
            {
                // Login exitoso
                if (this.Owner is FrmPrincipal principal)
                {
                    principal.IniciarSesion(usuario, resultado); // pasar nombre y ID
                }

                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string password = txtPass.Text;
            loginManager.ValidarLogin(usuario, password);
        }
    }
}
