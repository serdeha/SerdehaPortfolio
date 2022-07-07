using Microsoft.Extensions.DependencyInjection;
using SerdehaPortfolio.Business.Abstract;
using SerdehaPortfolio.Business.Concrete;
using SerdehaPortfolio.Data.Abstract;
using SerdehaPortfolio.Data.Concrete.EntityFramework;

namespace SerdehaPortfolio.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFeatureDal, EfFeatureDal>();
            serviceCollection.AddSingleton<IAboutDal, EfAboutDal>();
            serviceCollection.AddSingleton<IServiceDal, EfServiceDal>();
            serviceCollection.AddSingleton<ISkillDal, EfSkillDal>();
            serviceCollection.AddSingleton<IPortfolioDal, EfPortfolioDal>();
            serviceCollection.AddSingleton<IExperienceDal, EfExperienceDal>();
            serviceCollection.AddSingleton<ITestimonialDal, EfTestimonialDal>();
            serviceCollection.AddSingleton<IContactDal, EfContactDal>();
            serviceCollection.AddSingleton<IMessageDal, EfMessageDal>();
            serviceCollection.AddSingleton<IUserMessageDal, EfUserMessageDal>();
            serviceCollection.AddSingleton<IToDoListDal, EfToDoListDal>();

            serviceCollection.AddSingleton<IAboutService, AboutManager>();
            serviceCollection.AddSingleton<IFeatureService, FeatureManager>();
            serviceCollection.AddSingleton<IServiceService, ServiceManager>();
            serviceCollection.AddSingleton<ISkillService, SkillManager>();
            serviceCollection.AddSingleton<IPortfolioService, PortfolioManager>();
            serviceCollection.AddSingleton<IExperienceService, ExperienceManager>();
            serviceCollection.AddSingleton<ITestimonialService, TestimonialManager>();
            serviceCollection.AddSingleton<IContactService, ContactManager>();
            serviceCollection.AddSingleton<IMessageService, MessageManager>();
            serviceCollection.AddSingleton<IUserMessageService, UserMessageManager>();
            serviceCollection.AddSingleton<IToDoListService, ToDoListManager>();
        }
    }
}
