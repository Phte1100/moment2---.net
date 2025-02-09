namespace Moment2Mvc.Models
{
    using System.ComponentModel.DataAnnotations;

    // Modellen representerar en fiskfångst
    public class FishModel
    {
        // Fiskesorten måste anges
        [Required(ErrorMessage = "Fiskesort är obligatoriskt")]
        public required string Species { get; set; }
        
        // Platsen där fisken fångades måste anges
        [Required(ErrorMessage = "Plats är obligatoriskt")]        
        public required string Location { get; set; }
        
        // Vikten måste vara mellan 1 och 100000 gram, annars visas ett anpassat felmeddelande
        [Range(1, 100000, ErrorMessage = "Vikt måste vara mellan 1 och 100000 gram")]
        public int Weight { get; set; }
        
        // Längden måste vara mellan 1 och 300 cm, annars visas ett anpassat felmeddelande
        [Range(1, 300, ErrorMessage = "Längd måste vara mellan 1 och 300 cm")]
        public int Length { get; set; }
        
        // Datum måste anges, standardvärde sätts till dagens datum
        [Required(ErrorMessage = "Datum är obligatoriskt")]
        public DateTime Date { get; set; } = DateTime.Today;

        // Beskrivningen är obligatorisk och får vara max 250 tecken
        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        [MaxLength(250, ErrorMessage = "Beskrivning får inte vara längre än 250 tecken")]
        public required string Description { get; set; }

        // Användaren måste ange om fisken släpptes tillbaka eller ej
        [Required(ErrorMessage = "Välj om fisken släpptes tillbaka")]
        public required string Released { get; set; }

        // Konstruktor som ser till att alla strängvärden får en tom standardsträng vid instansiering
        public FishModel() 
        {
            Species = string.Empty;
            Location = string.Empty;
            Description = string.Empty;
            Released = string.Empty;
        }
    }
}
