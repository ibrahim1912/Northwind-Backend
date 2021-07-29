using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //çıplak class kalmasın
    public class Category:IEntity   //VB tablo isimleri
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
