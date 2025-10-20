namespace GestorGastosAPI.Utils
{
    public static class Validador
    {
        private static readonly string[] _extensionesPermitidas = [".jpg", ".jpeg", ".png"];

        private static readonly string[] _tiposMimePermitidos = ["image/jpeg", "image/png"];

        private const long _tamañoMaximoComprobante = 5 * 1024 * 1024; // 5 MB

        public static void ValidarComprobante(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                throw new ArgumentException("El archivo está vacío.");
            }

            if (archivo.Length > _tamañoMaximoComprobante)
            {
                throw new ArgumentException("El archivo es demasiado grande. Máximo permitido: 5 MB.");
            }

            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            if (!_extensionesPermitidas.Contains(extension))
            {
                throw new ArgumentException("Extensión no permitida. Solo .jpg, .jpeg y .png.");
            }

            if (!_tiposMimePermitidos.Contains(archivo.ContentType))
            {
                throw new ArgumentException("Tipo MIME no permitido. Solo JPEG y PNG.");
            }
        }
    }
}
