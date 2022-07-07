using Microsoft.AspNetCore.Http;

namespace SerdehaPortfolio.Core.Extensions
{
    public static class ImageHelperExtension
    {
        public static string UploadImage(IFormFile? formFile, string imgPath)
        {
            var extension = Path.GetExtension(formFile?.FileName);
            var newFileName = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Millisecond}_{Path.GetFileNameWithoutExtension(formFile?.FileName)}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{imgPath}", newFileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            return newFileName;
        }

        public static void DeleteImage(string imageUrl, string imgPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\img\\{imgPath}", imageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
