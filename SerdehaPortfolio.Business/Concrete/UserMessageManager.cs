using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Entity.Concrete;
using System.Linq.Expressions;
using SerdehaPortfolio.Data.Abstract;

namespace SerdehaPortfolio.Business.Concrete
{
    public class UserMessageManager:IUserMessageService
    {
        private readonly IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public UserMessage? GetById(int id)
        {
            return _userMessageDal.GetById(x => x.MessageId == id);
        }

        public List<UserMessage>? GetAll(Expression<Func<UserMessage, bool>>? filter = null)
        {
            return filter == null ? _userMessageDal.GetAll() : _userMessageDal.GetAll(filter);
        }

        public Task<IList<UserMessage>>? GetAllAsync(Expression<Func<UserMessage, bool>>? predicate = null, params Expression<Func<UserMessage, object>>[] includeProperties)
        {
            return _userMessageDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<UserMessage> GetAsync(Expression<Func<UserMessage, bool>>? predicate, params Expression<Func<UserMessage, object>>[] includeProperties)
        {
            return _userMessageDal.GetAsync(predicate, includeProperties);
        }

        public UserMessage? GetFirst()
        {
            return _userMessageDal.GetFirst();
        }

        public void Add(UserMessage? entity)
        {
            if(entity != null)
                _userMessageDal.Add(entity);
        }

        public void Update(UserMessage? entity)
        {
            if(entity != null)
                _userMessageDal.Update(entity);
        }

        public void Delete(UserMessage? entity)
        {
            if(entity != null)
                _userMessageDal.Delete(entity);
        }

        public int GetCount(Expression<Func<UserMessage, bool>>? filter = null)
        {
            return filter == null ? _userMessageDal.GetCount() : _userMessageDal.GetCount(filter);
        }

        public Task<UserMessage> Test()
        {
            throw new NotImplementedException();
        }
    }
}
