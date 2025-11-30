namespace Frontend_Inventario.Modelos
{
    public class Movimiento_Modelo_Respuesta
    {
        public int idMovimiento;
        public int idProducto;
        public string tipoMovimiento;
        public int cantidad;
        public string fecha;
        public int idUsuario;

    }
    public class Movimiento_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        public string tipoMovimiento { get; set; }
        public int cantidad { get; set; }
        public int idUsuario { get; set; }
    }
}
