using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Models
{
    [BindProperties]
    public class CarViewModel
    {
        [Required(ErrorMessage = "Se requiere saber la patente del carro")]
        [MaxLength(8, ErrorMessage = "La patente debe tener exactamente 8 caracteres")]
        [MinLength(8, ErrorMessage = "La patente debe tener exactamente 8 caracteres")]
        public string Patente { get; set; }

        [Required(ErrorMessage = "Se requiere saber la marca del carro")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Se requiere saber el modelo del carro")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Se requiere saber la cantidad de puertas")]
        public int Puertas { get; set; }
        
        [Range(1,int.MaxValue, ErrorMessage = "Se require un titular")]
        public int OwnerId { get; set; }
    }
}