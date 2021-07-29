using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //burda EntityFramework e bağımlı değiliz
    public class ProductManager : IProductService
    {
        IProductDal _productDal;  //businessın bildiği tek şey burası
        //ILogger _logger;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService /*ILogger logger*/) //injection //ProductManager new lendiği zaman burası çalışır ve bana bir tanae IProductDal referansı ver şuan InMemoryde olabilir yrn baska bir şey gelir örnek EntityFramework
        {
            _productDal = productDal;
            //_logger = logger;
            _categoryService = categoryService;
        }

        //[SecuredOperation("product.add,admin")]  //aspect  //yetkisi var mı

        [ValidationAspect(typeof(ProductValidator))]

        [CacheRemoveAspect("IProductService.Get")]  //bellekte içerinde get olan tüm keyleri iptal et
        //bunun eklendiği metot başarılı çalışınca verilen koşula uygun olarak(tüm getler fıom ıpservice) cachleri siler
        // önceden getbyidyi çalıştırdık cachede var add çalışınca cache silindi ve getbyid metotu cachede yok
        public IResult Add(Product product)   //IResult olayı da iki değer döndürmek 
        {
            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid); // böyleydi eski hali return new ErrorResult("yanlış oldu falan filan");
            //}
            //iş kodları

           /*eger static kullanmasaydık böyle yazacaktık
            ValidationTool validationTool = new ValidationTool();
            validationTool.Validate(new ProductValidator(), product);*/

            //bundan kurtulduk ValidationTool.Validate(new ProductValidator(),product);
            //yerine bunu üste ekledik [ValidationAspect(typeof(ProductValidator))]

            //_logger.Log();

            //bu sistemden de kurtulduk yerine BusinessRules geldi
            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success) 
            //{
            //    if (CheckIfProductNameExist(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);  //buraya geldiyse kod başarılı ekleyebilir

            //        return new SuccessResult(Messages.ProductAdded);  //burda da iki değer döndürüyoruz true ve mesaj istersek mesajsız da olur
            //    }

            //}
            //business code
            //bir kategory de en fazla 10 ürün olablir
            //soru şu Eger mevcut kategory sayısı 15 i geçerse sisteme yeni ürün ekleme

            IResult result = BusinessRules.Run(
                CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitExceed());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheAspect]
        //[SecuredOperation("product.list,admin")]
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları yazılır//ifler var burda
            //burda simüle edilmiş gbi düşün
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategoryId(int id)  //filtrelenmiş ürün listesi yapcaz
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)  //ucuzdan pahalı yada tersi filtreleme yapmak// eticarette örneğin
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;  //select count(*) from products where categorId=? sorgusu calıştırır
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceed()  //soru şu Eger mevcut kategory sayısı 15 i geçerse sisteme yeni ürün ekleme
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 20)
            {
                return new ErrorResult(Messages.CategoryLimitExceed);
            }
            return new SuccessResult();
        }

        [CacheRemoveAspect("IProductService.Get")]  //bellekte içerinde get olan tüm keyleri iptal et
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 20)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            //throw new NotImplementedException();
            return new SuccessResult();
        }
    }
}
