using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
          


                MongoClient db = new MongoClient("mongodb://localhost:27017");
                var dbList = db.ListDatabases().ToList();

                Console.WriteLine("The list of databases are :");
                foreach (var item in dbList)
                {
                    Console.WriteLine(item);
                }
            
        }
    }
    

//public class mongocrud
//    {
//        private IMongoDatabase db;

//        public mongocrud(string database)
//        {
//            var client = new MongoClient();
//            db = client.GetDatabase(database);
//        }

//    }
}
