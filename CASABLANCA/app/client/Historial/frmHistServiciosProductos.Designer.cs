namespace CASABLANCA.app.client.Historial
{
    partial class frmHistServiciosProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistServiciosProductos));
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPys = new System.Windows.Forms.GroupBox();
            this.lblAnchoCeldas = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvPys = new System.Windows.Forms.DataGridView();
            this.gbDatos.SuspendLayout();
            this.gbPys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPys)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.txtCodigo);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.txtId);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.Location = new System.Drawing.Point(20, 18);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gbDatos.Size = new System.Drawing.Size(783, 121);
            this.gbDatos.TabIndex = 7;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(112, 80);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(643, 26);
            this.txtNombre.TabIndex = 13;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(507, 37);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(248, 26);
            this.txtCodigo.TabIndex = 8;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(416, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(112, 37);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(265, 26);
            this.txtId.TabIndex = 2;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id:";
            // 
            // gbPys
            // 
            this.gbPys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbPys.Controls.Add(this.lblAnchoCeldas);
            this.gbPys.Controls.Add(this.lblRegistros);
            this.gbPys.Controls.Add(this.dgvPys);
            this.gbPys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbPys.Location = new System.Drawing.Point(20, 148);
            this.gbPys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPys.Name = "gbPys";
            this.gbPys.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPys.Size = new System.Drawing.Size(783, 712);
            this.gbPys.TabIndex = 9;
            this.gbPys.TabStop = false;
            this.gbPys.Text = "Productos y Servicios";
            // 
            // lblAnchoCeldas
            // 
            this.lblAnchoCeldas.AutoSize = true;
            this.lblAnchoCeldas.Location = new System.Drawing.Point(416, 688);
            this.lblAnchoCeldas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnchoCeldas.Name = "lblAnchoCeldas";
            this.lblAnchoCeldas.Size = new System.Drawing.Size(61, 20);
            this.lblAnchoCeldas.TabIndex = 7;
            this.lblAnchoCeldas.Text = "Ancho";
            this.lblAnchoCeldas.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(13, 677);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(170, 20);
            this.lblRegistros.TabIndex = 6;
            this.lblRegistros.Text = "Total de Registros:";
            // 
            // dgvPys
            // 
            this.dgvPys.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgvPys.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPys.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPys.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPys.Location = new System.Drawing.Point(17, 26);
            this.dgvPys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPys.MultiSelect = false;
            this.dgvPys.Name = "dgvPys";
            this.dgvPys.RowHeadersVisible = false;
            this.dgvPys.RowHeadersWidth = 51;
            this.dgvPys.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPys.Size = new System.Drawing.Size(748, 647);
            this.dgvPys.TabIndex = 4;
            // 
            // frmHistServiciosProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(75)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(819, 873);
            this.Controls.Add(this.gbPys);
            this.Controls.Add(this.gbDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmHistServiciosProductos";
            this.Text = "Historial Servicios y Productos";
            this.Load += new System.EventHandler(this.frmHistServiciosProductos_Load);
            this.Click += new System.EventHandler(this.frmHistServiciosProductos_Click);
            this.Move += new System.EventHandler(this.frmHistServiciosProductos_Move);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbPys.ResumeLayout(false);
            this.gbPys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPys;
        private System.Windows.Forms.DataGridView dgvPys;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblAnchoCeldas;
    }
}