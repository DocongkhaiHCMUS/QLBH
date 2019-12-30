using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CQuyenHan
    {
        public string          PER_ID          {get;set;}
        public string          Object_ID       {get;set;}
        public bool            AllowView       {get;set;}
        public bool            AllowAdd        {get;set;}
        public bool            AllowDelete     {get;set;}
        public bool            AllowEdit       {get;set;}
        public bool            Active          {get;set;}

        public CQuyenHan() { }

        public CQuyenHan
            (
                string          _PER_ID      ,
                string          _Object_ID   ,
                bool            _AllowView   ,
                bool            _AllowAdd    ,
                bool            _AllowDelete ,
                bool            _AllowEdit   ,
                bool            _Active     
            )
        {                                          
             PER_ID         =       _PER_ID        ;
             Object_ID      =       _Object_ID     ;
             AllowView      =       _AllowView     ;
             AllowAdd       =       _AllowAdd      ;
             AllowDelete    =       _AllowDelete   ;
             AllowEdit      =       _AllowEdit     ;
             Active         =       _Active        ;
        }
    }
}
