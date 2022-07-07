using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class ToDoListManager:IToDoListService
    {
        private readonly IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public ToDoList? GetById(int id)
        {
            return _toDoListDal.GetById(x => x.Id == id);
        }

        public List<ToDoList>? GetAll(Expression<Func<ToDoList, bool>>? filter = null)
        {
            return filter == null ? _toDoListDal.GetAll() : _toDoListDal.GetAll(filter);
        }

        public async Task<IList<ToDoList>>? GetAllAsync(Expression<Func<ToDoList, bool>>? predicate = null, params Expression<Func<ToDoList, object>>[] includeProperties)
        {
            return await _toDoListDal.GetAllAsync(predicate, includeProperties)!;
        }

        public Task<ToDoList> GetAsync(Expression<Func<ToDoList, bool>>? predicate, params Expression<Func<ToDoList, object>>[] includeProperties)
        {
            return _toDoListDal.GetAsync(predicate!, includeProperties)!;
        }

        public ToDoList? GetFirst()
        {
            return _toDoListDal.GetFirst();
        }

        public void Add(ToDoList? entity)
        {
            if (entity != null)
                _toDoListDal.Add(entity);
        }

        public void Update(ToDoList? entity)
        {
            if(entity != null)
                _toDoListDal.Update(entity);
        }

        public void Delete(ToDoList? entity)
        {
            if(entity != null)
                _toDoListDal.Delete(entity);
        }

        public int GetCount(Expression<Func<ToDoList, bool>>? filter = null)
        {
            return filter == null ? _toDoListDal.GetCount() : _toDoListDal.GetCount(filter);
        }
    }
}
