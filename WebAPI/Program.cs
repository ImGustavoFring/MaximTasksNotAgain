using Logic.Services;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IStringProcessorService, EnhancedStringProcessorService>();
            builder.Services.AddScoped<ICharacterCounterService, CharacterCounterService>();
            builder.Services.AddScoped<ILongestVowelSubstringService, LongestVowelSubstringService>();
            builder.Services.AddScoped<IStringSorter, QuickSortStringSorter>();
            builder.Services.AddScoped<IStringSorter, TreeSortStringSorter>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

            app.Run();
        }
    }
}
