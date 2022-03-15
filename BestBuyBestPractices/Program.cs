using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            
            IDbConnection conn = new MySqlConnection(connString);

            DapperDepartmentsRepository repo = new DapperDepartmentsRepository(conn);
            Console.WriteLine("Hello user here are the current departments:");
            var depos = repo.GetAllDepartments();

            foreach(var depo in depos) 
            {
                Console.WriteLine($"ID: {depo.DepartmentID}  Name: {depo.Name}");
            }

            DapperProductRepository prod = new DapperProductRepository(conn);
            Console.WriteLine("Here are the current products:");
            var prods = prod.GetAllProducts();

            foreach(var v in prods) 
            {
                Console.WriteLine($"Product ID: {v.ProductID} Name: {v.Name} Price: {v.Price} Category ID: {v.CategoryID} Sale Status: {v.OnSale} Stock Level {v.StockLevel}");
            }

        }
    }
}
