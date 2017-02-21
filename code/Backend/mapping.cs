using System.Collections.Generic;
using System.Collections;
using LiteDB;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using bVue;
using Newtonsoft.Json.Serialization;
using bVue.code.Backend.repo;



//using System.Dynamic;
//using bVue.code;


namespace bVue
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }

    public static class mapping
    {
        static string dbpath = @"Data\data.db";
        public static void RunDMC()
        {
            // Open database (or create if not exits)
            var repo = new LiteRepo(dbpath);
        
            using (var db = new LiteDatabase(dbpath))
            {
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "Tester JohnyRambo",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                //customers.Insert(customer);
              //  repo.Insert<Customer>(customer);
                // Update a document inside a collection
                customer.Name = "Joana Doe";

               // customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);
                
                // Use Linq to query documents
                var results = customers.Find(x => x.Name.StartsWith("Jo"));
            }
        }
    //  public static IEnumerable<T> ToList<T>(this IEnumerable<T> source)
    //     {
    //        List<T> res = new List<T>();
    //           foreach (var item in source)
    //            res.Add(item);
    //            return res;
    //     }
//   public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
//         {
//             if (action == null)
//                 throw new ArgumentNullException("action");

//             foreach (var item in source)
//                 action(item);

//             return source;
//         }
        public static List<Customer> getCustomerInfo()
        {
            using (var db = new LiteDatabase(dbpath))
            {
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers"); 
                return customers.FindAll().ToList();
            }

        }
    }
}
