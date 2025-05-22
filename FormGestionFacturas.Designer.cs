namespace ReportesFacturasApp
{
    partial class FormGestionFacturas
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
            this.components = new System.ComponentModel.Container();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bD_FacturacionPruebasDataSet = new ReportesFacturasApp.BD_FacturacionPruebasDataSet();
            this.victobssqlDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._victobs_sqlDataSet = new ReportesFacturasApp._victobs_sqlDataSet();
            this.btnVerReporte = new System.Windows.Forms.Button();
            this.btnGuardarEdicion = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.facturasTableAdapter = new ReportesFacturasApp.BD_FacturacionPruebasDataSetTableAdapters.FacturasTableAdapter();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_FacturacionPruebasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.victobssqlDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._victobs_sqlDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "Facturas";
            this.facturasBindingSource.DataSource = this.bD_FacturacionPruebasDataSet;
            // 
            // bD_FacturacionPruebasDataSet
            // 
            this.bD_FacturacionPruebasDataSet.DataSetName = "BD_FacturacionPruebasDataSet";
            this.bD_FacturacionPruebasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // victobssqlDataSetBindingSource
            // 
            this.victobssqlDataSetBindingSource.DataSource = this._victobs_sqlDataSet;
            this.victobssqlDataSetBindingSource.Position = 0;
            // 
            // _victobs_sqlDataSet
            // 
            this._victobs_sqlDataSet.DataSetName = "_victobs_sqlDataSet";
            this._victobs_sqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnVerReporte
            // 
            this.btnVerReporte.BackColor = System.Drawing.SystemColors.Info;
            this.btnVerReporte.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerReporte.Location = new System.Drawing.Point(609, 162);
            this.btnVerReporte.Name = "btnVerReporte";
            this.btnVerReporte.Size = new System.Drawing.Size(179, 44);
            this.btnVerReporte.TabIndex = 2;
            this.btnVerReporte.Text = "Ver Reporte";
            this.btnVerReporte.UseVisualStyleBackColor = false;
            this.btnVerReporte.Click += new System.EventHandler(this.btnVerReporte_Click);
            // 
            // btnGuardarEdicion
            // 
            this.btnGuardarEdicion.BackColor = System.Drawing.SystemColors.Info;
            this.btnGuardarEdicion.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarEdicion.Location = new System.Drawing.Point(609, 62);
            this.btnGuardarEdicion.Name = "btnGuardarEdicion";
            this.btnGuardarEdicion.Size = new System.Drawing.Size(179, 44);
            this.btnGuardarEdicion.TabIndex = 4;
            this.btnGuardarEdicion.Text = "Editar";
            this.btnGuardarEdicion.UseVisualStyleBackColor = false;
            this.btnGuardarEdicion.Click += new System.EventHandler(this.btnGuardarEdicion_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Info;
            this.btnEliminar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(609, 112);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(179, 44);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.SystemColors.Info;
            this.btnagregar.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.Location = new System.Drawing.Point(609, 12);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(179, 44);
            this.btnagregar.TabIndex = 6;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // facturasTableAdapter
            // 
            this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(12, 12);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.Size = new System.Drawing.Size(591, 356);
            this.dgvFacturas.TabIndex = 7;
            // 
            // FormGestionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardarEdicion);
            this.Controls.Add(this.btnVerReporte);
            this.Name = "FormGestionFacturas";
            this.Text = "FormGestionFacturas";
            this.Load += new System.EventHandler(this.FormGestionFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bD_FacturacionPruebasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.victobssqlDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._victobs_sqlDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource victobssqlDataSetBindingSource;
        private _victobs_sqlDataSet _victobs_sqlDataSet;
        private System.Windows.Forms.Button btnVerReporte;
        private System.Windows.Forms.Button btnGuardarEdicion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnagregar;
        private BD_FacturacionPruebasDataSet bD_FacturacionPruebasDataSet;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private BD_FacturacionPruebasDataSetTableAdapters.FacturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.DataGridView dgvFacturas;
    }
}