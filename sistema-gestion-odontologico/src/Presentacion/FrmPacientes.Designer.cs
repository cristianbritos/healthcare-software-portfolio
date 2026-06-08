namespace CapaPresentacion
{
    partial class FrmPacientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button btnPrinter;
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            label4 = new Label();
            txtOSocial = new TextBox();
            txtMed = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtPac = new TextBox();
            txtNro = new TextBox();
            txtBuscar = new TextBox();
            label5 = new Label();
            btnBuscar = new Button();
            btnPrinter = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrinter
            // 
            btnPrinter.Location = new Point(659, 390);
            btnPrinter.Name = "btnPrinter";
            btnPrinter.Size = new Size(75, 23);
            btnPrinter.TabIndex = 0;
            btnPrinter.Text = "button1";
            btnPrinter.UseVisualStyleBackColor = true;
            btnPrinter.Click += btnPrinter_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(85, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(470, 194);
            dataGridView1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(85, 219);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(470, 194);
            dataGridView2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtOSocial);
            panel1.Controls.Add(txtMed);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPac);
            panel1.Controls.Add(txtNro);
            panel1.Location = new Point(567, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 252);
            panel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(6, 178);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 7;
            label3.Text = "O. Social:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(6, 123);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Medico:";
            // 
            // txtOSocial
            // 
            txtOSocial.Location = new Point(51, 195);
            txtOSocial.Name = "txtOSocial";
            txtOSocial.Size = new Size(152, 23);
            txtOSocial.TabIndex = 5;
            // 
            // txtMed
            // 
            txtMed.Location = new Point(51, 140);
            txtMed.Name = "txtMed";
            txtMed.Size = new Size(152, 23);
            txtMed.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(6, 66);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Nro. Pac.:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(6, 11);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 2;
            label1.Text = "Nro. Int.:";
            // 
            // txtPac
            // 
            txtPac.Location = new Point(51, 83);
            txtPac.Name = "txtPac";
            txtPac.Size = new Size(152, 23);
            txtPac.TabIndex = 1;
            // 
            // txtNro
            // 
            txtNro.Location = new Point(51, 28);
            txtNro.Name = "txtNro";
            txtNro.Size = new Size(152, 23);
            txtNro.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(620, 42);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(575, 20);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 8;
            label5.Text = "Buscar:";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(628, 76);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // FrmPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBuscar);
            Controls.Add(label5);
            Controls.Add(txtBuscar);
            Controls.Add(panel1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(btnPrinter);
            Name = "FrmPacientes";
            Text = "FrmPacientes";
            Load += FrmPacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrinter;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Panel panel1;
        private Label label1;
        private TextBox txtPac;
        private TextBox txtNro;
        private Label label3;
        private Label label4;
        private TextBox txtOSocial;
        private TextBox txtMed;
        private Label label2;
        private TextBox txtBuscar;
        private Label label5;
        private Button btnBuscar;
    }
}