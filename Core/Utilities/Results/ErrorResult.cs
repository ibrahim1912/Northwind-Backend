using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)  //base dediği interiti; Resulta bunları döndür  //false default dönüyor çunku error class burası
        {

        }

        public ErrorResult() : base(false)  //burası da isterse mesaj olmaz kısmı
        {

        }
    }
}

