using System.Linq.Expressions;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Business.Concrete
{
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public Testimonial? GetById(int id)
        {
            return _testimonialDal.GetById(x=>x.TestimonialId == id);
        }

        public List<Testimonial>? GetAll(Expression<Func<Testimonial, bool>>? filter = null)
        {
            return filter == null ? _testimonialDal.GetAll() : _testimonialDal.GetAll(filter);
        }

        public Task<IList<Testimonial>>? GetAllAsync(Expression<Func<Testimonial, bool>>? predicate = null, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return _testimonialDal.GetAllAsync(predicate, includeProperties);
        }

        public Task<Testimonial> GetAsync(Expression<Func<Testimonial, bool>>? predicate, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return _testimonialDal.GetAsync(predicate, includeProperties);  
        }

        public Testimonial? GetFirst()
        {
            return _testimonialDal.GetFirst();
        }

        public void Add(Testimonial? entity)
        {
            if(entity != null)
                _testimonialDal.Add(entity);
        }

        public void Update(Testimonial? entity)
        {
            if(entity != null)
                _testimonialDal.Update(entity);
        }

        public void Delete(Testimonial? entity)
        {
            if(entity != null)
                _testimonialDal.Delete(entity);
        }

        public int GetCount(Expression<Func<Testimonial, bool>>? filter = null)
        {
            return filter == null ? _testimonialDal.GetCount() : _testimonialDal.GetCount(filter);
        }
    }
}
