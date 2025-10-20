using GestorGastosAPI.DTOs;
using GestorGastosAPI.Models;

namespace GestorGastosAPI.Services
{
    public interface ITransaccionService
    {
        Task<List<Transaccion>> ObtenerTodas();

        Task<Transaccion?> ObtenerPorId(int id);

        Task<List<Transaccion>> Filtrar(
            string? descripcion,
            string? tipo,
            string? categoria,
            DateTime? desde,
            DateTime? hasta,
            string? mimeType
        );

        Task<Transaccion> Agregar(TransaccionCreateDto dto);

        public Task<bool> Actualizar(int id, TransaccionUpdateDto dto);

        Task<bool> Eliminar(int id);
    }
}
