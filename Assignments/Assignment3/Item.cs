using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Item
    {
        [Range(0,99, ErrorMessage = "must be 0-99")]
        public int Level { get; set; }

        [Required]
        public String ItemType { get; set; }

        [Required]
        public Guid ItemID { get; set; }

        public Guid OwningPlayer { get; set; }

        [DateValidation]
        public DateTime CreationDate { get; set; }

    }
}
