using System;
using System.Collections.Generic;
using System.Text;

namespace App1.CurrentSession
{
    //Stores the User-Data to 
    static class CurrentUser
    {
        static public string CurrentUserName { get; set; }
        static public string CurrentUserId { get; set; }
        static public string Token { get; set; }
    }
}
