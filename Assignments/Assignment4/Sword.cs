using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Sword : Item
    {
        [Range(3, 99)]
        public int Level { get; set; }
    }
}
