using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message):base(true,message)  //base dediği interiti; Resulta bunları döndür  //true default dönüyor çunku success class burası
        {

        }

        public SuccessResult():base(true)  //burası da isterse mesaj olmaz kısmı
        {

        }
    }
}
