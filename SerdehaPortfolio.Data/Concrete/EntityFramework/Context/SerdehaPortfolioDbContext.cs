using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SerdehaPortfolio.Data.Concrete.EntityFramework.Configurations;
using SerdehaPortfolio.Entity.Concrete;

namespace SerdehaPortfolio.Data.Concrete.EntityFramework.Context
{
    public class SerdehaPortfolioDbContext:IdentityDbContext<AuthorUser,AuthorRole,int>
    {
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Experience>? Experiences { get; set; }
        public DbSet<Feature>? Features { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Portfolio>? Portfolios { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Skill>? Skills { get; set; }
        public DbSet<SocialMedia>? SocialMedias { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserMessage>? UserMessages { get; set; }
        public DbSet<ToDoList>? ToDoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TestimonialConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserMessageConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoListConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=SerdehaPortfolioDB;integrated security=true");
        }
    }
}
