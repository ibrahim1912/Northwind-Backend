using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>  //hep true döndürcek defuolt deger yani
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            //ister data ver ister mesaj ver
        }
        public SuccessDataResult(T data):base(data,true)
        {
            //istersen sadece data ver
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            //istersen sadece mesaj ver
        }
        public SuccessDataResult():base(default,true)
        {
            //istersen hiç bir sey verme
        }
    }
}
