using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CUser
    {
        public string      UserID      { get; set; }
        public string      UserName    { get; set; }
        public string      Password    { get; set; }
        public string      GroupID     { get; set; }
        public string      Description { get; set; }
        public string      PartID      { get; set; }
        public bool        Active      { get; set; }

        public CUser() { }
        public CUser
            (
                string      _UserID      ,
                string      _UserName    ,
                string      _Password    ,
                string      _GroupID     ,
                string      _Description ,
                string      _PartID      ,
                bool        _Active     
            )
        {
            UserID         =        _UserID        ;
            UserName       =        _UserName      ;
            Password       =        _Password      ;
            GroupID        =        _GroupID       ;
            Description    =        _Description   ;
            PartID         =        _PartID        ;
            Active         =        _Active        ;
        }
    }
}
