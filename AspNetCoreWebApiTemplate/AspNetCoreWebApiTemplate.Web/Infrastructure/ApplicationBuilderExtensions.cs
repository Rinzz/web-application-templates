namespace AspNetCoreWebApiTemplate.Web.Infrastructure
{
    using Data;
    using Data.Seeding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

            dbContext.Database.Migrate();
        }

        public static void SeedData(this IApplicationBuilder app)
        {

            using var serviceScope = app.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

            new AppDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
        }
    }
}
