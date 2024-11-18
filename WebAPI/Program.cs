using Logic.Services;
using WebAPI.Middlewares;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Считываем конфигурацию
            var settingsConfig = builder.Configuration.GetSection("Settings").Get<SettingsConfig>();
            var randomApi = builder.Configuration["RandomApi"];

            // Добавляем конфигурацию в контейнер DI
            builder.Services.AddSingleton(settingsConfig);

            // Считываем лимит параллельных запросов и регистрируем как объект
            var parallelLimit = builder.Configuration.GetValue<int>("Settings:ParallelLimit");
            builder.Services.AddSingleton(new ParallelLimitConfig { ParallelLimit = parallelLimit });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICharacterCounterService, CharacterCounterService>();
            builder.Services.AddSingleton<ILongestVowelSubstringService, LongestVowelSubstringService>();
            builder.Services.AddSingleton<IStringSorter, QuickSortStringSorter>();
            builder.Services.AddSingleton<IStringSorter, TreeSortStringSorter>();

            builder.Services.AddSingleton<IStringProcessorService>(provider =>
            {
                var blackList = settingsConfig.BlackList;
                return new EnhancedStringProcessorService(blackList);
            });

            builder.Services.AddHttpClient<IRandomNumberService, RandomNumberService>((client) =>
            {
                var apiString = randomApi;
                return new RandomNumberService(client, apiString);
            });

            var app = builder.Build();

            // Регистрируем middleware и передаем объект с лимитом через DI
            app.UseMiddleware<RequestLimitMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

            app.Run();
        }
    }
}
