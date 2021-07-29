using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;  //bu nuget ten install yapmıştık
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: DB tabloları ile classları bağlamak
    public class NorthwindContext:DbContext //context olduğunu belirtik
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True");
        }

        public DbSet<Product> Products { get; set; }
        //database e ustte bağlandık
        //bu propertyde ise DbSet ile hangi nesne hangi nesneye karşılık gelcek onu yapıyoruz
        //Product kendi classımız //Products Northwind den geliyor
        //DbSet ile nesneleri bağladık
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}
