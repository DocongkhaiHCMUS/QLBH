using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CNhatKy
    {
        public string       SYS_ID          {get;set;}
        public string       MChine          {get;set;}
        public string       IP              {get;set;}
        public string       UserID          {get;set;}
        public DateTime     Created         {get;set;}
        public string       Module          {get;set;}
        public int          Action          {get;set;}
        public string       Action_Name     {get;set;}
        public string       Reference       {get;set;}
        public string       Description     {get;set;}
        public bool         Active          {get;set;}


        public CNhatKy() { }

        public CNhatKy
            (
                string      _UserID          ,
                DateTime    _Created         ,
                string      _Module          ,
                string      _Action_Name     ,
                string      _Reference       ,
                string      _Description     
            )
        {
            UserID         =        _UserID          ;
            Created        =        _Created         ;
            Module         =        _Module          ;
            Action_Name    =        _Action_Name     ;
            Reference      =        _Reference == null ? "" : _Reference       ;
            Description    =        _Description     ;

            MChine = Environment.MachineName;
            IP = MChine;
            Action = 0;
            Active = true;
        }
    }
}
