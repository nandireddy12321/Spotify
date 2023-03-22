

namespace audio
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
        }





        // Configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();


                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("audio/swagger/v1/swagger.json", "audio  v1");
                });
            }



            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

        }
    }
}


