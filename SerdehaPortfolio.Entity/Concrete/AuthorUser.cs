using Microsoft.AspNetCore.Identity;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class AuthorUser:IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
