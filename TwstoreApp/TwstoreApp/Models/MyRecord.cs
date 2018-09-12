using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFSQLite
{
    public class MyRecord
    {
        public MyRecord()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int fromID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string notes { get; set; }
    }
}