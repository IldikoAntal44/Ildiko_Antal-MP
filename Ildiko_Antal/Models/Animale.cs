using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ildiko_Antal.Models
{
    public class Animale
    {
        public int ID { get; set; }

        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string nume { get; set; }

        [Display(Name = "Regim alimentar/Medicatie")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string  regim { get; set; }

        [Display(Name = "Alte detalii")]
        [Required(ErrorMessage = "Va rog sa completati campul."), MinLength(5, ErrorMessage = "Necesar minim 5 caractere."), MaxLength(30, ErrorMessage = "Admis maxim 30 de caractere.")]
        public string altedetalii { get; set; }

        [Display(Name = "Check-In")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        [DataType(DataType.Date)]
        public DateTime checkin { get; set; }

        [Display(Name = "Specie")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int SpecieID { get; set; }
        public Specie Specie { get; set; }

        [Display(Name = "Adapost")]
        [Required(ErrorMessage = "Va rog sa completati campul.")]
        public int AdapostID { get; set; }
        public Adapost Adapost { get; set; }
    }
}
