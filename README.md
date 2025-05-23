#  Documentación Paso a Paso: Sistema de Facturación con Reporte en C# Windows Forms
### 🔹 Paso 1: Configuración y Estructura del Proyecto
---
## 📁 Nombre del proyecto:
- ReportesFacturasApp

## 📁 Estructura de Carpetas:
-conexion.cs: clase para la conexión a la base de datos.

-Factura.cs: clase de modelo (entidad).

-FormFactura.cs: formulario para registrar/gestionar facturas.

-FormGestionFacturas.cs: muestra el listado y permite editar/eliminar/agregar.

-FormReporte.cs: muestra el reporte en ReportViewer.

-BD_FacturacionPruebasDataSet.xsd: dataset usado para el ReportViewer.

-victobs.sqlDataSet.xsd: otro dataset.

-ReporteFactura.rdlc: archivo del reporte.

-App.config: configuración de conexión.

-Program.cs: clase principal del sistema.

---
![Image](https://github.com/user-attachments/assets/f8327e53-ea16-4dba-a295-07d4d3bfb8db)

### Paso 2: Crear y Conectar la Base de Datos

---

Script de Base de Datos:
---
```sql
CREATE DATABASE BD_FacturacionPruebas;
GO

USE BD_FacturacionPruebas;
GO

CREATE TABLE Facturas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(255),
    Categoria NVARCHAR(100),
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    ITEBIS DECIMAL(10,2),
    Descuento DECIMAL(10,2),
    TotalGeneral AS ((Cantidad * PrecioUnitario + ITEBIS) - Descuento) PERSISTED
);
```
---

### Paso 3: Clase de Conexión conexion.cs
-Aqui pones tu linea de conexion con la base de datos que creamos.
---

```csharp
using System.Data.SqlClient;

namespace ReportesFacturasApp
{
    public class conexion
    {
        private SqlConnection con;

        public SqlConnection Conectar()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=BD_FacturacionPruebas;Integrated Security=True");
            return con;
        }
    }
}
```
---

### Paso 4: Modelo de Factura Factura.cs
---

```csharp
namespace ReportesFacturasApp
{
    public class Factura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ITEBIS { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalGeneral { get; set; }
    }
}
```

### Paso 5: Formulario para Registrar Facturas FormFactura.cs
(Se asume que contiene TextBox para cada campo y un botón btnGuardar)
---

```csharp
private void btnGuardar_Click(object sender, EventArgs e)
{
    using (SqlConnection con = new conexion().Conectar())
    {
        string query = "INSERT INTO Facturas (Descripcion, Categoria, Cantidad, PrecioUnitario, ITEBIS, Descuento) " +
                       "VALUES (@Descripcion, @Categoria, @Cantidad, @PrecioUnitario, @ITEBIS, @Descuento)";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
        cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
        cmd.Parameters.AddWithValue("@PrecioUnitario", Convert.ToDecimal(txtPrecio.Text));
        cmd.Parameters.AddWithValue("@ITEBIS", Convert.ToDecimal(txtITEBIS.Text));
        cmd.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento.Text));

        con.Open();
        cmd.ExecuteNonQuery();
        MessageBox.Show("Factura guardada correctamente");
    }
}
```
### Aqui vemos el formulario para registrar la factura con los texbox..
---
![Image](https://github.com/user-attachments/assets/15af1940-11dc-4d98-918e-2bfbd670afca)
---
### Paso 3: Gestión de Facturas (FormGestionFacturas.cs)
---
### 🧾 Funcionalidad:
---
-Mostrar todas las facturas en un DataGridView.
-Permitir seleccionar una factura para editar o eliminar.
-Cargar los datos al FormFactura o un panel de edición.

### 🧩 Estructura básica:
---
-Tienes que tener esto en tu Form:

-dgvFacturas: tu DataGridView
-Botones: btnEditar, btnEliminar, btnActualizar

-Código para mostrar las facturas en el DataGridView:
```csharp
private void CargarFacturas()
{
    using (SqlConnection con = new conexion().Conectar())
    {
        string query = "SELECT * FROM Facturas";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dgvFacturas.DataSource = dt;
    }
}
```
-Llamas esto en el Form_Load:
---
```csharp
private void FormGestionFacturas_Load(object sender, EventArgs e)
{
    CargarFacturas();
}
```
-Código para eliminar una factura:
```csharp
private void btnEliminar_Click(object sender, EventArgs e)
{
    if (dgvFacturas.SelectedRows.Count > 0)
    {
        int id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells["Id"].Value);
        using (SqlConnection con = new conexion().Conectar())
        {
            string query = "DELETE FROM Facturas WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Factura eliminada correctamente.");
            CargarFacturas();
        }
    }
}
```
-Código para cargar una factura a TextBox (modo edición):
```csharp
private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0)
    {
        txtId.Text = dgvFacturas.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        txtDescripcion.Text = dgvFacturas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
        txtCategoria.Text = dgvFacturas.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
        txtCantidad.Text = dgvFacturas.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
        txtPrecio.Text = dgvFacturas.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.ToString();
        txtITEBIS.Text = dgvFacturas.Rows[e.RowIndex].Cells["ITEBIS"].Value.ToString();
        txtDescuento.Text = dgvFacturas.Rows[e.RowIndex].Cells["Descuento"].Value.ToString();
    }
}
```
-Código para actualizar factura:
```csharp
private void btnActualizar_Click(object sender, EventArgs e)
{
    using (SqlConnection con = new conexion().Conectar())
    {
        string query = "UPDATE Facturas SET Descripcion = @Descripcion, Categoria = @Categoria, Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario, ITEBIS = @ITEBIS, Descuento = @Descuento WHERE Id = @Id";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));
        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
        cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
        cmd.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtCantidad.Text));
        cmd.Parameters.AddWithValue("@PrecioUnitario", Convert.ToDecimal(txtPrecio.Text));
        cmd.Parameters.AddWithValue("@ITEBIS", Convert.ToDecimal(txtITEBIS.Text));
        cmd.Parameters.AddWithValue("@Descuento", Convert.ToDecimal(txtDescuento.Text));

        con.Open();
        cmd.ExecuteNonQuery();
        MessageBox.Show("Factura actualizada correctamente.");
        CargarFacturas();
    }
}
```
### Ahora vamos a visualizar el form.
---
![Image](https://github.com/user-attachments/assets/b5caeeac-b73c-4c2e-b6d0-5634d91a7f11)

### Paso 4: Crear y configurar el DataSet (BD_FacturacionPruebasDataSet.xsd)
---
### 📌 ¿Para qué sirve?
El .xsd se usa para vincular los datos con el ReportViewer (.rdlc).
---
### ✅ Pasos para configurarlo:
-Haz doble clic sobre BD_FacturacionPruebasDataSet.xsd.
-Se abrirá un diseñador en blanco. Haz clic derecho y selecciona:
-Agregar > Tabla de datos (DataTable).
-Ponle nombre Facturas.
### Haz clic derecho sobre Facturas y selecciona Agregar > Columna por cada campo:
---
-Id (int)
-Descripcion (string)
-Categoria (string)
-Cantidad (int)
-PrecioUnitario (decimal)
-ITEBIS (decimal)
-Descuento (decimal)
-TotalGeneral (decimal)

### Se te creara una tabla.
--- 
![Image](https://github.com/user-attachments/assets/e1ce3d0f-59ce-416b-8133-c7f641450064)
---
### 📊 Llenar el DataSet con los datos:
-Dentro de FormReporte.cs o cualquier formulario que use el ReportViewer:
---
```csharp
using ReportesFacturasApp.BD_FacturacionPruebasDataSetTableAdapters;

private void FormReporte_Load(object sender, EventArgs e)
{
    FacturasTableAdapter adapter = new FacturasTableAdapter();
    BD_FacturacionPruebasDataSet.FacturasDataTable tabla = new BD_FacturacionPruebasDataSet.FacturasDataTable();
    adapter.Fill(tabla);

    ReportDataSource rds = new ReportDataSource("DataSetFacturas", (DataTable)tabla);
    reportViewer1.LocalReport.DataSources.Clear();
    reportViewer1.LocalReport.DataSources.Add(rds);
    this.reportViewer1.RefreshReport();
}
```
Nota: el nombre "DataSetFacturas" debe coincidir con el nombre que configures al vincular el RDLC al DataSet.
---
## ✅ Paso 5: Crear el Reporte Visual con ReportViewer
---
## 📄 Crear el archivo .rdlc (como ReporteFactura.rdlc)
Asegúrate de que esté en el proyecto!!
---
### 🛠 Instalar los paquetes necesarios desde NuGet
---
-Abre la Consola del Administrador de Paquetes y ejecuta:
```chsarp
Install-Package Microsoft.Reporting.WinForms
```
### O desde Administrador de NuGet en Visual Studio:

- Haz clic derecho en el proyecto → Administrar paquetes NuGet
Busca: Microsoft.Reporting.WinForms

Instala la última versión estable.

🔍 Nota importante: Si usas .NET Framework 4.x, selecciona la versión compatible (por ejemplo, Microsoft.Reporting.WinForms v150.x si estás en .NET Framework 4.7 o 4.8).
---
###  ✅ Paso 6: Agregar el control ReportViewer en el formulario FormReporte.cs
---
### 🧩 6.1. Agregar el control
-Abre el formulario FormReporte.cs en vista de diseño.
-En la Caja de herramientas busca "ReportViewer".
-Si no aparece, haz clic derecho → "Elegir elementos" → Marca "Microsoft.ReportViewer.WinForms".
-Arrástralo al formulario y cambia su nombre a reportViewer1.
---
![image](https://github.com/user-attachments/assets/aa2b69e6-6343-4b08-8583-b00311010631)
---
### ✅ Paso 7: Cargar datos en el Reporte
---
🧾 Código base para cargar el reporte
En el FormReporte.cs, en el evento Load, agrega:
---
```csharp
using Microsoft.Reporting.WinForms;

private void FormReporte_Load(object sender, EventArgs e)
{
    // Establecer el path del reporte
    this.reportViewer1.LocalReport.ReportPath = "ReporteFactura.rdlc";

    // Crear el DataSet y adaptador
    BD_FacturacionPruebasDataSet ds = new BD_FacturacionPruebasDataSet();
    BD_FacturacionPruebasDataSetTableAdapters.FacturasTableAdapter ta = new BD_FacturacionPruebasDataSetTableAdapters.FacturasTableAdapter();
    ta.Fill(ds.Facturas); // Asegúrate que 'Facturas' es el nombre exacto de tu tabla en el DataSet

    // Crear el origen de datos
    ReportDataSource rds = new ReportDataSource("DataSetFactura", ds.Tables["Facturas"]);
    this.reportViewer1.LocalReport.DataSources.Clear();
    this.reportViewer1.LocalReport.DataSources.Add(rds);

    this.reportViewer1.RefreshReport();
}
```
---
📌 Importante: El nombre "DataSetFactura" debe coincidir con el que configuraste en el archivo .rdlc.

### ✅ Paso 8: Configurar el archivo .rdlc (si no lo hiciste)
-Nombre ReporteFactura.rdlc.
-En el diseñador:
---
### Crea una tabla.
Usa los campos: Descripcion, Categoria, Cantidad, PrecioUnitario, ITEBIS, Descuento, TotalGeneral.
---
Ve a "Report → Data Sources" y asegúrate de que el dataset esté vinculado correctamente como DataSetFactura y aqui en el archivo ponemos arrastrar los campos en valores en grupo de filas o columnas.
![Image](https://github.com/user-attachments/assets/c7030d71-d7c1-483f-ae39-1ec3c27f67d6)
---

### ✅ Paso 9: Agrega RefreshReport en el constructor del formulario
En el constructor FormReporte, asegúrate de tener esto:
---
```csharp
public FormReporte()
{
    InitializeComponent();
    this.reportViewer1.RefreshReport();
}
```
---
### Ya de una vez corrido tendra que verse algo asi que se pueda imprimir y todo.
![Image](https://github.com/user-attachments/assets/81948ff4-51af-4748-aa06-d00e2823a019)
