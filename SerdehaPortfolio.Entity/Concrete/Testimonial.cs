using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Testimonial:IEntity
    {
        public int TestimonialId { get; set; }
        public string? ClientName { get; set; }
        public string? Company { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
    }
}
