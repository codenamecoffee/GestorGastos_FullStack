using GestorGastosAPI.Data;
using GestorGastosAPI.DTOs;
using GestorGastosAPI.Models;
using GestorGastosAPI.Utils;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorGastosAPI.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly AppDbContext _context; // Para Dependeny Injection

        public TransaccionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaccion>> ObtenerTodas()
        {
            return await _context.Transacciones.ToListAsync();
        }

        public async Task<Transaccion?> ObtenerPorId(int id) 
        {
            return await _context.Transacciones.FindAsync(id);
        }

        public async Task<List<Transaccion>> Filtrar(
            string? descripcion,
            string? tipo,
            string? categoria,
            DateTime? desde,
            DateTime? hasta,
            string? mimeType
        )
        {
            var query = _context.Transacciones.AsQueryable();

            if (!string.IsNullOrWhiteSpace(descripcion))
                query = query.Where(transaccion => EF.Functions.Like(transaccion.Descripcion, $"%{descripcion}%"));

            if (!string.IsNullOrWhiteSpace(tipo) && Enum.TryParse<TipoTransaccion>(tipo, true, out var tipoEnum))
                query = query.Where(transaccion => transaccion.Tipo == tipoEnum);

            if (!string.IsNullOrWhiteSpace(categoria) && Enum.TryParse<Categoria>(categoria, true, out var categoriaEnum))
                query = query.Where(transaccion => transaccion.Categoria == categoriaEnum);

            if (desde.HasValue)
                query = query.Where(transaccion => transaccion.Fecha >= desde.Value);

            if (hasta.HasValue)
            {
                // Incluye todo el día 'hasta'
                var finDelDia = hasta.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(t => t.Fecha <= finDelDia);
            }

            if (!string.IsNullOrWhiteSpace(mimeType))
                query = query.Where(transaccion => transaccion.ComprobanteMimeType == mimeType);

            return await query.ToListAsync();
        }

        public async Task<Transaccion> Agregar(TransaccionCreateDto dto) 
        {
            byte[]? comprobanteBytes = null;

            if(dto.Comprobante != null) 
            {
                /*Validador.ValidarComprobante(dto.Comprobante);*/ // Clase y método desde ./Utils

                // Debuggeando el comprobante:
                Console.WriteLine($"Recibiendo comprobante: {dto.Comprobante.FileName}, Tamaño: {dto.Comprobante.Length} bytes.");

                using var memoryStream = new MemoryStream();
                await dto.Comprobante.CopyToAsync(memoryStream);
                comprobanteBytes = memoryStream.ToArray();

                // Chequeamos si el comprobante logró convertirse a byte[]
                Console.WriteLine($"Comprobante convertido a bytes: {comprobanteBytes.Length} bytes.");

            }
            else // En caso de que no se haya recibido el comprobante. 
            {
                Console.WriteLine("No se recibió ningun comprobante.");
            }

            var fecha = dto.Fecha?.ToUniversalTime() ?? DateTime.UtcNow;

            // Operador '?'
            // (1) - Si dto.Fecha no es nulo, entonces llamá a ToUniversalTime() sobre ese valor.
            // (2) - Si es nulo, devolvé null sin lanzar error.

            // Operador '??'
            // (1) - Si el valor a la izquierda es nulo, usá el de la derecha.

            var transaccion = new Transaccion
                {
                    Fecha = fecha,
                    Descripcion = dto.Descripcion!,
                    Categoria = dto.Categoria!.Value,
                    Monto = dto.Monto!.Value,
                    Moneda = dto.Moneda!,
                    Tipo = dto.Tipo!.Value,
                    Comprobante = comprobanteBytes,
                    ComprobanteMimeType = dto.Comprobante?.ContentType // Guardamos el tipo.
                };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return transaccion;
        }

        public async Task<bool> Actualizar(int id, TransaccionUpdateDto dto) 
        {
            var transaccion = await _context.Transacciones.FindAsync(id);

            if (transaccion == null) 
            {
                return false;
            };

            if (dto.Fecha != null) 
            {
                // Nos aseguramos de convertir a UTC
                var fecha = dto.Fecha.Value;

                if (fecha.Kind == DateTimeKind.Unspecified)
                    fecha = DateTime.SpecifyKind(fecha, DateTimeKind.Local);

                transaccion.Fecha = fecha.ToUniversalTime();
            }

            transaccion.Descripcion = dto.Descripcion!;
            transaccion.Categoria = dto.Categoria!.Value;
            transaccion.Monto = dto.Monto!.Value;
            transaccion.Moneda = dto.Moneda!;
            transaccion.Tipo = dto.Tipo!.Value;


            if (dto.ActualizarComprobante) // Si queremos eliminar el comprobante
            {
                transaccion.Comprobante = null;
                transaccion.ComprobanteMimeType = null;

                // Si tenemos comprobante nuevo, lo sustituimos.
                if (dto.ComprobanteInput != null) // Sino hay, queda todo igual.
                {
                    //Validador.ValidarComprobante(dto.ComprobanteInput);  // Hay que actualizarlo (fue pensado para imágenes).

                    using var memoryStream = new MemoryStream();
                    await dto.ComprobanteInput.CopyToAsync(memoryStream);
                    transaccion.Comprobante = memoryStream.ToArray();

                    // Actualizamos el MIME type
                    transaccion.ComprobanteMimeType = dto.ComprobanteInput.ContentType;
                }
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id) 
        {
            var transaccion = await _context.Transacciones.FindAsync(id);

            if (transaccion == null)
            {
                return false;
            }
            
            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();
            
            return true;
            
        }
    }
}
