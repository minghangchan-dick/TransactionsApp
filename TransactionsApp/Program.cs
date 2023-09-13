using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransactionsApp.Data;
using TransactionsApp.Interface;
using TransactionsApp.Services;

namespace TransactionsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TransactionContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("TransactionsAppContext") ?? throw new InvalidOperationException("Connection string 'TransactionsAppContext' not found."),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TransactionsAppContext"))));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IEventService, EventService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}