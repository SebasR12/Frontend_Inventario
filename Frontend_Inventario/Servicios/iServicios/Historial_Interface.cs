using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Historial_Interface
    {
        public Task<IEnumerable<Historial_Modelo_Respuesta>> Get_Historial();

        public Task<Dictionary<string, object>> Get_Historial_Id(int idHistorial);

        public Task<Historial_Modelo_Peticion> Crear_Historial(Historial_Modelo_Peticion historial);

        public Task<Historial_Modelo_Peticion> Editar_Historial(Historial_Modelo_Peticion historial);

        public Task<bool> Eliminar_Historial(int idHistorial);
    }


}
