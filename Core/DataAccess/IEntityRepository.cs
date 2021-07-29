
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()  //bana çalışacağım tipi söyle //bu tipin class olması ve IEntity içermesi gerekir//new() yapınca IEntity yapılamaz ama implemet ettiği nesneler olur
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