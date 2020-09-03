using Example.Application.Common;
using Example.Application.Example.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Application.Example.Models.Response
{
    public class ExampleGetAllResponse: BaseResponse
    {
        public ExampleGetAllResponse()
        {
            Itens = new List<ExampleDto>();
        }

        public List<ExampleDto> Itens{ get; set; }
    }
}
