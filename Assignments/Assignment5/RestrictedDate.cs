using System;
using System.ComponentModel.DataAnnotations;

namespace assignment5
{
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid (object date)
        {
            DateTime _date = (DateTime) date;
            return _date < DateTime.Now;
        }
    }
}