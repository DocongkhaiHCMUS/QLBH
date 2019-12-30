using QLBH_BUS;
using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAQLBH_Devexpress
{
    public class Action
    {
        public static string Module            {get;set;}
        public static string ActionName        {get;set;}
        public static string UserID            {get;set;}
        public static string Reference         {get;set;}

        public static void LuuThongTin()
        {
            CNhatKy nk = new CNhatKy(UserID, DateTime.Now, Module, ActionName, Reference, ActionName +" " + Module);
            BUS_NhatKy.ThemNhatKy(nk);
        }
    }
}
