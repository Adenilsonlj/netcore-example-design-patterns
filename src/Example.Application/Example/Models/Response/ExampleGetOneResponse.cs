using Example.Application.Common;
using Example.Application.Example.Models.Dtos;

namespace Example.Application.Example.Models.Response
{
    public class ExampleGetOneResponse: BaseResponse
    {
        public ExampleDto Example { get; set; }
    }
}
