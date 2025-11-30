using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Rol_Interface
    {
        public Task<IEnumerable<Rol_Modelo_Respuesta>> Get_Roles();

        public Task<Dictionary<string, object>> Get_Rol_Id(int idRol);

        public Task<Rol_Modelo_Peticion> Crear_Rol(Rol_Modelo_Peticion rol);

        public Task<Rol_Modelo_Peticion> Editar_Rol(Rol_Modelo_Peticion rol);

        public Task<bool> Eliminar_Rol(int idRol);
    }
}
