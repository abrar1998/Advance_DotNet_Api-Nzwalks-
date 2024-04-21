namespace NZZwalks.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInkm {  get; set; }
        public string? WalkImgUrl {  get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        public Difficulty Difficulty { get; set; } // one to one 
        public Region Region { get; set; } // one to one relation
    }
}
