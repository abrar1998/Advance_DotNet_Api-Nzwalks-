using NZZwalks.DataContext;
using NZZwalks.Models.Domain;

namespace NZZwalks.ImageRepository
{
    public class ImageRepo:IimageRepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AccountContext dbcontext;

        public ImageRepo(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor , AccountContext dbcontext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbcontext = dbcontext;
        }

        public async Task<Image> Upload(Image image)
        {
            var fileLocation = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName} {image.FileExtension}");
            FileStream fs = new FileStream(fileLocation, FileMode.Create);
            await image.File.CopyToAsync(fs);
            //path be like :-  https://localhost:7213/Images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.Path}/Images/{image.FileName}{image.FileExtension}";
            image.FilePath = urlFilePath;
            await dbcontext.AddAsync(image);
            await dbcontext.SaveChangesAsync();
            return image;


        }
    }
}
