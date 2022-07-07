using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
        public bool Status { get; set; }

        public List<UserMessage>? UserMessages { get; set; }
    }
}
