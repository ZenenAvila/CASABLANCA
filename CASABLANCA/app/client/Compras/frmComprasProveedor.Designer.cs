namespace CASABLANCA.app.client.Compras
{
    partial class frmComprasProveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbProveedores = new System.Windows.Forms.GroupBox();
            this.lblAnchoCeldas = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvElementos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoParte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.cbxProductos = new System.Windows.Forms.ComboBox();
            this.cbxProveedores = new System.Windows.Forms.ComboBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoParte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pcbBorrar = new System.Windows.Forms.PictureBox();
            this.pbxProductos = new System.Windows.Forms.PictureBox();
            this.btnProveedores = new System.Windows.Forms.PictureBox();
            this.gbProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementos)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBorrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProveedores
            // 
            this.gbProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbProveedores.Controls.Add(this.lblAnchoCeldas);
            this.gbProveedores.Controls.Add(this.lblRegistros);
            this.gbProveedores.Controls.Add(this.dgvElementos);
            this.gbProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbProveedores.Location = new System.Drawing.Point(14, 283);
            this.gbProveedores.Name = "gbProveedores";
            this.gbProveedores.Size = new System.Drawing.Size(902, 397);
            this.gbProveedores.TabIndex = 9;
            this.gbProveedores.TabStop = false;
            this.gbProveedores.Text = "Proveedores";
            // 
            // lblAnchoCeldas
            // 
            this.lblAnchoCeldas.AutoSize = true;
            this.lblAnchoCeldas.Location = new System.Drawing.Point(23, 282);
            this.lblAnchoCeldas.Name = "lblAnchoCeldas";
            this.lblAnchoCeldas.Size = new System.Drawing.Size(51, 16);
            this.lblAnchoCeldas.TabIndex = 8;
            this.lblAnchoCeldas.Text = "Ancho";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(80, 282);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(141, 16);
            this.lblRegistros.TabIndex = 7;
            this.lblRegistros.Text = "Total de Registros:";
            // 
            // dgvElementos
            // 
            this.dgvElementos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvElementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElementos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NoParte,
            this.Marca,
            this.pUnitario,
            this.Cantidad});
            this.dgvElementos.Location = new System.Drawing.Point(13, 21);
            this.dgvElementos.MultiSelect = false;
            this.dgvElementos.Name = "dgvElementos";
            this.dgvElementos.RowHeadersVisible = false;
            this.dgvElementos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvElementos.Size = new System.Drawing.Size(875, 258);
            this.dgvElementos.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.Frozen = true;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // NoParte
            // 
            this.NoParte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NoParte.Frozen = true;
            this.NoParte.HeaderText = "No. Parte";
            this.NoParte.Name = "NoParte";
            this.NoParte.ReadOnly = true;
            // 
            // Marca
            // 
            this.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Marca.Frozen = true;
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // pUnitario
            // 
            this.pUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pUnitario.Frozen = true;
            this.pUnitario.HeaderText = "Precio Unitario";
            this.pUnitario.Name = "pUnitario";
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // gbDatos
            // 
            this.gbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbDatos.Controls.Add(this.pcbBorrar);
            this.gbDatos.Controls.Add(this.pbxProductos);
            this.gbDatos.Controls.Add(this.dgvProductos);
            this.gbDatos.Controls.Add(this.btnProveedores);
            this.gbDatos.Controls.Add(this.cbxProductos);
            this.gbDatos.Controls.Add(this.cbxProveedores);
            this.gbDatos.Controls.Add(this.txtMarca);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.txtNoParte);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.Location = new System.Drawing.Point(14, 15);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(4);
            this.gbDatos.Size = new System.Drawing.Size(902, 261);
            this.gbDatos.TabIndex = 7;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(13, 122);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.Size = new System.Drawing.Size(875, 132);
            this.dgvProductos.TabIndex = 9;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // cbxProductos
            // 
            this.cbxProductos.FormattingEnabled = true;
            this.cbxProductos.Location = new System.Drawing.Point(95, 56);
            this.cbxProductos.Name = "cbxProductos";
            this.cbxProductos.Size = new System.Drawing.Size(255, 24);
            this.cbxProductos.TabIndex = 14;
            this.cbxProductos.SelectedIndexChanged += new System.EventHandler(this.cbxProductos_SelectedIndexChanged);
            // 
            // cbxProveedores
            // 
            this.cbxProveedores.BackColor = System.Drawing.Color.White;
            this.cbxProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProveedores.FormattingEnabled = true;
            this.cbxProveedores.Location = new System.Drawing.Point(92, 11);
            this.cbxProveedores.Name = "cbxProveedores";
            this.cbxProveedores.Size = new System.Drawing.Size(521, 32);
            this.cbxProveedores.TabIndex = 14;
            this.cbxProveedores.SelectedIndexChanged += new System.EventHandler(this.cbxProveedores_SelectedIndexChanged);
            this.cbxProveedores.BindingContextChanged += new System.EventHandler(this.cbxProveedores_BindingContextChanged);
            // 
            // txtMarca
            // 
            this.txtMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMarca.Location = new System.Drawing.Point(432, 94);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(181, 22);
            this.txtMarca.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Farsi Simple Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(371, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Marca:";
            // 
            // txtNoParte
            // 
            this.txtNoParte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoParte.Location = new System.Drawing.Point(95, 94);
            this.txtNoParte.Name = "txtNoParte";
            this.txtNoParte.Size = new System.Drawing.Size(255, 22);
            this.txtNoParte.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Farsi Simple Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(10, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "No. Parte:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Farsi Simple Bold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(10, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Productos:";
            // 
            // pcbBorrar
            // 
            this.pcbBorrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbBorrar.Image = global::CASABLANCA.Properties.Resources.Papelera_roja;
            this.pcbBorrar.Location = new System.Drawing.Point(535, 53);
            this.pcbBorrar.Name = "pcbBorrar";
            this.pcbBorrar.Size = new System.Drawing.Size(35, 35);
            this.pcbBorrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbBorrar.TabIndex = 26;
            this.pcbBorrar.TabStop = false;
            this.pcbBorrar.Click += new System.EventHandler(this.pcbBorrar_Click);
            // 
            // pbxProductos
            // 
            this.pbxProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxProductos.Image = global::CASABLANCA.Properties.Resources.productosServiciosAzul;
            this.pbxProductos.Location = new System.Drawing.Point(619, 81);
            this.pbxProductos.Name = "pbxProductos";
            this.pbxProductos.Size = new System.Drawing.Size(35, 35);
            this.pbxProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProductos.TabIndex = 25;
            this.pbxProductos.TabStop = false;
            this.pbxProductos.Click += new System.EventHandler(this.pbxProductos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnProveedores.Image = global::CASABLANCA.Properties.Resources.proveedoresAzul;
            this.btnProveedores.Location = new System.Drawing.Point(619, 11);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(35, 35);
            this.btnProveedores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnProveedores.TabIndex = 24;
            this.btnProveedores.TabStop = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // frmComprasProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(75)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(929, 691);
            this.Controls.Add(this.gbProveedores);
            this.Controls.Add(this.gbDatos);
            this.Name = "frmComprasProveedor";
            this.Text = "frmComprasProveedor";
            this.Load += new System.EventHandler(this.frmComprasProveedor_Load);
            this.gbProveedores.ResumeLayout(false);
            this.gbProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBorrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbProveedores;
        private System.Windows.Forms.Label lblAnchoCeldas;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvElementos;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.PictureBox btnProveedores;
        public System.Windows.Forms.ComboBox cbxProveedores;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoParte;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbxProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbxProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoParte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn pUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.PictureBox pcbBorrar;
    }
}