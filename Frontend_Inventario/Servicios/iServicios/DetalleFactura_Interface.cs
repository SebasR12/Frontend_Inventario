using Frontend_Inventario.Modelos;

namespace Frontend_Inventario.Servicios.iServicios
{
    public interface DetalleFactura_Interface
    {
        public Task<IEnumerable<Detalle_Factura_Modelo_Respuesta>> Get_DetalleFacturas();
        public Task<Dictionary<string, object>> Get_DetalleFactura_Id(int idDetalle);
        public Task<Dictionary<string, object>> Get_DetalleFactura_IdFactura(int idFactura);
        public Task<Detalle_Factura_Modelo_Peticion> Crear_DetalleFactura(Detalle_Factura_Modelo_Peticion detalleFactura);
        public Task<Detalle_Factura_Modelo_Peticion> Editar_DetalleFactura(Detalle_Factura_Modelo_Peticion detalleFactura);
        public Task<bool> Eliminar_DetalleFactura(int idDetalle);

    }
}
