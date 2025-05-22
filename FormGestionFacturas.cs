using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ReportesFacturasApp
{
    public partial class FormGestionFacturas : Form
    {

        public FormGestionFacturas()
        {
            InitializeComponent();
        }

      

        private void FormGestionFacturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bD_FacturacionPruebasDataSet.Facturas' Puede moverla o quitarla según sea necesario.
            this.facturasTableAdapter.Fill(this.bD_FacturacionPruebasDataSet.Facturas);
            CargarFacturas();
        }
        private void CargarFacturas()
        {
            using (SqlConnection cn = conexion.Conectar())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Facturas", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvFacturas.AutoGenerateColumns = true;  // <--- Esto es importante
                dgvFacturas.DataSource = dt;
            }
        }

        private void btnVerReporte_Click(object sender, EventArgs e)
        {
            FormReporte reporte = new FormReporte();
            reporte.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una factura para eliminar.");
                return;
            }

            // Usa índice 0 para la columna Id, o cambia a "Id" si existe
            int id;
            try
            {
                id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["Id"].Value);
            }
            catch
            {
                // Si no existe la columna "Id", usa índice 0
                id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value);
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar esta factura?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection cn = conexion.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Facturas WHERE Id=@id", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                MessageBox.Show("✅ Factura eliminada.");
                CargarFacturas();
            }

        }



        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una factura para editar.");
                return;
            }


            var idObj = dgvFacturas.SelectedRows[0].Cells["id"].Value;

            if (idObj == null)
            {
                MessageBox.Show("No se pudo obtener el ID de la factura seleccionada.");
                return;
            }

            int id;

            try
            {
                id = Convert.ToInt32(idObj);
            }
            catch
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            FormFactura formEditar = new FormFactura(id); // este constructor carga los datos
            formEditar.ShowDialog();

            CargarFacturas();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            FormFactura formFactura = new FormFactura(); // sin parámetros = nuevo
            formFactura.ShowDialog();
            CargarFacturas();
        }
    }
}
