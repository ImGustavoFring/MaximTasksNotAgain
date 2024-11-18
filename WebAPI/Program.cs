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

            builder.Services.AddSingleton<IStringProcessorService, EnhancedStringProcessorService>();
            builder.Services.AddSingleton<ICharacterCounterService, CharacterCounterService>();
            builder.Services.AddSingleton<ILongestVowelSubstringService, LongestVowelSubstringService>();
            builder.Services.AddSingleton<IStringSorter, QuickSortStringSorter>();
            builder.Services.AddSingleton<IStringSorter, TreeSortStringSorter>();

            builder.Services.AddHttpClient<IRandomNumberService, RandomNumberService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

            app.Run();
        }
    }
}
