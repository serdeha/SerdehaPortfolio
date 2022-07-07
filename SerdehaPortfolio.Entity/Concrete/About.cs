using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class About:IEntity
    {
        public int AboutId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Age { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
