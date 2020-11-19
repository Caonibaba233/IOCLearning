using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo1_2
{
    /// <summary>
    /// 正常工厂模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IDatabaseFactory mySqlDatabaseFactory = new MysqlDBFactory();
            IDatabase mySql =  mySqlDatabaseFactory.CreateDatabase();
            mySql.Delete();
            mySql.Insert();

            IDatabaseFactory sqlDatabaseFactory = new SqlDBFactory();
            IDatabase sql = sqlDatabaseFactory.CreateDatabase();
            sql.Delete();
            sql.Insert();

            IDatabaseFactory mongoDbDatabaseFactory = new MongoDBFactory();
            IDatabase mongoDb = mongoDbDatabaseFactory.CreateDatabase();
            mongoDb.Delete();
            mongoDb.Insert();

            Console.ReadKey();
        }
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

       
        /*
         * 工厂接口
         * 因为工厂中存在switch循环（大量if判断），所以与IDatabase的耦合性依旧很高。
         * 为了降低耦合性，将DatabaseFactory也变成一个接口，
         */
        public interface IDatabaseFactory
        {
            IDatabase CreateDatabase();
        }

        public class MysqlDBFactory : IDatabaseFactory
        {
            public IDatabase CreateDatabase()
            {
                return new Mysql();
            }
        }

        public class SqlDBFactory : IDatabaseFactory
        {
            public IDatabase CreateDatabase()
            {
                return new Sql();
            }
        }

        public class MongoDBFactory : IDatabaseFactory
        {
           
            public IDatabase CreateDatabase()
            {
                return new MongoDB();
            }
        }
    }
}
