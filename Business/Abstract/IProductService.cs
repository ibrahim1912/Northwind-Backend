using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product);   //eski hali void idi
        IResult Update(Product product);   //eski hali void idi
        IDataResult<Product> GetById(int productId);
        //hoca eklicek mi bakalım void Add(Product product);//ekledi
        //IResult AddTransactionalTest(Product product);
        

    } 
    
    //sistemi kurunca bir şeye dokunmadan bunları ekleyip managerda dolduruyoruz

}
