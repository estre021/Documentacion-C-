using System.Data.SqlClient;

public class conexion
{
    public static SqlConnection Conectar()
    {
        string cadena = "Server=LENOVO2\\MSSQLSERVER01;Database=BD_FacturacionPruebas;Trusted_Connection=True;";
        SqlConnection cn = new SqlConnection(cadena);
        return cn;
    }
}

