using System;
using System.Collections.Generic;
using System.Text;


public class DateModifier
{
    public double dayDifferenceTwoDates(DateTime startDate, DateTime endDate)
    {
        return Math.Abs((endDate - startDate).TotalDays);
    }
}

