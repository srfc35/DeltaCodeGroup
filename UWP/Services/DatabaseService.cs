using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWP.Entities;
using Windows.ApplicationModel.Core;
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

        public TableQuery<TV> TVs
        {
            get { return this.sqliteConnection.Table<TV>(); }
        }

        public List<Computer> ComputersEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Computer>(); }
        }

        public List<Phone> PhonesEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Phone>(); }
        }

        public List<Tablet> TabletsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Tablet>(); }
        }

        public List<TV> TVsEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<TV>(); }
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

        public void SaveWithChildren(Phone item)
        {
            this.Save(item.Order);
            this.sqliteConnection.InsertOrReplaceWithChildren(item);
        }

        public void SaveWithChildren(Tablet item)
        {
            this.Save(item.Order);
            this.sqliteConnection.InsertOrReplaceWithChildren(item);
        }

        public void SaveWithChildren(TV item)
        {
            this.Save(item.Order);
            this.sqliteConnection.InsertOrReplaceWithChildren(item);
        }

        public DatabaseService()
        {
            AutoResetEvent eRF = new AutoResetEvent(false);
            // AutoResetEvent eR1 = new AutoResetEvent(false);
            Task.Factory.StartNew(async () =>
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile myDb = await localFolder.CreateFileAsync("mydb.sqlite",
                        CreationCollisionOption.OpenIfExists);
                this.sqliteConnection = new SQLiteConnection(myDb.Path);
                while (this.sqliteConnection == null)
                {

                }
            }).ContinueWith((s) =>
            {
                this.sqliteConnection.CreateTable<Client>();
                this.sqliteConnection.CreateTable<Seller>();
                this.sqliteConnection.CreateTable<Command>();
                this.sqliteConnection.CreateTable<Computer>();
                this.sqliteConnection.CreateTable<Phone>();
                this.sqliteConnection.CreateTable<Tablet>();
                this.sqliteConnection.CreateTable<TV>();
                eRF.Set();
            });
            eRF.WaitOne();
            //            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
            //Windows.UI.Core.CoreDispatcherPriority.Normal,
            //() =>
            //{


            //});
        }
    }
}
