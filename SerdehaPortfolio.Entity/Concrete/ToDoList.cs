using SerdehaPortfolio.Entity.Abstract;

namespace SerdehaPortfolio.Entity.Concrete
{
    public class ToDoList:IEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool Status { get; set; }
    }
}
