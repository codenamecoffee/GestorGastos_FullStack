using System.ComponentModel.DataAnnotations;

namespace GestorGastosAPI.Utils
{
    public class NoEspaciosEnBlancoAttribute : ValidationAttribute
    {   
        public NoEspaciosEnBlancoAttribute() 
        {
            ErrorMessage = "El campo no puede estar vacío ni contener solo espacios.";
        }

        public override bool IsValid(object? value) // No podemos cambiar la firma del método
        {
            if (value is string str)
            {
                return !string.IsNullOrEmpty(str);
            }

            return true; // No aplica la validación sino es un string. Ej: int es true.
        }
    }
}

/* Al final no usé esto porque [Required] ya resolvía por si solo. 
 No probé, pensé que solo gestionaba valores null. */