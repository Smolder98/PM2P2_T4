using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2P2_T4.Model
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }

    }
}
