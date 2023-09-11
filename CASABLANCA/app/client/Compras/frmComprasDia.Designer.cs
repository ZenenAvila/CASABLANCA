namespace CASABLANCA.app.client.Compras
{
    partial class frmComprasDia
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.pbxProductos = new System.Windows.Forms.PictureBox();
            this.btnProveedores = new System.Windows.Forms.PictureBox();
            this.txtNoRFacRem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNoParte = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxProveedores = new System.Windows.Forms.ComboBox();
            this.cbxProductos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gbProveedores = new System.Windows.Forms.GroupBox();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAnchoCeldas = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodServ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noParte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedores)).BeginInit();
            this.gbProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbDatos.Controls.Add(this.txtId);
            this.gbDatos.Controls.Add(this.label11);
            this.gbDatos.Controls.Add(this.pbxProductos);
            this.gbDatos.Controls.Add(this.btnProveedores);
            this.gbDatos.Controls.Add(this.txtNoRFacRem);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.cbxNoParte);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.cbxProveedores);
            this.gbDatos.Controls.Add(this.cbxProductos);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.btnAgregar);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.Location = new System.Drawing.Point(19, 18);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(5);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(5);
            this.gbDatos.Size = new System.Drawing.Size(783, 165);
            this.gbDatos.TabIndex = 7;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // pbxProductos
            // 
            this.pbxProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxProductos.Image = global::CASABLANCA.Properties.Resources.productosServiciosAzul;
            this.pbxProductos.Location = new System.Drawing.Point(273, 113);
            this.pbxProductos.Margin = new System.Windows.Forms.Padding(4);
            this.pbxProductos.Name = "pbxProductos";
            this.pbxProductos.Size = new System.Drawing.Size(45, 42);
            this.pbxProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxProductos.TabIndex = 27;
            this.pbxProductos.TabStop = false;
            this.pbxProductos.Click += new System.EventHandler(this.pbxProductos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnProveedores.Image = global::CASABLANCA.Properties.Resources.agregarAzul;
            this.btnProveedores.Location = new System.Drawing.Point(729, 41);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(45, 42);
            this.btnProveedores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnProveedores.TabIndex = 26;
            this.btnProveedores.TabStop = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // txtNoRFacRem
            // 
            this.txtNoRFacRem.AcceptsReturn = true;
            this.txtNoRFacRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNoRFacRem.Location = new System.Drawing.Point(89, 57);
            this.txtNoRFacRem.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoRFacRem.Name = "txtNoRFacRem";
            this.txtNoRFacRem.Size = new System.Drawing.Size(229, 23);
            this.txtNoRFacRem.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "No. Factura/Remision:";
            // 
            // cbxNoParte
            // 
            this.cbxNoParte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxNoParte.FormattingEnabled = true;
            this.cbxNoParte.Location = new System.Drawing.Point(348, 127);
            this.cbxNoParte.Margin = new System.Windows.Forms.Padding(4);
            this.cbxNoParte.Name = "cbxNoParte";
            this.cbxNoParte.Size = new System.Drawing.Size(311, 25);
            this.cbxNoParte.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "No. Parte:";
            // 
            // cbxProveedores
            // 
            this.cbxProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxProveedores.FormattingEnabled = true;
            this.cbxProveedores.Location = new System.Drawing.Point(348, 57);
            this.cbxProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.cbxProveedores.Name = "cbxProveedores";
            this.cbxProveedores.Size = new System.Drawing.Size(373, 25);
            this.cbxProveedores.TabIndex = 16;
            this.cbxProveedores.SelectedIndexChanged += new System.EventHandler(this.cbxProveedores_SelectedIndexChanged);
            // 
            // cbxProductos
            // 
            this.cbxProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbxProductos.FormattingEnabled = true;
            this.cbxProductos.Location = new System.Drawing.Point(17, 127);
            this.cbxProductos.Margin = new System.Windows.Forms.Padding(4);
            this.cbxProductos.Name = "cbxProductos";
            this.cbxProductos.Size = new System.Drawing.Size(251, 25);
            this.cbxProductos.TabIndex = 15;
            this.cbxProductos.SelectedIndexChanged += new System.EventHandler(this.cbxProductos_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Productos:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(670, 116);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 39);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proveedor:";
            // 
            // gbProveedores
            // 
            this.gbProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbProveedores.Controls.Add(this.btnGuardarCompra);
            this.gbProveedores.Controls.Add(this.txtTotal);
            this.gbProveedores.Controls.Add(this.txtIva);
            this.gbProveedores.Controls.Add(this.txtSubtotal);
            this.gbProveedores.Controls.Add(this.label7);
            this.gbProveedores.Controls.Add(this.label5);
            this.gbProveedores.Controls.Add(this.label3);
            this.gbProveedores.Controls.Add(this.lblAnchoCeldas);
            this.gbProveedores.Controls.Add(this.lblRegistros);
            this.gbProveedores.Controls.Add(this.dgvProductos);
            this.gbProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbProveedores.Location = new System.Drawing.Point(19, 192);
            this.gbProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.gbProveedores.Name = "gbProveedores";
            this.gbProveedores.Padding = new System.Windows.Forms.Padding(4);
            this.gbProveedores.Size = new System.Drawing.Size(783, 668);
            this.gbProveedores.TabIndex = 9;
            this.gbProveedores.TabStop = false;
            this.gbProveedores.Text = "Productos";
            // 
            // btnGuardarCompra
            // 
            this.btnGuardarCompra.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCompra.Location = new System.Drawing.Point(367, 558);
            this.btnGuardarCompra.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(125, 78);
            this.btnGuardarCompra.TabIndex = 28;
            this.btnGuardarCompra.Text = "Guardar Compra";
            this.btnGuardarCompra.UseVisualStyleBackColor = true;
            this.btnGuardarCompra.Click += new System.EventHandler(this.btnGuardarCompra_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(634, 612);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(129, 26);
            this.txtTotal.TabIndex = 14;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(634, 577);
            this.txtIva.Margin = new System.Windows.Forms.Padding(4);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(129, 26);
            this.txtIva.TabIndex = 13;
            this.txtIva.Text = "0.00";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(634, 543);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(129, 26);
            this.txtSubtotal.TabIndex = 12;
            this.txtSubtotal.Text = "0.00";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 616);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(534, 581);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "IVA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 547);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subtotal:";
            // 
            // lblAnchoCeldas
            // 
            this.lblAnchoCeldas.AutoSize = true;
            this.lblAnchoCeldas.Location = new System.Drawing.Point(23, 671);
            this.lblAnchoCeldas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnchoCeldas.Name = "lblAnchoCeldas";
            this.lblAnchoCeldas.Size = new System.Drawing.Size(61, 20);
            this.lblAnchoCeldas.TabIndex = 8;
            this.lblAnchoCeldas.Text = "Ancho";
            this.lblAnchoCeldas.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(23, 518);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(170, 20);
            this.lblRegistros.TabIndex = 7;
            this.lblRegistros.Text = "Total de Registros:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.prodServ,
            this.id,
            this.noParte,
            this.idProveedor,
            this.proveedor,
            this.marca,
            this.precioUni,
            this.iva,
            this.descuento,
            this.descuentoPor,
            this.subtotal,
            this.cantidad,
            this.total,
            this.eliminar});
            this.dgvProductos.Location = new System.Drawing.Point(17, 26);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.Size = new System.Drawing.Size(746, 476);
            this.dgvProductos.TabIndex = 4;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            this.dgvProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellValueChanged);
            // 
            // idProducto
            // 
            this.idProducto.HeaderText = "IdCatProdServ";
            this.idProducto.MinimumWidth = 6;
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            this.idProducto.Width = 136;
            // 
            // prodServ
            // 
            this.prodServ.HeaderText = "Producto";
            this.prodServ.MinimumWidth = 6;
            this.prodServ.Name = "prodServ";
            this.prodServ.ReadOnly = true;
            this.prodServ.Width = 94;
            // 
            // id
            // 
            this.id.HeaderText = "Id Producto";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 134;
            // 
            // noParte
            // 
            this.noParte.HeaderText = "No. Parte";
            this.noParte.MinimumWidth = 6;
            this.noParte.Name = "noParte";
            this.noParte.ReadOnly = true;
            this.noParte.Width = 97;
            // 
            // idProveedor
            // 
            this.idProveedor.HeaderText = "IdProveedor";
            this.idProveedor.MinimumWidth = 6;
            this.idProveedor.Name = "idProveedor";
            this.idProveedor.ReadOnly = true;
            this.idProveedor.Visible = false;
            this.idProveedor.Width = 138;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.MinimumWidth = 6;
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            this.proveedor.Width = 103;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 76;
            // 
            // precioUni
            // 
            this.precioUni.HeaderText = "Precio Uni.";
            this.precioUni.MinimumWidth = 6;
            this.precioUni.Name = "precioUni";
            this.precioUni.Width = 106;
            // 
            // iva
            // 
            this.iva.HeaderText = "IVA";
            this.iva.MinimumWidth = 6;
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.ToolTipText = "El IVA es del  16%";
            this.iva.Width = 58;
            // 
            // descuento
            // 
            this.descuento.HeaderText = "Descuento";
            this.descuento.MinimumWidth = 6;
            this.descuento.Name = "descuento";
            this.descuento.ToolTipText = "Valor permitido de 1 a 100";
            this.descuento.Width = 105;
            // 
            // descuentoPor
            // 
            this.descuentoPor.HeaderText = "Descuento %";
            this.descuentoPor.MinimumWidth = 6;
            this.descuentoPor.Name = "descuentoPor";
            this.descuentoPor.ReadOnly = true;
            this.descuentoPor.Width = 121;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Width = 89;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 93;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 69;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.MinimumWidth = 6;
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Width = 64;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtId.Location = new System.Drawing.Point(17, 57);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(54, 23);
            this.txtId.TabIndex = 65;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(13, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 20);
            this.label11.TabIndex = 64;
            this.label11.Text = "Id:";
            // 
            // frmComprasDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(75)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(819, 873);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbProveedores);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmComprasDia";
            this.Text = "Compras Día";
            this.Load += new System.EventHandler(this.frmComprasDia_Load);
            this.Enter += new System.EventHandler(this.frmComprasDia_Enter);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProveedores)).EndInit();
            this.gbProveedores.ResumeLayout(false);
            this.gbProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbProveedores;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.ComboBox cbxProductos;
        public System.Windows.Forms.ComboBox cbxProveedores;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbxNoParte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbxProductos;
        private System.Windows.Forms.PictureBox btnProveedores;
        private System.Windows.Forms.Label lblAnchoCeldas;
        private System.Windows.Forms.TextBox txtNoRFacRem;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.Button btnGuardarCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodServ;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn noParte;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUni;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewImageColumn eliminar;
        public System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label11;
    }
}