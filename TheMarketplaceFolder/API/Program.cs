namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                    });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<ITodoRepository, TodoRepositoryInMemory>();
            //builder.Services.AddSingleton<ITodoRepositoryInMemory, TodoRepositoryInMemory>();
            //builder.Services.AddSingleton<ITodoRepositoryMongoDB, TodoRepositoryMongoDB>();

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("policy");

            app.MapControllers();

            app.Run();
        }
    }
}