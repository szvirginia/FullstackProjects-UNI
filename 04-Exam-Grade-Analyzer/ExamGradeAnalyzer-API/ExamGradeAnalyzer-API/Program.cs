
using ExamGradeAnalyzer_API.Data;

namespace ExamGradeAnalyzer_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors();
            builder.Services.AddDbContext<GradeAnalyzerDbContext>();
            builder.Services.AddTransient<IGradeAnalyzerRepository, GradeAnalyzerRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:5500", "http://127.0.0.1:5500"));

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
