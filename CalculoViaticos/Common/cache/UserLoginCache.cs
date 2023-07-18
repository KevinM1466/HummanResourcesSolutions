using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.cache
{
    public static class UserLoginCache
    {
        public static int userID { get; set; }
        public static int empleadoID { get; set; }
        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static string email { get; set; }
        public static string contrasenia { get; set; }
        public static string puesto { get; set; }
        public static byte[] imagen { get; set; }
        public static string correoAdmin { get; set; }
        public static byte[] firmaAdmin { get; set; }
        public static bool isJefe { get; set; }
        public static int jefeID { get; set; }
    }
}
