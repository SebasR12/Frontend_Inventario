using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Cliente_Interface
    {
        public Task<IEnumerable<Cliente_Modelo_Respuesta>> Get_Clientes();
        public Task<Dictionary<string, object>> Get_Cliente_Id(int idCliente);
        public Task<Cliente_Modelo_Peticion> Crear_Cliente(Cliente_Modelo_Peticion cliente);
        public Task<Cliente_Modelo_Peticion> Editar_Cliente(Cliente_Modelo_Peticion cliente);
        public Task<bool> Eliminar_Cliente(int idCliente);
    }
}
