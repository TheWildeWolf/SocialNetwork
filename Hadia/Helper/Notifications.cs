using System;

namespace Hadia.Helper
{
    public static class Notifications
    {
        public static string SuccessNotify(string msg) =>
            string.Format(@" new PNotify({{
                title: 'Success',
                text: '{0}',
                addclass: 'bg-success border-success'
            }});", msg);

        public static string ErrorNotify(string msg) =>
            string.Format(@" new PNotify({{
                title: 'Error',
                text: '{0}',
                addclass: 'bg-danger border-danger'
            }});", msg);

        public static string NormalNotify(string msg) =>
            string.Format(@" new PNotify({{
                title: 'Alert',
                text: '{0}',
                addclass: 'bg-primary border-primary'
            }});", msg);
        public static Func<string,string> Success = str=> string.Format(@" new PNotify({{
                title: 'Success',
                text: '{0}',
                addclass: 'bg-success border-success'
            }});", str);


    }
}