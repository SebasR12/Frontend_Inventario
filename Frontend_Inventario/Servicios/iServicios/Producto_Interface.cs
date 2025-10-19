using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Producto_Interface
    {
        public Task<IEnumerable<Producto_Modelo_Respuesta>> Get_Producto();

        public Task<Dictionary<string, object>> Get_Producto_ID(int idProducto);

        public Task<Producto_Modelo_Peticion> Crear_Producto(Producto_Modelo_Peticion producto);

        public Task<Producto_Modelo_Peticion> Editar_Producto(Producto_Modelo_Peticion producto);

        public Task<bool> Eliminar_Producto(int idProducto);
    }
}
