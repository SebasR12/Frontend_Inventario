using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Categoria_Interface
    {
        public Task<IEnumerable<Categoria_Modelo_Respuesta>> Get_Categorias();

        public Task<Dictionary<string, object>> Get_Categoria_Id(int idCategoria);

        public Task<Categoria_Modelo_Peticion> Crear_Categoria(Categoria_Modelo_Peticion categoria);

        public Task<Categoria_Modelo_Peticion> Editar_Categoria(Categoria_Modelo_Peticion categoria);

        public Task<bool> Eliminar_Categoria(int idCategoria);
    }
}
