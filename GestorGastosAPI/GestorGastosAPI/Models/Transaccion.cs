namespace GestorGastosAPI.Models
{
    public enum TipoTransaccion 
    { 
        Ingreso = 1, 
        Gasto = 2
    }

    public enum Categoria 
    {
        Alquiler = 0,
        Boletos = 1,
        Peluquería = 2,
        Gimnasio = 3,
        Streaming = 4,
        Saldo = 5,
        Consumibles = 6,
        Pareja = 7,
        Imprevistos = 8
    }

    public class Transaccion
    {
        public int Id { get; set; } // Clave primaria

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; } = ""; // Para que se saque el miedo de ser NULL, pero nunca lo será igual. Tampoco podrá quedarse con string vacío.

        // Propiedad automática para el campo (oculto) generado automáticamente
        public Categoria Categoria { get; set; }

        public decimal Monto { get; set; }

        // Propiedad automática para el campo (oculto) generado automáticamente.
        public string Moneda { get; set; } = ""; // Para que se saque el miedo de ser NULL, pero nunca lo será igual. Tampoco podrá quedarse con string vacío.

        // Propiedad automática para el campo (oculto) generado automáticamente
        // que usa la enumeración declarada encima de la clase para almacenar el tipo de transacción.
        public TipoTransaccion Tipo { get; set; }

        // Propiedad automática (idem a la anterior) que contendrá
        // a una imagen o pdf comprobante de la transacción
        //public byte[]? ImagenComprobante { get; set; }
        public byte[]? Comprobante { get; set; }

        //public string? ImagenMimeType { get; set; }
        public string? ComprobanteMimeType { get; set; }



        /* Cosas ya no necesarias debido a usar DTOs y un backend más avanzado: */

        //// Campo
        //private DateTime _fecha; 

        //// Propiedad
        //public DateTime Fecha 
        //{
        //    get => _fecha;

        //    // Operador ternario, como en js:
        //    set => _fecha = value == default ? throw new ArgumentException("La fecha no puede estar vacía.") : value; 
        //}

        //// Campo
        //private string _descripcion = string.Empty;

        //// Propiedad
        //public string Descripcion 
        //{
        //    get => _descripcion;

        //    set  
        //    {
        //        if (string.IsNullOrWhiteSpace(value) || value.Length < 3) 
        //        {
        //            throw new ArgumentException("La descripción debe tener al menos 3 caracteres.");
        //        };

        //        _descripcion = value;
        //    }
        //}

        //// Campo
        //private decimal _monto;

        //// Propiedad
        //public decimal Monto
        //{
        //    get => _monto;

        //    set 
        //    {
        //        if (value < 0) 
        //        {
        //            throw new ArgumentException("El monto no puede ser negativo.");
        //        };

        //        _monto = value;
        //    }
        //}

    } // Fin class Transaccion
}
