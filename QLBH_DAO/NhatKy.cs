using QLBH_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_DAO
{
    public class NhatKy
    {
        public DataTable LoadNhatKy()
        {
            try
            {
                string sql = "SYS_LOG_GetList_ByDate";
                var shortDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                return SelectTable.SelectProcedure(sql,
                    new SqlParameter { ParameterName = "@From",Value=DateTime.Now.Date},
                    new SqlParameter { ParameterName = "@To", Value = shortDate }
                    );
                }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void XoaNhatKy(int ID)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "SYS_LOG_Delete";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql, new SqlParameter { ParameterName = "@SYS_ID", Value = ID });
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }

        public void ThemNhatKy(CNhatKy nk)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = "KSP_ThemNhatKy";
                CommandType type = CommandType.StoredProcedure;
                dao.ExeCuteNonQuery(type, sql,
                    new SqlParameter { ParameterName = "@MChine"		   , Value = nk.MChine         },
                    new SqlParameter { ParameterName = "@IP"			   , Value = nk.IP             },
                    new SqlParameter { ParameterName = "@UserID"		   , Value = nk.UserID         },
                    new SqlParameter { ParameterName = "@Created"		   , Value = nk.Created        },
                    new SqlParameter { ParameterName = "@Module"		   , Value = nk.Module         },
                    new SqlParameter { ParameterName = "@Action"		   , Value = nk.Action         },
                    new SqlParameter { ParameterName = "@Action_Name"	   , Value = nk.Action_Name    },
                    new SqlParameter { ParameterName = "@Reference"	       , Value = nk.Reference      },
                    new SqlParameter { ParameterName = "@Description"	   , Value = nk.Description    },
                    new SqlParameter { ParameterName = "@Active"           , Value = nk.Active         } 
                    );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dao.DisConnect();
            }
        }
    }
}
