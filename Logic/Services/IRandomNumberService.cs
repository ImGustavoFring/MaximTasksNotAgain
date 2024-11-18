
namespace Logic.Services
{
    public interface IRandomNumberService
    {
        Task<int> GetRandomNumberAsync(int maxValue);
    }
}