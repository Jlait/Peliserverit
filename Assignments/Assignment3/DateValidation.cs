using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public class DateValidation : ValidationAttribute
    {
    
            public override bool IsValid (object date)
            {

            DateTime _date = (DateTime)date;
            return _date < DateTime.Now;

            }
    }
}
