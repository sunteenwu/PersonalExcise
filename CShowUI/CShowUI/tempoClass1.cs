using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCatholicPrayer.Model
{
    public class TablePrayer
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string PrayerTitle { get; set; }
        public string PrayerContent { get; set; }
        public string PrayerCurrContent { get; set; }
        public TablePrayer()
        {
            //empty constructor
        }

        public TablePrayer(string title, string content)
        {
            PrayerTitle = title;
            PrayerContent = content;
            this.PrayerCurrContent = true;


        }
    }

}