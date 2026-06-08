using CapaPresentacion.clases;
using System.Data;
using System.Runtime.InteropServices;
using CapaNegocio;
using System.Security.Cryptography.Xml;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        private string Usuario;
        private int idUsuario;
        private int Usertipo;
        private Tool tool = new Tool();

        public FrmPrincipal()
        {
            InitializeComponent();
            customizeDesing();
            this.Usuario = string.Empty;
            this.idUsuario = 0;
            this.Usertipo = 1; // Asignar un valor por defecto
        }

        // Importar funciones de la API de Windows para mover el formulario

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        // FIN
        // Configuración del formulario principal
        private void customizeDesing()
        {
            panelInforSubmenu.Visible = false;
            panelFacturSubmenu.Visible = false;
            panelLiquidarSubmenu.Visible = false;
            //..
        }

        private void hideSubMenu()
        {
            panelInforSubmenu.Visible = false;
            panelFacturSubmenu.Visible = false;
            panelLiquidarSubmenu.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnFactur_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFacturSubmenu);
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            showSubMenu(panelLiquidarSubmenu);
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInforSubmenu);
        }

        // FIN

        // Eventos de los botones del menú
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnRestaurar.Visible = true;
                btnMaximizar.Visible = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnRestaurar.Visible = false;
                btnMaximizar.Visible = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // FIN
        // Eventos de los botones del menú secundario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            //..
            //Your Code
            //..
            hideSubMenu();
        }
        // FIN

        // Método para iniciar sesión
        public void IniciarSesion(string usuario, int id)
        {
            this.Usuario = usuario;
            this.idUsuario = id;
            MessageBox.Show($"Bienvenido {usuario} (ID: {id})", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Enabled = true;
            toolStripStatusLabel2.Text = $"EN LÍNEA → ({usuario})";
            // habilitar menú, cargar permisos, etc.
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Form Ps = new FrmPass();
            Ps.Show(this);
            this.Enabled = false;
        }
        // FIN
        // Abrir formularios desde el menú
        private int WState()
        {
            int res = 0;
            if (this.WindowState == FormWindowState.Maximized)
                res = 1;
            return res;
        }
        #region ChildForm
        private Form activeForm = null;

        private void openChildForm(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            //childform.FormBorderStyle = FormBorderStyle.None;
            //childform.Dock = DockStyle.Left;
            panelChildForm.Controls.Add(childform);
            panelChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        #endregion
        private void button15_Click(object? sender, EventArgs e)
        {
            if (this.Usertipo != 1 && this.Usertipo != 2)
            {
                tool.Mensaje("", "ACCESO DENEGADO!!!", 0);
                return;
            }

            FrmHistoria formulario = panelChildForm.Controls.OfType<FrmHistoria>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new FrmHistoria(WState(), this.idUsuario, this.Usertipo);
                formulario.TopLevel = false;
                panelChildForm.Controls.Add(formulario);
                panelChildForm.Tag = formulario;
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.Show();
                formulario.BringToFront();

                // Suscribirse una sola vez
                formulario.ShowFrmImprimirRequested += FrmFactur_ShowFrmImprimirRequested;
            }
            else
            {
                formulario.BringToFront();
            }

            hideSubMenu();
        }
        private void FrmFactur_ShowFrmImprimirRequested(object sender, ParametrosEventArgs e)
        {
            FrmImprimir formulario = panelChildForm.Controls.OfType<FrmImprimir>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new FrmImprimir(WState(), e.nroPla, e.nroInt, e.Periodo, e.opcion);
                formulario.TopLevel = false;
                panelChildForm.Controls.Add(formulario);
                panelChildForm.Tag = formulario;
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.Usertipo != 1 && this.Usertipo != 2)
            {
                tool.Mensaje("", "ACCESO DENEGADO!!!", 0);
                return;
            }

            FrmPacientes formulario = panelChildForm.Controls.OfType<FrmPacientes>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new FrmPacientes(WState(), this.idUsuario, this.Usertipo);
                formulario.TopLevel = false;
                panelChildForm.Controls.Add(formulario);
                panelChildForm.Tag = formulario;
                formulario.StartPosition = FormStartPosition.CenterScreen;
                formulario.Show();
                formulario.BringToFront();

                // Suscribirse una sola vez
                formulario.ShowFrmImprimirRequested += FrmFactur_ShowFrmImprimirRequested;
            }
            else
            {
                formulario.BringToFront();
            }

            hideSubMenu();
        }

        // FIN
    }
}
