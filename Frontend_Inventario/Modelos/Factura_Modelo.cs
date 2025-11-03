namespace Frontend_Inventario.Modelos
{
    public class Factura_Modelo_Respuesta
    {
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public string fecha { get; set; }
        public int total { get; set; }
        public int idUsuario { get; set; }
    }
    public class Factura_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public string fecha { get; set; }
        public int total { get; set; }
        public int idUsuario { get; set; }

    }
}
