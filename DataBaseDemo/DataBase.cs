using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataBaseDemo
{
    public class DataBase
    {

        public DataBase()
        {
            entries = new List<Entry>();
        }
        public List<Entry> entries { get; set; }

    }
}
