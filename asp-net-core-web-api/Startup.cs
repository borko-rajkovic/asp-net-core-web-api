using AspNetCoreWebApi.Data;
using AspNetCoreWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreWebApi
{
    public class Startup
    {
        // TODO Controller wit Entity Framework
        // TODO ASP.NET Core with React and Redux
        // TODO Local DB send to github
        // TODO Swagger

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//.AddXmlSerializerFormatters();
            services.AddDbContext<ProductsDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductsDB;"));
            //services.AddApiVersioning(o => o.ApiVersionReader = new MediaTypeApiVersionReader());
            //services.AddScoped<IProduct, ProductRepository>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info(){Title = "Products API", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductsDbContext productsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "API for Products"));
            app.UseMvc();
            productsDbContext.Database.EnsureCreated();
        }
    }
}
