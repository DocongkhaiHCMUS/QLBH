using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CQuyen
    {
        public string   ID              {get;set;}
        public string   Name            {get;set;}
        public string   Description     {get;set;}
        public bool     ACTIVE          {get;set;}

        public CQuyen() { }
        public CQuyen
            (
                string   _ID             ,
                string   _Name           ,
                string   _Description    ,
                bool     _ACTIVE     
            )
        {
            ID                 =        _ID            ;
            Name               =        _Name          ;
            Description        =        _Description   ;
            ACTIVE             =        _ACTIVE        ;
        }
    }
}
