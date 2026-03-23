namespace Frontend_Inventario.Modelos
{
    public class Categoria_Modelo_Respuesta
    {
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
    public class Categoria_Modelo_Peticion
    {
        public int proceso { get; set; }
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
