using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class SocialMedia: IEntity
    {
        public int SocialMediaId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
    }
}
