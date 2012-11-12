using System;
using Resources;

namespace PersianRelativeDate
{
    public static class PersianDateExtensions
    {
        public static string MakeRelative(this DateTime date)
        {
            var timeSince = DateTime.Now.Subtract(date);
            if (timeSince.TotalMilliseconds < 1) return Messages.NotYet;
            if (timeSince.TotalMinutes < 1) return Messages.JustNow;
            if (timeSince.TotalMinutes < 60) return string.Format(Messages.MinutesAgo, timeSince.Minutes);
            if (timeSince.TotalHours < 24) return string.Format(Messages.HoursAgo, timeSince.Hours);
            if (timeSince.TotalDays < 2) return Messages.Yesterday;
            if (timeSince.TotalDays < 7) return string.Format(Messages.DaysAgo, timeSince.Days);
            if (timeSince.TotalDays < 14) return Messages.LastWeek;
            if (timeSince.TotalDays < 21) return Messages.TwoWeeksAgo;
            if (timeSince.TotalDays < 28) return Messages.ThreeWeeksAgo;
            if (timeSince.TotalDays < 60) return Messages.LastMonth;
            if (timeSince.TotalDays < 365) return string.Format(Messages.MonthsAgo, Math.Round(timeSince.TotalDays / 30));
            return timeSince.TotalDays < 730 ? Messages.LastYear : string.Format(Messages.YearsAgo, Math.Round(timeSince.TotalDays / 365));
        }
    }
}