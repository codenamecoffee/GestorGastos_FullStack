using System.ComponentModel.DataAnnotations;
using GestorGastosAPI.Models;
//using GestorGastosAPI.Utils;  Para el custom validation attribute que al final no usé.

namespace GestorGastosAPI.DTOs
{
    public class TransaccionCreateDto
    {
        //[Required(ErrorMessage = "La fecha no puede estar vacía.")] - La lógica impedirá que quede vacía.
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "La descripción no puede estar vacía.")]
        //[NoEspaciosEnBlanco] No es necesario: Required ya resuelve, además no funciona bien. 
        [MinLength(2, ErrorMessage = "Es necesario indicar por lo menos el motivo de la transacción.")]
        [MaxLength(200, ErrorMessage = "La descripción no puede ser superior a 200 caracteres.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario indicar la categoría adecuada: [Alquiler, Boletos, Fundas, Peluquería, Gimnasio, Streaming, Saldo, Consumibles, Pareja, Imprevistos].")]
        public Categoria? Categoria { get; set; }

        [Required(ErrorMessage = "El monto no puede estar vacío.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal? Monto { get; set; }

        //[NoEspaciosEnBlanco] No es necesario: Required ya resuelve, además no funciona bien. 
        [Required(ErrorMessage = "Es necesario indicar UYU o USD, por lo menos.")]
        [MinLength(2, ErrorMessage = "Ingresa una moneda válida.")]
        public string? Moneda { get; set; }

        [Required(ErrorMessage = "Es necesario indicar el tipo de transacción: [Ingreso, Gasto].")]
        public TipoTransaccion? Tipo { get; set; }
        /*public IFormFile? Imagen { get; set; }*/ // Aquí llega la imagen real. 

        public IFormFile? Comprobante { get; set; }
    }
}
