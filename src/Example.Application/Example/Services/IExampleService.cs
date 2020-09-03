using Example.Application.Example.Models.Request;
using Example.Application.Example.Models.Response;
using System.Threading.Tasks;

namespace Example.Application.Example.Services
{
    public interface IExampleService
    {
        Task<ExampleCreateResponse> CreateAsync(ExampleCreateRequest request);
        Task<ExampleGetAllResponse> GetAllAsync();
        Task<ExampleGetOneResponse> GetOneAsync(int id);
        Task<ExampleUpdateResponse> UpdateAsync(int id, ExampleUpdateRequest request);
    }
}
