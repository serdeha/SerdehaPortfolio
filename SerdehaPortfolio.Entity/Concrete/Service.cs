using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Service: IEntity
    {
        public int ServiceId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped] 
        public IFormFile? FormFile { get; set; }
    }
}
