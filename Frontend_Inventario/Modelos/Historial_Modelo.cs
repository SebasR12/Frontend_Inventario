namespace Frontend_Inventario.Modelos
{
    public class Historial_Modelo_Respuesta
    {
        public int idHistorial { get; set; }
        public int idProducto { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public string fecha { get; set; }
    }
    public class Historial_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idHistorial { get; set; }
        public int idProducto { get; set; }          // cambiar de decimal a int
        public decimal precioCompra { get; set; }    // decimal está bien
        public decimal precioVenta { get; set; }     // cambiar de int a decimal
    }

}
