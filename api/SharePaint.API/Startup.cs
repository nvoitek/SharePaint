using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SharePaint.API.Auth;
using SharePaint.API.Db;
using SharePaint.Repository;
using SharePaint.Repository.Interfaces;
using SharePaint.Services;
using SharePaint.Services.Interfaces;

namespace SharePaint.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<DatabaseConnectionSettings>(
                Configuration.GetSection(nameof(DatabaseConnectionSettings)));

            services.AddSingleton<IDatabaseConnectionSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseConnectionSettings>>().Value);

            services.Configure<AuthorizationSettings>(
                Configuration.GetSection(nameof(AuthorizationSettings)));

            services.AddSingleton<IAuthorizationSettings>(sp =>
                sp.GetRequiredService<IOptions<AuthorizationSettings>>().Value);

            services.AddSingleton<IMongoDbShapeContext, MongoDbShapeContext>();
            services.AddSingleton<IShapeRepository, ShapeRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IShapeUnderPointService, ShapeUnderPointService>();
            services.AddSingleton<IShapeInsideAreaService, ShapeInsideAreaService>();
            services.AddSingleton<IShapeService, ShapeService>();
            services.AddSingleton<IUserService, UserService>();

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
