using System.ComponentModel.DataAnnotations;

namespace CasoPractico1_PrograAvanzada.Models
{
    public enum UnidadMedida
    {
        [Display(Name = "Unidad")]
        Unidad = 1,

        [Display(Name = "Kilogramo")]
        Kilogramo = 2,

        [Display(Name = "Litro")]
        Litro = 3
    }
}
