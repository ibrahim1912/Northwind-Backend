using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //ister data ver ister mesaj ver
        }
        public ErrorDataResult(T data) : base(data, false)
        {
            //istersen sadece data ver
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            //istersen sadece mesaj ver
        }
        public ErrorDataResult() : base(default, false)
        {
            //istersen hiç bir sey verme
        }
    }
}
