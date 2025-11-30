using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Movimiento_Interface
    {
        public Task<IEnumerable<Movimiento_Modelo_Respuesta>> Get_Movimientos();

        public Task<Dictionary<string, object>> Get_Movimiento_Id(int idMovimiento);

        public Task<Movimiento_Modelo_Peticion> Crear_Movimiento(Movimiento_Modelo_Peticion movimiento);

        public Task<Movimiento_Modelo_Peticion> Editar_Movimiento(Movimiento_Modelo_Peticion movimiento);

        public Task<bool> Eliminar_Movimiento(int idMovimiento);
    }
}
