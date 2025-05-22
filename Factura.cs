namespace ReportesFacturasApp
{
    internal class Factura
    {
     
            public int ID { get; set; }
            public string DESCRIPCION { get; set; }
            public string CATEGORIA { get; set; }
            public int CANTIDAD { get; set; }
            public decimal PRECIO_UNITARIO { get; set; }
            public decimal ITEBIS { get; set; }
            public decimal DESCUENTO { get; set; }
            public decimal TOTAL_GENERAL { get; set; }
       

    }
}
