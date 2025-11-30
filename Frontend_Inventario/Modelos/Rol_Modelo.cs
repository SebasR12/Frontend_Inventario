namespace Frontend_Inventario.Modelos
{
    public class Rol_Modelo_Respuesta
    {
        public int idRol { get; set; }
        public string nombreRol { get; set; }
        public string descripcion { get; set; }
    }
    public class Rol_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idRol { get; set; }
        public string nombreRol { get; set; }
        public string descripcion { get; set; }
    }
}
