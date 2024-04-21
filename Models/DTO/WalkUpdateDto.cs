using NZZwalks.Models.Domain;

namespace NZZwalks.Models.DTO
{
    public class WalkUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInkm { get; set; }
        public string? WalkImgUrl { get; set; }

        ///create relation with difficulty
        public Guid DifficultyId { get; set; }
        
        public Guid RegionId { get; set; }
 
    }
}
