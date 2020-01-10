using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Entities;
using Windows.Storage;

namespace UWP.Services
{
    public class DatabaseService
    {
        private SQLiteConnection sqliteConnection;

        public SQLiteConnection SqliteConnection
        {
            get { return sqliteConnection; }
        }

        public TableQuery<Computer> Computers
        {
            get { return this.sqliteConnection.Table<Computer>(); }
        }

        public TableQuery<Phone> Phones
        {
            get { return this.sqliteConnection.Table<Phone>(); }
        }

        public TableQuery<Tablet> Tablets
        {
            get { return this.sqliteConnection.Table<Tablet>(); }
        }

        public List<Computer> ComputersEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Computer>(); }
        }

        public int Save(object item)
        {
            return this.sqliteConnection.InsertOrReplace(item);
        }

        public void SaveWithChildren(Computer item)
        {
            this.Save(item.Order);
            this.sqliteConnection.InsertOrReplaceWithChildren(item);
        }

        public DatabaseService()
        {
            Task.Factory.StartNew(async () =>
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile myDb = await localFolder.CreateFileAsync("mydb.sqlite",
                        CreationCollisionOption.OpenIfExists);
                this.sqliteConnection = new SQLiteConnection(myDb.Path);
                this.sqliteConnection.CreateTable<Computer>();
            });
        }
    }
}
