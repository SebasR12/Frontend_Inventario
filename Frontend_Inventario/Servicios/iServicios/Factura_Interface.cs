using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface Factura_Interface
    {
        public Task<IEnumerable<Factura_Modelo_Respuesta>> Get_Factura();
        public Task<Dictionary<string, object>> Get_Factura_Id(int idFactura);
        public Task<Factura_Modelo_Peticion> Crear_Factura(Factura_Modelo_Peticion factura);
        public Task<Factura_Modelo_Peticion> Editar_Factura(Factura_Modelo_Peticion factura);
        public Task<bool> Eliminar_Factura(int idFactura);

    }
}
