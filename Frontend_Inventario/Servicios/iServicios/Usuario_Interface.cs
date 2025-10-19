using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Usuario_Interface
    {
        public Task<IEnumerable<Usuario_Modelo_Respuesta>> Get_Usuarios();
        
        public Task<Dictionary<string,object>> Get_Usuario_Id(int idUsuario);

        public Task<Usuario_Modelo_Peticion> Crear_Usuario(Usuario_Modelo_Peticion usuario);

        public Task<Usuario_Modelo_Peticion> Editar_Usuario(Usuario_Modelo_Peticion usuario);
        
        public Task<bool> Eliminar_Usuario(int idUsuario);        
    }
}
