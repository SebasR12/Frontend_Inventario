namespace Frontend_Inventario.Modelos
{
    public class Detalle_Factura_Modelo_Respuesta
    {
        public int idDetalle { get; set; }
        public int idFactura { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }
        public decimal subtotal { get; set; }

    }
    public class Detalle_Factura_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idDetalle { get; set; }
        public int idFactura { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal descuento { get; set; }

    }
}
