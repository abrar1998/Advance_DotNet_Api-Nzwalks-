using NZZwalks.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZZwalks.Models.DTO
{
    public class AddWalkDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage ="Name characters should not exceed 50 character")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please enter km")]
        public double LengthInkm { get; set; }
        public string? WalkImgUrl { get; set; }

        ///create relation with difficulty <summary>
        /// create relation with difficulty
        /// </summary>
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }

    }
}
