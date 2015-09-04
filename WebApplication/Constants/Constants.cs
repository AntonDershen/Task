using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public static class Constant
    {
        public const string admin = "Admin";
        public const string user = "User";
        public static string adminName;
        public static string adminEmail;
        public static string adminPassword;
        public static string documentAddition;
        public static string userExist;
        public static string errorPassword;
        public static string errorAuth;
        public static string error;
        public static string welcome;
        public static string downloadController;
        static Constant()
        {
            adminName = "Admin";
            adminEmail = "Admin@email.com";
            adminPassword = "Password";
            documentAddition = "()";
            userExist = "User already exists";
            errorPassword = "Password doesn`t match";
            errorAuth = "Login or password incorrect";
            error = "Unknown Error , try again later";
            welcome = "Hello ";
            downloadController = "/Document/DownloadDocument?documentId=";
        }
    }
}
