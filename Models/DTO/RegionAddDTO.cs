using System.ComponentModel.DataAnnotations;

namespace NZZwalks.Models.DTO
{
    public class RegionAddDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage =("Name has to be maximum 50 characters"))]
        public string Name { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Code Length should be minimum 3 characters")]
        [MaxLength(3, ErrorMessage ="Code length should not exceed more than 3 characters")]
        public string Code { get; set; }

        public string? RegionImgUlr { get; set; }
    }
}
