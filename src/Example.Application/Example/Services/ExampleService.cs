using System.Threading.Tasks;
using Example.Application.Common;
using Example.Application.Example.Models.Request;
using Example.Application.Example.Models.Response;
using Example.Application.Example.Repository;
using Example.Domain.ExampleAggregate;
using Example.Domain.SeedWork;
using System.Linq;
using AutoMapper;
using Example.Application.Example.Models.Dtos;
using Example.Domain.SeedWork.Exceptions;

namespace Example.Application.Example.Services
{
    public class ExampleService : BaseService, IExampleService
    {
        private readonly IExampleRepository _exampleRepository;

        private readonly INotification _notification;

        public ExampleService(IExampleRepository exampleRepository, INotification notification) : base(notification)
        {
            _exampleRepository = exampleRepository;
            _notification = notification;
        }

        public async Task<ExampleCreateResponse> CreateAsync(ExampleCreateRequest request) => await ExecuteAsync(async () =>
        {
            var response = new ExampleCreateResponse();
            var obj = ExampleDomain.Create(request.Age, request.Name);
            obj.Validate(obj, new ExampleValidator());
            if (!obj.Valid)
            {
                _notification.AddNotifications(obj.ValidationResult);
                return response;
            }
            await _exampleRepository.InsertOrUpdateAsync(obj).ConfigureAwait(false);
            return response;
        });

        public async Task<ExampleGetAllResponse> GetAllAsync() => await ExecuteAsync(async () =>
        {
            var response = new ExampleGetAllResponse();
            var banco = await _exampleRepository.GetAllAsync().ConfigureAwait(false);
            response.Itens.AddRange(banco.Select(x => (ExampleDto)x).ToList());
            return response;
        });

        public async Task<ExampleGetOneResponse> GetOneAsync(int id) => await ExecuteAsync(async () =>
        {
            var response = new ExampleGetOneResponse();
            var banco = await _exampleRepository.GetByIdAsync(id, false).ConfigureAwait(false);
            if (banco != null)
                response.Example = (ExampleDto)banco;
            return response;
        });

        public async Task<ExampleUpdateResponse> UpdateAsync(int id, ExampleUpdateRequest request) => await ExecuteAsync(async () =>
        {
            var response = new ExampleUpdateResponse();
            var example = await _exampleRepository.GetByIdAsync(id, false).ConfigureAwait(false);
            if (example != null)
            {
                //Changing property
                example.Update(request.Age, request.Name);

                //Validate
                example.Validate(example, new ExampleValidator());
                if (!example.Valid)
                {
                    _notification.AddNotifications(example.ValidationResult);
                    return response;
                }

                await _exampleRepository.UpdateAsync(example).ConfigureAwait(false);
            }
            else
                throw new NotFoundException();
            return response;
        });
    }
}
