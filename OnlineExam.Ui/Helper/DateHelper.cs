using System.Globalization;

namespace OnlineExam.Ui.Helper
{
    public class DateHelper
    {

        public static string MiladiToShamsi(DateTime dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime).ToString("0000") + "/" + pc.GetMonth(dateTime).ToString("00")
                + "/" + pc.GetDayOfMonth(dateTime).ToString("00") + " " + pc.GetHour(dateTime).ToString("00") + ":" + pc.GetMinute(dateTime).ToString("00");
        }
        public static string MiladiToShamsi(string dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            PersianCalendar pc = new PersianCalendar();
            var DateType = DateTime.Parse(dateTime);
            return pc.GetYear(DateType).ToString("0000") + "/" + pc.GetMonth(DateType).ToString("00") + "/" + pc.GetDayOfMonth(DateType).ToString("00");

        }
        public static string GetShamsiYear(DateTime DateTime)
        {
            PersianCalendar ps = new PersianCalendar();

            return ps.GetYear(DateTime).ToString();
        }
        public static string GetShamsiMonth(DateTime dateTime)
        {
            PersianCalendar ps = new PersianCalendar();
            return ps.GetMonth(dateTime).ToString();
        }

        public static string GetShamsiMonthName(int Month)
        {

            switch (Month)
            {
                case 1:
                    {
                        return "فروردین";

                    }
                case 2:
                    {
                        return "اردیبهشت";
                    }
                case 3:
                    {
                        return "خرداد";
                    }
                case 4:
                    {
                        return "تیر";
                    }
                case 5:
                    {
                        return "مرداد";

                    }
                case 6:
                    {
                        return "شهریور";
                    }
                case 7:
                    {
                        return "مهر";
                    }
                case 8:
                    {
                        return "آبان";

                    }
                case 9:
                    {
                        return "آذر";
                    }
                case 10:
                    {
                        return "دی";
                    }
                case 11:
                    {
                        return "بهمن";
                    }
                case 12:
                    {
                        return "اسفند";
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }

            }

        }

    }
}
