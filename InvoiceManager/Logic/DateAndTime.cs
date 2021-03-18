using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManager.Logic
{
    public class DateAndTime
    {
        public static DateTime[] GetMonthStartEnd(int monthInput)
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            var x = new DateTime();
            if (monthInput != 0)
            {
                x = month.AddMonths(monthInput);
            }
            else
            {
                x = month;
            }
            if (monthInput == 0)
            {

            }
            

            return new DateTime[] { first, last };          
        }

        public static DateTime[] GetMonthStartEnd2(int monthInput)
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = new DateTime();
            var last = new DateTime();
            
            if (monthInput == 0)
            {
                first = month;
                last = month.AddMonths(1).AddDays(-1);
            }
            if (monthInput < 0)
            {
                first = month.AddMonths(monthInput);
                last = month.AddDays(-1);
            }
            if (monthInput > 0)
            {
                first = month.AddMonths(monthInput);
                last = month.AddMonths(monthInput + 1).AddDays(-1);
            }

            return new DateTime[] { first, last };
        }
    }
}
