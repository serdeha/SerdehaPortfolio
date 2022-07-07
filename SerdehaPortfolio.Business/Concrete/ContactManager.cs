using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class ContactManager:IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact? GetById(int id)
        {
            return _contactDal.GetById(x=> x.ContactId == id);
        }

        public List<Contact>? GetAll(Expression<Func<Contact, bool>>? filter = null)
        {
            return filter == null ? _contactDal.GetAll() : _contactDal.GetAll(filter);
        }

        public Task<IList<Contact>>? GetAllAsync(Expression<Func<Contact, bool>>? predicate = null, params Expression<Func<Contact, object>>[] includeProperties)
        {
            return _contactDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Contact> GetAsync(Expression<Func<Contact, bool>>? predicate, params Expression<Func<Contact, object>>[] includeProperties)
        {
            return _contactDal.GetAsync(predicate, includeProperties);
        }

        public Contact? GetFirst()
        {
            return _contactDal.GetFirst();
        }

        public void Add(Contact? entity)
        {
            if (entity != null)
                _contactDal.Add(entity);
        }

        public void Update(Contact? entity)
        {
            if (entity != null)
                _contactDal.Update(entity);
        }

        public void Delete(Contact? entity)
        {
            if (entity != null)
                _contactDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Contact, bool>>? filter = null)
        {
            return filter == null ? _contactDal.GetCount() : _contactDal.GetCount(filter);
        }
    }
}
