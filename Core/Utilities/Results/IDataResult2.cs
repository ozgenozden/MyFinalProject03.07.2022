using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult2 : IResult
    {
         Object Data { get; }
    }
}
