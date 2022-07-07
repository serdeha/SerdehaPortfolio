using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Skill:IEntity
    {
        public int SkillId { get; set; }
        public string? Title { get; set; }
        public string? Value { get; set; }
    }
}
