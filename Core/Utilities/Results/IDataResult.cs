using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //IDataResult hem List of product hem işlem hemde messaj döndürcek
    public interface IDataResult<T> :IResult  //IResult dan bool ve message geliyor zaten
    {
        T Data { get; }
    }
}
