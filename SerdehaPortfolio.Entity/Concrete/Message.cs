using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class Message:IEntity
    {
        public int MessageId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
