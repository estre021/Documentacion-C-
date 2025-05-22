using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReportesFacturasApp
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {

            this.reportViewer6.RefreshReport();
            reportViewer6.LocalReport.DataSources.Clear();


            reportViewer6.LocalReport.ReportPath = Application.StartupPath + @"\ReporteFactura.rdlc";



            SqlConnection con = new SqlConnection("Server=LENOVO2\\MSSQLSERVER01;Database=BD_FacturacionPruebas;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Facturas", con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Facturas");

        
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables["Facturas"]);

        
            reportViewer6.LocalReport.DataSources.Add(rds);
            reportViewer6.RefreshReport();
        }
    }
}
