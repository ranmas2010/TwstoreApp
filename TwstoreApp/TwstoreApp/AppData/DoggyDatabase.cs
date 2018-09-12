using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFSQLite
{
    public class DoggyDatabase
    {
        static object locker = new object();

        public string DBPath { get; set; }

        SQLiteConnection database;

        public DoggyDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            DBPath = database.DatabasePath;
            // create the tables
            database.CreateTable<MyRecord>();
        }

        public IEnumerable<MyRecord> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<MyRecord>() select i).ToList();
            }
        }

        public IEnumerable<MyRecord> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<MyRecord>("SELECT * FROM [MyRecord] WHERE [Done] = 0");
            }
        }

        public MyRecord GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<MyRecord>().FirstOrDefault(x => x.id == id);
            }
        }

        public MyRecord GetItemFromID(int fromID)
        {
            lock (locker)
            {
                return database.Table<MyRecord>().FirstOrDefault(x => x.fromID == fromID);
            }
        }

        public int SaveItem(MyRecord item)
        {
            lock (locker)
            {
                if (item.id != 0)
                {
                    database.Update(item);
                    return item.id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<MyRecord>(id);
            }
        }

        public void DeleteAll()
        {
            var fooItems = GetItems().ToList();
            foreach (var item in fooItems)
            {
                DeleteItem(item.id);
            }
        }
    }
}