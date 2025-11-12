using MVCVoertuig.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCVoertuig.Models
{
    public class Voertuig
    {
        public int VoertuigId { get; set; }

        [Required]
        [StringLength(100)]
        public string Merk { get; set; }

        [Required]
        [StringLength(100)]
        public string MerkType { get; set; }

        [Required]
        [CustomBouwjaarValidation]
        public int Bouwjaar { get; set; }

        [Required]
        [Range(0,5000000)]
        public int Km { get; set; }

        [Required]
        [Column(TypeName= "decimal(8,2)")]
        public decimal VerkoopPrijs { get; set; }

        public bool AanwezigInShowroom { get; set; }

    }
}
