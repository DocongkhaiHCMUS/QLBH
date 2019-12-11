using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DTO
{
    public class CUser
    {
        string UserID { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string GroupID { get; set; }
        string Description { get; set; }
        string PartID { get; set; }
        bool Active { get; set; }
    }
}
