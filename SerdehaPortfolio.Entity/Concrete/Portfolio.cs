using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Portfolio:IEntity
    {
        public int PortfolioId { get; set; }
        public string? Name { get; set; }
        public string? WebsiteName  { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFormFile { get; set; }
        public string? ThumbnailImageUrl { get; set; }
        [NotMapped] 
        public IFormFile? ThumbnailFormFile { get; set; }
    }
}
