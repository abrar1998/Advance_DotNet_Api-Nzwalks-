using NZZwalks.Models.Domain;

namespace NZZwalks.Models.DTO
{
    public class SendWalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInkm { get; set; }
        public string? WalkImgUrl { get; set; }

        ///create relation with difficulty
        public RegionDTO Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
