namespace Frontend_Inventario.Modelos
{
    public class Proveedor_Modelo_Respuesta
    {
        public int idProveedor { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
    }
    public class Proveedor_Modelo_Peticion 
    {
        public int proceso { get; set; }
        public int idProveedor { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string contacto { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
    }
}
