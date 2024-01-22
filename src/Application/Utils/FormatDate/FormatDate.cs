using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Application.Utils.FormatDate;
public class FormatDate
{
    public const string STR_FORMAT_DATE_DATA = "yyyy-MM-dd";
    public const string STR_FORMAT_DATE_UI = "dd/MM/yyyy";
    public const string STR_FORMAT_WEEK = "dd/MM";
    public const string STR_FORMAT_MONTH = "MM/yyyy";
    public const string STR_FORMAT_DATE_TIME = "HH:mm:ss - dd-MM-yyyy";

    public static string CalTimeBetweenTwoDate(DateTime dateTime)
    {
        DateTime Today = DateTime.Now;
        TimeSpan timeSpan = Today - dateTime;
        string type = "";
        int timeCurrent = 0;
        if (timeSpan.TotalMinutes < 1)
        {
            timeCurrent = timeSpan.Seconds;
            type = "giây";
        }            
        else if (timeSpan.TotalHours < 1)
        {
            timeCurrent = timeSpan.Minutes;
            type = "phút";
        }
            
        else if (timeSpan.TotalDays < 1)
        {
            timeCurrent = timeSpan.Hours;
            type = "giờ";
        }
            
        else if ((Today.Month- dateTime.Month) < 1 && (Today.Year - dateTime.Year) < 1)
        {
            timeCurrent = timeSpan.Days;
            type = "ngày";
        }
            
        else if ((Today.Year - dateTime.Year) < 1)
        {
            timeCurrent = Today.Month - dateTime.Month;
            type = "tháng";
        }            
        else
        {
            timeCurrent = (Today.Year - dateTime.Year);
            type = "năm";
        }
            
        var content = FormatDateForView(timeCurrent, type);
        return content;
    }

    public static string FormatDateForView(int Index, string type) 
    {
        return $"{Index} {type} Trước";
    }
}
