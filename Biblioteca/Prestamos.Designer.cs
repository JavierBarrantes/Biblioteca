
namespace Biblioteca
{
    partial class Prestamos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClavePrestamo = new System.Windows.Forms.TextBox();
            this.txtEjemplar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaveUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActulizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvPrestamo = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPrestamo = new System.Windows.Forms.DateTimePicker();
            this.dtpDevolucion = new System.Windows.Forms.DateTimePicker();
            this.dgvEjemplarDatos = new System.Windows.Forms.DataGridView();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtFiltrarUsuario = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFiltarEjemplar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjemplarDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave Prestamo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtClavePrestamo
            // 
            this.txtClavePrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClavePrestamo.Location = new System.Drawing.Point(26, 71);
            this.txtClavePrestamo.Name = "txtClavePrestamo";
            this.txtClavePrestamo.Size = new System.Drawing.Size(149, 31);
            this.txtClavePrestamo.TabIndex = 1;
            this.txtClavePrestamo.Text = "XR2";
            // 
            // txtEjemplar
            // 
            this.txtEjemplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEjemplar.Location = new System.Drawing.Point(214, 71);
            this.txtEjemplar.Name = "txtEjemplar";
            this.txtEjemplar.Size = new System.Drawing.Size(152, 31);
            this.txtEjemplar.TabIndex = 3;
            this.txtEjemplar.Text = "LB001-001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Clave Ejemplar";
            // 
            // txtClaveUsuario
            // 
            this.txtClaveUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveUsuario.Location = new System.Drawing.Point(395, 71);
            this.txtClaveUsuario.Name = "txtClaveUsuario";
            this.txtClaveUsuario.Size = new System.Drawing.Size(127, 31);
            this.txtClaveUsuario.TabIndex = 5;
            this.txtClaveUsuario.Text = "P001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clave usario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Prestamo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(977, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha Devolucion";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(179, 129);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(122, 49);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActulizar
            // 
            this.btnActulizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActulizar.Location = new System.Drawing.Point(338, 129);
            this.btnActulizar.Name = "btnActulizar";
            this.btnActulizar.Size = new System.Drawing.Size(122, 49);
            this.btnActulizar.TabIndex = 12;
            this.btnActulizar.Text = "Actualizar";
            this.btnActulizar.UseVisualStyleBackColor = true;
            this.btnActulizar.Click += new System.EventHandler(this.btnActulizar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(26, 129);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(122, 49);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvPrestamo
            // 
            this.dgvPrestamo.AllowUserToAddRows = false;
            this.dgvPrestamo.AllowUserToDeleteRows = false;
            this.dgvPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamo.Location = new System.Drawing.Point(544, 169);
            this.dgvPrestamo.Name = "dgvPrestamo";
            this.dgvPrestamo.ReadOnly = true;
            this.dgvPrestamo.Size = new System.Drawing.Size(800, 516);
            this.dgvPrestamo.TabIndex = 13;
            this.dgvPrestamo.DoubleClick += new System.EventHandler(this.dgvPrestamo_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Detalles del ejemplar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 572);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Detalles del Usuario";
            // 
            // dtpPrestamo
            // 
            this.dtpPrestamo.CustomFormat = "yyy/dd/M";
            this.dtpPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPrestamo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPrestamo.Location = new System.Drawing.Point(557, 71);
            this.dtpPrestamo.Name = "dtpPrestamo";
            this.dtpPrestamo.Size = new System.Drawing.Size(375, 31);
            this.dtpPrestamo.TabIndex = 18;
            this.dtpPrestamo.UseWaitCursor = true;
            this.dtpPrestamo.ValueChanged += new System.EventHandler(this.dtpPrestamo_ValueChanged);
            // 
            // dtpDevolucion
            // 
            this.dtpDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDevolucion.Location = new System.Drawing.Point(962, 71);
            this.dtpDevolucion.Name = "dtpDevolucion";
            this.dtpDevolucion.Size = new System.Drawing.Size(370, 31);
            this.dtpDevolucion.TabIndex = 19;
            // 
            // dgvEjemplarDatos
            // 
            this.dgvEjemplarDatos.AllowUserToAddRows = false;
            this.dgvEjemplarDatos.AllowUserToDeleteRows = false;
            this.dgvEjemplarDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEjemplarDatos.Location = new System.Drawing.Point(28, 327);
            this.dgvEjemplarDatos.Name = "dgvEjemplarDatos";
            this.dgvEjemplarDatos.ReadOnly = true;
            this.dgvEjemplarDatos.Size = new System.Drawing.Size(473, 242);
            this.dgvEjemplarDatos.TabIndex = 20;
            this.dgvEjemplarDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Location = new System.Drawing.Point(30, 600);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.Size = new System.Drawing.Size(471, 243);
            this.dgvUsuario.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(539, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Detalles de Prestamos";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 20);
            this.textBox1.TabIndex = 23;
            // 
            // txtFiltrarUsuario
            // 
            this.txtFiltrarUsuario.AutoSize = true;
            this.txtFiltrarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrarUsuario.Location = new System.Drawing.Point(23, 193);
            this.txtFiltrarUsuario.Name = "txtFiltrarUsuario";
            this.txtFiltrarUsuario.Size = new System.Drawing.Size(259, 25);
            this.txtFiltrarUsuario.TabIndex = 24;
            this.txtFiltrarUsuario.Text = "Filtrar por nombre usuario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Filtrar por nombre de libro";
            // 
            // txtFiltarEjemplar
            // 
            this.txtFiltarEjemplar.Location = new System.Drawing.Point(28, 276);
            this.txtFiltarEjemplar.Name = "txtFiltarEjemplar";
            this.txtFiltarEjemplar.Size = new System.Drawing.Size(432, 20);
            this.txtFiltarEjemplar.TabIndex = 25;
            this.txtFiltarEjemplar.TextChanged += new System.EventHandler(this.txtFiltarEjemplar_TextChanged);
            // 
            // Prestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 864);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFiltarEjemplar);
            this.Controls.Add(this.txtFiltrarUsuario);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.dgvEjemplarDatos);
            this.Controls.Add(this.dtpDevolucion);
            this.Controls.Add(this.dtpPrestamo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvPrestamo);
            this.Controls.Add(this.btnActulizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClaveUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEjemplar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClavePrestamo);
            this.Controls.Add(this.label1);
            this.Name = "Prestamos";
            this.Text = "Prestamos";
            this.Load += new System.EventHandler(this.Prestamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEjemplarDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClavePrestamo;
        private System.Windows.Forms.TextBox txtEjemplar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClaveUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActulizar;
        private System.Windows.Forms.DataGridView dgvPrestamo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpPrestamo;
        private System.Windows.Forms.DateTimePicker dtpDevolucion;
        private System.Windows.Forms.DataGridView dgvEjemplarDatos;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtFiltrarUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFiltarEjemplar;
    }
}