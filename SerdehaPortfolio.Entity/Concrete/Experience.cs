using System.ComponentModel.DataAnnotations.Schema;
using SerdehaPortfolio.Entity.Abstract;
using Microsoft.AspNetCore.Http;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Experience:IEntity
    {
        public int ExperienceId { get; set; }
        public string? Name { get; set; }
        public string? Date { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public string? Description { get; set; }
    }
}
