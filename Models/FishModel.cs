namespace Moment2Mvc.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class FishModel
    {
        [Required(ErrorMessage = "Fiskesort är obligatoriskt")]
        public required string Species { get; set; }
        
        [Required(ErrorMessage = "Plats är obligatoriskt")]        
        public required string Location { get; set; }
        
        [Range(1, 100000), Required(ErrorMessage = "Vikt måste vara mellan 1 och 100000 gram")]
        public int Weight { get; set; }
        
        [Range(1, 300), Required(ErrorMessage = "Längd måste vara mellan 1 och 300 cm")]
        public int Length { get; set; }
        
        [Required(ErrorMessage = "Datum är obligatoriskt")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Beskrivning är obligatoriskt,")]
        [MaxLength(250, ErrorMessage = "Beskrivning får inte vara längre än 250 tecken")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Välj om fisken släpptes tillbaka")]
        public required string Released { get; set; } 
    }
}
