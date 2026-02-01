using System.Threading.Tasks;

namespace Core.Domain.Contracts
{
    public interface IDataSeeding
    {
        Task SeedDataAsync();
    }
}
