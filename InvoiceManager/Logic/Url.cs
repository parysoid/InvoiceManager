using System;

namespace InvoiceManager.Logic
{
    public class Url
    {
        public static bool HasId(string url)
        {
            int id = 0;

            if (Int32.TryParse(url.Substring(url.LastIndexOf("/") + 1), out id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetId(string url)
        {
            return Convert.ToInt32(url.Substring(url.LastIndexOf("/") + 1));
        }
    }
}
