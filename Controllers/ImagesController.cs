using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZZwalks.CustomActionFilters;
using NZZwalks.ImageRepository;
using NZZwalks.Models.Domain;
using NZZwalks.Models.DTO;

namespace NZZwalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IimageRepo imageRepo;

        public ImagesController(IimageRepo imageRepo)
        {
            this.imageRepo = imageRepo;
        }

        [HttpPost]
        [Route("UploadImage")]
        [ValidateModel]
        public async Task<IActionResult> Upload([FromForm] ImageUploadDTO imageUploadDTO)
        {
            ValidateFileUpload(imageUploadDTO);
            //user repo
            var imageDomain = new Image
            {
                File = imageUploadDTO.File,
                FileDescritpion = imageUploadDTO.FileDescritpion,
                FileSizeInBytes = imageUploadDTO.File.Length,
                FileName = imageUploadDTO.Filename,
                FileExtension = Path.GetExtension(imageUploadDTO.File.FileName)
            };
            await imageRepo.Upload(imageDomain);
            return Ok(imageDomain);
        }

        private void ValidateFileUpload(ImageUploadDTO requestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(requestDTO.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported File Extension");
            }

            if(requestDTO.File.Length > 10485760)
            {
                ModelState.AddModelError("FileLength", "FileSize More Than 10mb ");
            }
        }
    }
}
