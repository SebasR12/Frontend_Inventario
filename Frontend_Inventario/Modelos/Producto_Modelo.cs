namespace Frontend_Inventario.Modelos
{
    public class Producto_Modelo_Respuesta
    {
        public int idProducto { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public decimal margenGanancia { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public int idCategoria { get; set; }
        public int idProveedor{ get; set; }

    }
    public class Producto_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public decimal margenGanancia { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public int idCategoria { get; set; }
        public int idProveedor { get; set; }

    }
}
