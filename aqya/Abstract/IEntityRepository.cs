using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> //bana çalışacağım tipi söyle
    {
        //(p=>prop.categoryId=2) bunu gibi filteleme yapmak için expression yazdık
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //filtre vermesende olur
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        

    }
}


/* IProducDal yada ICategoryDal bunlar Entites concerete kalsorunden gelir
 * ordaki nesneler yani Product için IProductDal içinde
 * yukarıdaki kodun aynusı yazılır 
 * T yerine product olur category olur diğer nesneler için
 * bunları yapcağına tek interface yazılır
 * -----------------------
 List<T> GetAllByCategory(int categoryId); //kategorye göre filtrele listele
üstteki koda ihtiyaç yok artık expression sayesinde
 */