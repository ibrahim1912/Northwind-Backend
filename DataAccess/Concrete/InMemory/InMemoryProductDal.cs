using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Teknolojinin ismi(şu an bellek)-Ürünle ilgili-VeriErişim kodlarının yazılacağı class
    public class InMemoryProductDal : IProductDal
    //burda yazcağım kodlar farklıdır entitiy frameworkte farklıdır
    //o yuzden IProductDal ı implemet ederizki herkez içini kendine göre doldursun
    //bellekte veri yönetimi yapıyoruz:simüle
    {
        //global değişken altçizgili olur
        List<Product> _products; //bu listeyi VB gibi düşün
        public InMemoryProductDal() //bellekte referans alınca çalışacak blok
        {
            //alttakileri fake yaptık normalde;
            //burası oracle,sql,mongo,postgres herhangi birinden geliyormuş gibi düşüncez
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1, ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1, ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2, ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2, ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2, ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);  //listeye eklencek
        }

        public void Delete(Product product)
        {
            /*_products.Remove(product);//boyle asla silinemez
             referans tip oldukları için farklı olcak ondan silinmez
             */

            //linq kullanmasaydık
            //listeyi dolaşır ve şart koyardık
            /* Product productToDelete = null;
             foreach (var p in _products)
             {
                 if (product.ProductId == p.ProductId)
                 {
                     productToDelete = p;
                 }
             }*/
            //linq kullanımı
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);  //bu kod foreach yapıo p takma ad //tek bir sonuç cıkcak


            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() //VB veriyi Business a veren yer
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //where komutu içindeki şarta uygun bulan elemanları yaeni bir liste haline getirir ve döndürür
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahp olan listedeki ürün id sini bul yani ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
