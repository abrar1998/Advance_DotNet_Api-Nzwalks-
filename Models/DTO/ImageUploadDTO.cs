using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NZZwalks.Models.DTO
{
    public class ImageUploadDTO
    {
        [Required]
        public IFormFile File {  get; set; }

        [Required]
        public string Filename {  get; set; }
        public string? FileDescritpion {  get; set; }  
        
        
    }
}
