using System.ComponentModel.DataAnnotations;

namespace CasoPractico1_PrograAvanzada.Models
{
    public enum TipoVenta
    {
        [Display(Name = "Por unidad")]
        Unidad = 1,

        [Display(Name = "Por peso (kg)")]
        Peso = 2
    }
}
