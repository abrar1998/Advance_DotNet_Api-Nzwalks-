using NZZwalks.Models.Domain;

namespace NZZwalks.ImageRepository
{
    public interface IimageRepo
    {
        Task<Image> Upload(Image image);
    }
}
