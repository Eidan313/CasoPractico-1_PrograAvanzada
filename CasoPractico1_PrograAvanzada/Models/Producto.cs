using System.ComponentModel.DataAnnotations;

namespace CasoPractico1_PrograAvanzada.Models
{
    public class Producto : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es requerido.")]
        [StringLength(12, ErrorMessage = "El código no puede superar los 12 caracteres.")]
        [Display(Name = "Código")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 80 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es requerida.")]
        [StringLength(40, ErrorMessage = "La categoría no puede superar los 40 caracteres.")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El tipo de venta es requerido.")]
        [EnumDataType(typeof(TipoVenta), ErrorMessage = "El tipo de venta no es válido.")]
        [Display(Name = "Tipo de venta")]
        public TipoVenta TipoVenta { get; set; } = TipoVenta.Unidad;

        // Precio por unidad o por kilo
        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(typeof(decimal), "0.01", "99999999.99", ParseLimitsInInvariantCulture = true, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }

        // Unidades o kilo
        [Range(typeof(decimal), "0", "9999", ParseLimitsInInvariantCulture = true, ErrorMessage = "La existencia debe estar entre 0 y 9999.")]
        public decimal Existencia { get; set; }

        public bool Activo { get; set; } = true;

        public string UnidadMedida => TipoVenta == TipoVenta.Peso ? "kg" : "unid.";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoVenta == TipoVenta.Unidad && Existencia % 1 != 0)
                yield return new ValidationResult("Un producto por unidad debe tener una existencia entera.", new[] { nameof(Existencia) });

            if (TipoVenta == TipoVenta.Peso && decimal.Round(Existencia, 3) != Existencia)
                yield return new ValidationResult("El peso admite como máximo 3 decimales.", new[] { nameof(Existencia) });
        }
    }
}
