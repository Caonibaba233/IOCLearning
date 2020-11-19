using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo1_0
{

    /// <summary>
    /// 简单工厂
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase Sql = DatabaseFactory.CreateDatabase("Sql");
            Sql.Delete();
            Sql.Insert();

            IDatabase MySql = DatabaseFactory.CreateDatabase("Mysql");
            MySql.Delete();
            MySql.Insert();

            IDatabase MongoDB = DatabaseFactory.CreateDatabase("MongoDB");
            MongoDB.Delete();
            MongoDB.Insert();

            Console.ReadKey();
        }
    }


    #region factory 1.0
    public interface IDatabase
    {
        void Insert();
        void Delete();
    }

    public class Mysql : IDatabase
    {
        public void Delete()
        {
            Console.WriteLine("Mysql Delete!");
        }

        public void Insert()
        {
            Console.WriteLine("Mysql Insert!");
        }
    }

    public class Sql : IDatabase
    {
        public void Delete()
        {
            Console.WriteLine("Sql Delete!");
        }

        public void Insert()
        {
            Console.WriteLine("Sql Insert!");
        }
    }

    public class MongoDB : IDatabase
    {
        public void Delete()
        {
            Console.WriteLine("MongoDB  Delete!");
        }

        public void Insert()
        {
            Console.WriteLine("MongoDB  Insert!");
        }
    }


    public static class DatabaseFactory
    {
        public static IDatabase CreateDatabase(string dbName)
        {
            IDatabase database = null;
            switch (dbName)
            {
                case "Mysql":
                    database = new Mysql();
                    break;
                case "Sql":
                    database = new Sql();
                    break;
                case "MongoDB":
                    database = new MongoDB();
                    break;
                default:
                    break;
            }

            return database;
        }
    }


    #endregion




}
