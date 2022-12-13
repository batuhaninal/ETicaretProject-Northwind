// See https://aka.ms/new-console-template for more information
using ETicaret.Business.Concrete;
using ETicaret.DataAccess.Concrete.EntityFramework.Repositories;

ProductManager p = new ProductManager(new EfProductRepository());

foreach (var item in p.GetProductDetails())
{
    Console.WriteLine(item.ProductName+" = "+item.CategoryName);
}
