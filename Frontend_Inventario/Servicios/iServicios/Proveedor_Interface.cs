using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Proveedor_Interface
    {
        public Task<IEnumerable<Proveedor_Modelo_Respuesta>> Get_Proveedores();

        public Task<Dictionary<string,object>> Get_Proveedor_Id(int idProveedor);

        public Task<Proveedor_Modelo_Peticion> Crear_Proveedor(Proveedor_Modelo_Peticion proveedor);

        public Task<Proveedor_Modelo_Peticion> Editar_Proveedor(Proveedor_Modelo_Peticion proveedor);

        public Task<bool> Eliminar_Proveedor(int idProveedor);
    }
}
