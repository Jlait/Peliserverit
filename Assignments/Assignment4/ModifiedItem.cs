using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    public class ModifiedItem
    {
        public Player player { get; set; }
        public String ItemType { get; set; }
        public int Level { get; internal set; }
        public object Type { get; internal set; }
    }
}
