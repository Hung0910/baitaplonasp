using BanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BanDongHo.Common
{
    public class Common
    {
        /*g?i mail reset password*/
        private static string Fr_Email = ConfigurationManager.AppSettings["Email"];
        private static string password = ConfigurationManager.AppSettings["Password"];
        public static bool SendMail(string name, string content, string To_Email)
        {
            bool rs = false;
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new SmtpClient(); //T?o m?t ??i t??ng SmtpClient ?? g?i email.
                {
                    smtp.Host = "smtp.gmail.com"; //??t t�n m�y ch? SMTP
                    smtp.Port = 587; //?�y l� c?ng ti�u chu?n ???c s? d?ng cho giao th?c SMTP.
                    smtp.EnableSsl = true; //K�ch ho?t ch? ?? SSL cho m�y ch? SMTP. ?i?u n�y y�u c?u k?t n?i ???c m� h�a SSL khi g?i email.
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; //X�c ??nh ph??ng th?c g?i email l� th�ng qua m?ng.

                    smtp.UseDefaultCredentials = false; //Kh�ng s? d?ng th�ng tin ??ng nh?p m?c ??nh.
                    smtp.Credentials = new NetworkCredential() //??t th�ng tin ??ng nh?p
                    {
                        UserName = Fr_Email,
                        Password = password
                    };
                }
                MailAddress fromAddress = new MailAddress(Fr_Email, name); //T?o m?t ??i t??ng MailAddress ?? ch? ??nh ??a ch? email ngu?n v� t�n ng??i g?i.
                message.From = fromAddress; //??t ??a ch? email ngu?n c?a th?.
                message.To.Add(To_Email);//Th�m ??a ch? email ?�ch v�o danh s�ch ng??i nh?n.
                message.IsBodyHtml = true;//cho ph�p n?i dung mail ???c hi?n th? d??i d?ng HTML.
                message.Body = content; // n?i dung mail
                smtp.Send(message);
                rs = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                rs = false;
            }
            return rs;
        }
        public static string FormatNumber(object value, int SoSauDauPhay = 2)
        {
            bool isNumber = IsNumeric(value);
            decimal GT = 0;
            if (isNumber)
            {
                GT = Convert.ToDecimal(value);
            }
            string str = "";
            string thapPhan = "";
            for (int i = 0; i < SoSauDauPhay; i++)
            {
                thapPhan += "#";
            }
            if (thapPhan.Length > 0) thapPhan = "." + thapPhan;
            string snumformat = string.Format("0:#,##0{0}", thapPhan);
            str = String.Format("{" + snumformat + "}", GT);

            return str;
        }
        private static bool IsNumeric(object value)
        {
            return value is sbyte
                       || value is byte
                       || value is short
                       || value is ushort
                       || value is int
                       || value is uint
                       || value is long
                       || value is ulong
                       || value is float
                       || value is double
                       || value is decimal;
        }


        public static string HtmlRate(int rate)
        {
            var str = "";
            if (rate == 1)
            {
                str = @"
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>";
            }
            if (rate == 2)
            {
                str = @"
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>";
            }
            if (rate == 3)
            {
                str = @"
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>";
            }
            if (rate == 4)
            {
                str = @"
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star-o' aria-hidden='true'></i></li>";
            }
            if (rate == 5)
            {
                str = @"
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>
                <li><i class='fa fa-star' aria-hidden='true'></i></li>";
            }
            return str;
        }
    }
}