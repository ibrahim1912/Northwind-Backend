using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryProductGetAllTest();

            //Sadece EntityFramework klasorünü ekledik başka bir seye dokunmadan aşağıdaki kodu çalıştırdık
            //Solid=>  Open Closed Princible

            //EfProdctGetAllTest();

            //EfProductGetAllByCategoryId();

            //EfProductGetByUnitPriceTest();

            //EfCategoryGetAllTest();

            //EfCategoryGetByIdTest();

            // EfProductGetProductDetailsTest();



        }

        private static void EfProductGetProductDetailsTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void EfCategoryGetByIdTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result = categoryManager.GetById(1);
            Console.WriteLine(result.Data.CategoryName);
        }

        //private static void EfCategoryGetAllTest() sonra çöz bunu
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var category in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        //}

        private static void EfProductGetByUnitPriceTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetByUnitPrice(50, 100);
            if (result.Success == true)
            {
                foreach (var product in result.Data)

                {
                    Console.WriteLine(product.ProductName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void EfProductGetAllByCategoryId()
        {
            ProductManager productManager3 = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager3.GetAllByCategoryId(2);
            if (result.Success == true)
            {
                foreach (var product in result.Data)

                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void EfProdctGetAllTest()
        {
            ProductManager productManager2 = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            var result = productManager2.GetAll();
            if (result.Success == true)
            {
                foreach (var product in result.Data)

                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void InMemoryProductGetAllTest()
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetAll();
            if (result.Success == true)
            {
                foreach (var product in result.Data)

                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
