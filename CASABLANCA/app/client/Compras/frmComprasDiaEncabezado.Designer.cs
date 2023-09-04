namespace CASABLANCA.app.client.Compras
{
    partial class frmComprasDiaEncabezado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbPys = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblAnchoCeldas = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dgvEncabezados = new System.Windows.Forms.DataGridView();
            this.gbPys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncabezados)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPys
            // 
            this.gbPys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(190)))), ((int)(((byte)(30)))));
            this.gbPys.Controls.Add(this.btnNuevo);
            this.gbPys.Controls.Add(this.lblAnchoCeldas);
            this.gbPys.Controls.Add(this.lblRegistros);
            this.gbPys.Controls.Add(this.dgvEncabezados);
            this.gbPys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbPys.Location = new System.Drawing.Point(20, 18);
            this.gbPys.Margin = new System.Windows.Forms.Padding(4);
            this.gbPys.Name = "gbPys";
            this.gbPys.Padding = new System.Windows.Forms.Padding(4);
            this.gbPys.Size = new System.Drawing.Size(783, 379);
            this.gbPys.TabIndex = 10;
            this.gbPys.TabStop = false;
            this.gbPys.Text = "Compras Día";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(660, 16);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(104, 39);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblAnchoCeldas
            // 
            this.lblAnchoCeldas.AutoSize = true;
            this.lblAnchoCeldas.Location = new System.Drawing.Point(338, 351);
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
            this.lblRegistros.Location = new System.Drawing.Point(13, 350);
            this.lblRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(170, 20);
            this.lblRegistros.TabIndex = 6;
            this.lblRegistros.Text = "Total de Registros:";
            // 
            // dgvEncabezados
            // 
            this.dgvEncabezados.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEncabezados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEncabezados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEncabezados.ColumnHeadersHeight = 29;
            this.dgvEncabezados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEncabezados.Location = new System.Drawing.Point(17, 63);
            this.dgvEncabezados.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEncabezados.MultiSelect = false;
            this.dgvEncabezados.Name = "dgvEncabezados";
            this.dgvEncabezados.RowHeadersVisible = false;
            this.dgvEncabezados.RowHeadersWidth = 51;
            this.dgvEncabezados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEncabezados.Size = new System.Drawing.Size(747, 281);
            this.dgvEncabezados.TabIndex = 4;
            this.dgvEncabezados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncabezados_CellContentClick);
            this.dgvEncabezados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncabezados_CellDoubleClick);
            // 
            // frmComprasDiaEncabezado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(75)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(819, 412);
            this.Controls.Add(this.gbPys);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmComprasDiaEncabezado";
            this.Text = "Compras Día";
            this.Load += new System.EventHandler(this.frmComprasDiaEncabezado_Load);
            this.Enter += new System.EventHandler(this.frmComprasDiaEncabezado_Enter);
            this.gbPys.ResumeLayout(false);
            this.gbPys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncabezados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPys;
        private System.Windows.Forms.Label lblAnchoCeldas;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dgvEncabezados;
        private System.Windows.Forms.Button btnNuevo;
    }
}