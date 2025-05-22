using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReportesFacturasApp
{
    public partial class FormFactura : Form
    {
        private int? facturaId = null;

        public FormFactura()
        {
            InitializeComponent();
        }

        public FormFactura(int id)
        {
            InitializeComponent();
            facturaId = id;
            CargarFacturaParaEditar(id);
        }
        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            int cantidad = (int)numCantidad.Value;
            decimal precio = Convert.ToDecimal(txtPrecioUnitario.Text);
            decimal itebis = Convert.ToDecimal(txtITEBIS.Text);
            decimal descuento = Convert.ToDecimal(txtDescuento.Text);

            decimal total = (cantidad * precio) + itebis - descuento;
         

            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd;

                if (facturaId.HasValue) 
                {
                    cmd = new SqlCommand("UPDATE Facturas SET Descripcion=@desc, Categoria=@cat, Cantidad=@cant, PrecioUnitario=@precio, ITEBIS=@itebis, Descuento=@descue WHERE Id=@id", cn);

                    cmd.Parameters.AddWithValue("@id", facturaId.Value);
                }
                else 
                {
                    cmd = new SqlCommand("INSERT INTO Facturas (Descripcion, Categoria, Cantidad, PrecioUnitario, ITEBIS, Descuento) VALUES (@desc, @cat, @cant, @precio, @itebis, @descue)", cn);

                }

                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@itebis", itebis);
                cmd.Parameters.AddWithValue("@descue", descuento);
                


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show(facturaId.HasValue ? "✅ Factura actualizada." : "✅ Factura agregada.");
                LimpiarCampos();
            }
        }


        private void btnIrAVisualizarFacturas_Click(object sender, EventArgs e)
        {
            FormGestionFacturas formGestion = new FormGestionFacturas();
            formGestion.Show();
        }
        private void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtCategoria.Clear();
            numCantidad.Value = 1;
            txtPrecioUnitario.Clear();
            txtITEBIS.Clear();
            txtDescuento.Clear();
        }
        private void CargarFacturaEditar()
        {
            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Facturas WHERE Id = @id", cn);
                cmd.Parameters.AddWithValue("@id", facturaId);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtDescripcion.Text = reader["Descripcion"].ToString();
                    txtCategoria.Text = reader["Categoria"].ToString();
                    numCantidad.Value = Convert.ToDecimal(reader["Cantidad"]);
                    txtPrecioUnitario.Text = reader["PrecioUnitario"].ToString();
                    txtITEBIS.Text = reader["ITEBIS"].ToString();
                    txtDescuento.Text = reader["Descuento"].ToString();
                }
                cn.Close();
            }
        }
        private void CargarFacturaParaEditar(int id)
        {
            using (SqlConnection cn = conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Facturas WHERE Id=@id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDescripcion.Text = dr["Descripcion"].ToString();
                    txtCategoria.Text = dr["Categoria"].ToString();
                    numCantidad.Value = Convert.ToInt32(dr["Cantidad"]);
                    txtPrecioUnitario.Text = dr["PrecioUnitario"].ToString();
                    txtITEBIS.Text = dr["ITEBIS"].ToString();
                    txtDescuento.Text = dr["Descuento"].ToString();
                }
                cn.Close();
            }
        }
        private void FormFactura_Load(object sender, EventArgs e)
        {

        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtITEBIS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
