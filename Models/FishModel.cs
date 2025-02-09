namespace Moment2Mvc.Models
{
    using System.ComponentModel.DataAnnotations;

    // Modellen representerar en fångst av en fisk
    public class FishModel
    {

        [Required(ErrorMessage = "Fiskesort är obligatoriskt")]
        public required string Species { get; set; }
        
        [Required(ErrorMessage = "Plats är obligatoriskt")]        
        public required string Location { get; set; }
        
        // Vikten på fisken måste vara mellan 1 och 100000 gram
        [Range(1, 100000), Required(ErrorMessage = "Vikt måste vara mellan 1 och 100000 gram")]
        public int Weight { get; set; }
        
        // Längden på fisken mellan 1 och 300 cm
        [Range(1, 300), Required(ErrorMessage = "Längd måste vara mellan 1 och 300 cm")]
        public int Length { get; set; }
        
        // Datum för fångsten måste anges, förvald till dagens datum
        [Required(ErrorMessage = "Datum är obligatoriskt")]
        public DateTime Date { get; set; } = DateTime.Today;

        // beskrivning max 250 tecken
        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        [MaxLength(250, ErrorMessage = "Beskrivning får inte vara längre än 250 tecken")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Välj om fisken släpptes tillbaka")]
        public required string Released { get; set; }

        // Konstruktor som ser till att alla strängvärden får en standardtom sträng vid instansiering
        public FishModel() 
        {
            Species = string.Empty;
            Location = string.Empty;
            Description = string.Empty;
            Released = string.Empty;
        }
    }
}
