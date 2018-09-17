using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public class NewItem
    {
        [Range(0, 99, ErrorMessage = "must be 0-99")]
        public int Level { get; set; }

        [Required]
        public String ItemType { get; set; }

       

        public Guid OwningPlayer { get;  set; }
    }
}
