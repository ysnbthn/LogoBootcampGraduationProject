using System;
using System.Diagnostics;

namespace BootcampProject.Web.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToJsString(this DateTime dateTime)
        {
            string formattedDate = dateTime.ToString("yyyy.MM.dd").Split(' ')[0].Replace(".", "-");
            Debug.WriteLine(formattedDate);

            return formattedDate;
        }
    }
}
