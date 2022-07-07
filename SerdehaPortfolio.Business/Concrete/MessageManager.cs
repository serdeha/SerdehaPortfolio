using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class MessageManager:IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message? GetById(int id)
        {
            return _messageDal.GetById(x => x.MessageId == id);
        }

        public List<Message>? GetAll(Expression<Func<Message, bool>>? filter = null)
        {
            return filter == null ? _messageDal.GetAll() :_messageDal.GetAll(filter);
        }

        public Task<IList<Message>>? GetAllAsync(Expression<Func<Message, bool>>? predicate = null, params Expression<Func<Message, object>>[] includeProperties)
        {
            return _messageDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Message> GetAsync(Expression<Func<Message, bool>>? predicate, params Expression<Func<Message, object>>[] includeProperties)
        {
            return _messageDal.GetAsync(predicate, includeProperties);
        }

        public Message? GetFirst()
        {
            return _messageDal.GetFirst();
        }

        public void Add(Message? entity)
        {
            if (entity != null)
                _messageDal.Add(entity);
        }

        public void Update(Message? entity)
        {
            if (entity != null)
                _messageDal.Update(entity);
        }

        public void Delete(Message? entity)
        {
            if (entity != null)
                _messageDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Message, bool>>? filter = null)
        {
            return filter == null ? _messageDal.GetCount() : _messageDal.GetCount(filter);
        }
    }
}
