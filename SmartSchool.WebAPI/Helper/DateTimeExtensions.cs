using System;

namespace SmartSchool.WebAPI.Helper
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currenDate = DateTime.UtcNow;
            int age = currenDate.Year - dateTime.Year;

            if (currenDate < dateTime.AddYears(age))
                return age--;

            return age;
        }
    }
}