using System;
using System.Collections.Generic;
using System.Text;

namespace estet.Classes
{
    public class Globals
    {
        public static bool IsUserDev;

        public static string UserName = "";

        public static int Id;

        public void MakeDev ()
        {
            IsUserDev = true;
        }
        

    }
}
