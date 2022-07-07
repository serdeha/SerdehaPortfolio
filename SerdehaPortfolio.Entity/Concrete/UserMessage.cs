using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class UserMessage:IEntity
    {
        public int MessageId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
