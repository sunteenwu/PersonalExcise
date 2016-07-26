using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.ApplicationModel.Background;

namespace ClassLib
{

    public class MyDatabase
    {
        string DbFileName = "MyDb.db";
        string DbFilePath;
        public async void savedata(string data)
        {
            for (int i = 0;  i < 600;i++)
            {
                var asyncConnection = GetConnetion();
                //data = string.Format(data, i);
                await asyncConnection.InsertAsync(data);
            }
        }

        public SQLiteAsyncConnection GetConnetion()
        {
            DbFilePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DbFileName);
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(DbFilePath, storeDateTimeAsTicks: false)));
            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
            return asyncConnection;
        }

        public class MyDataTable
        {
            public string Data { get; set; }

            public MyDataTable() { }

            public MyDataTable(string data)
            {
                this.Data = data;
            }
        }
    }
}