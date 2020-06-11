using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.CrossCutting.Results
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
