namespace Shared.Extensions;

public static class DateTimeExtensions
{
    public static string ToReadableDate(this DateTime date) =>
        date.ToString("dd MMM yyyy");

    public static string ToReadableDateTime(this DateTime date) =>
        date.ToString("dd MMM yyyy, hh:mm tt");

    public static bool IsWeekend(this DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

    public static int Age(this DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}
