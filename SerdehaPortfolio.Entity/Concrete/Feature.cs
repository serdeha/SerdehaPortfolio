using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Feature:IEntity
    {
        public int FeatureId { get; set; }
        public string? Header { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
