using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDemo3
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IsuperFactory isuperFactory = new WindowsWithSqlFactory();
            isuperFactory.InstallDB().CreateDatabase().Delete();
            isuperFactory.InstallDB().CreateDatabase().Insert();
            isuperFactory.InstallOS().InstallOS().Shutdown();
            isuperFactory.InstallOS().InstallOS().Start();

            Console.ReadKey();
        }
    }

    /**
     * 数据库接口
     * 
     */
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

    /**
     * 操作系统接口
     */
    public interface IOperatingSystem
    {
        void Shutdown();
        void Start();
    }

    public interface IOperatingSystemFactory
    {
        IOperatingSystem InstallOS();
    }

    public class WinodowsSystem : IOperatingSystem
    {
        public void Shutdown()
        {
            Console.WriteLine("Windows shutdown!");
        }
        public void Start()
        {
            Console.WriteLine("Windows Start!");
        }
    }

    public class LinuxSystem : IOperatingSystem
    {
        public void Shutdown()
        {
            Console.WriteLine("Linux shutdown!");
        }
        public void Start()
        {
            Console.WriteLine("Linux Start!");
        }
    }

    public class WindowsSystemFactory : IOperatingSystemFactory
    {
        public IOperatingSystem InstallOS()
        {
           return new WinodowsSystem();
        }
    }

    public class LinuxSystemFactory : IOperatingSystemFactory
    {
        public IOperatingSystem InstallOS()
        {
            return new LinuxSystem();
        }
    }


    /**
     * 超级工厂接口
     */
    public interface IsuperFactory
    {
        IDatabaseFactory InstallDB();
        IOperatingSystemFactory InstallOS();
    }

    public class WindowsWithSqlFactory : IsuperFactory
    {
        public IDatabaseFactory InstallDB()
        {
            return new SqlDBFactory();
        }

        public IOperatingSystemFactory InstallOS()
        {
            return new WindowsSystemFactory();
        }
    }

}
