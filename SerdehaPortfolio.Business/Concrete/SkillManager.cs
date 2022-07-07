using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class SkillManager:ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public Skill? GetById(int id)
        {
            return _skillDal.GetById(x => x.SkillId == id);
        }

        public List<Skill>? GetAll(Expression<Func<Skill, bool>>? filter = null)
        {
            return filter == null ? _skillDal.GetAll() : _skillDal.GetAll(filter);
        }

        public Task<IList<Skill>>? GetAllAsync(Expression<Func<Skill, bool>>? predicate = null, params Expression<Func<Skill, object>>[] includeProperties)
        {
            return _skillDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Skill> GetAsync(Expression<Func<Skill, bool>>? predicate, params Expression<Func<Skill, object>>[] includeProperties)
        {
            return _skillDal.GetAsync(predicate, includeProperties);
        }

        public Skill? GetFirst()
        {
            return _skillDal.GetFirst();
        }

        public void Add(Skill? entity)
        {
            if(entity != null)
                _skillDal.Add(entity);
        }

        public void Update(Skill? entity)
        {
            if(entity != null)
                _skillDal.Update(entity);
        }

        public void Delete(Skill? entity)
        {
            if (entity != null)
                _skillDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Skill, bool>>? filter = null)
        {
            return filter == null ? _skillDal.GetCount() : _skillDal.GetCount(filter);
        }
    }
}
