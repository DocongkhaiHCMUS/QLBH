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
    public class PhanQuyen
    {
        public DataTable LoadPhanQuyenALL()
        {
            try
            {
                string sql = "select * from K_Permision_Detail";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUser()
        {
            try
            {
                string sql = "select * from SYS_USER";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadPermision()
        {
            try
            {
                string sql = "select * from K_Permision";
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void XoaVaiTro(string Ma)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = string.Format("delete K_Permision where ID ='{0}'", Ma);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);

                sql = string.Format("delete K_Permision_Detail where PER_ID ='{0}'", Ma);
                type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);
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

        public void XoaNguoiDung(string Ma)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = string.Format("delete SYS_USER where UserID='{0}'",Ma);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);
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

        public void SuaNguoiDung(CUser us)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = string.Format("UPDATE dbo.SYS_USER SET Group_ID ='{0}',Description=N'{1}',PartID='{2}',Active='{3}' WHERE UserID='{4}'", 
                    us.GroupID,us.Description,us.PartID,us.Active,us.UserID);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);
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

        public void ThemNguoiDung(CUser us)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = 
                    string.Format("INSERT dbo.SYS_USER( UserID ,UserName ,Password ,Group_ID ,Description ,PartID ,Active)VALUES('{0}', N'{1}', '{2}', '{3}', N'{4}', '{5}', {6})",
                    us.UserID, us.UserName, us.Password, us.GroupID, us.Description,us.PartID,us.Active==true ? 1:0);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);
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

        public void SuaVaiTro(CQuyen q,List<CQuyenHan> qh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = string.Format("UPDATE dbo.K_PERMISION SET Name ='{0}', Description=N'{1}',ACTIVE='{2}'WHERE ID='{3}'"
                    , q.Name,q.Description,q.ACTIVE,q.ID);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);

                foreach (var item in qh)
                {
                    sql = string.Format("UPDATE dbo.K_Permision_Detail SET AllowAdd='{0}',AllowDelete='{1}',AllowEdit='{2}',AllowView='{3}',Active='{4}'WHERE PER_ID='{5}'AND Object_ID='{6}'"
                        , item.AllowAdd,item.AllowDelete,item.AllowEdit,item.AllowView,item.Active,item.PER_ID,item.Object_ID);
                    type = CommandType.Text;
                    dao.ExeCuteNonQuery(type, sql);
                }
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

        public void ThemVaiTro(CQuyen q, List<CQuyenHan> qh)
        {
            Provider dao = new Provider();
            try
            {
                dao.Connect();
                string sql = string.Format("INSERT dbo.K_PERMISION( ID, Name, Description, ACTIVE )VALUES  ( '{0}',N'{1}',N'{2}',{3})"
                    , q.ID, q.Name, q.Description, q.ACTIVE == true ? 1 : 0);
                CommandType type = CommandType.Text;
                dao.ExeCuteNonQuery(type, sql);

                foreach (var item in qh)
                {
                    sql = string.Format("INSERT dbo.K_Permision_Detail( PER_ID ,Object_ID ,AllowAdd ,AllowDelete ,AllowEdit ,Active ,AllowView)" +
                        "VALUES('{0}', '{1}', {2}, {3}, {4}, {5}, {6})"
                        , item.PER_ID, item.Object_ID, item.AllowAdd == true ? 1 : 0, item.AllowDelete == true ? 1 : 0, item.AllowEdit == true ? 1 : 0, item.Active == true ? 1 : 0, item.AllowView == true ? 1 : 0);
                    type = CommandType.Text;
                    dao.ExeCuteNonQuery(type, sql);
                }
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
        public DataTable LoadPhanQuyen(string vaitro)
        {
            try
            {
                string sql = string.Format("select * from K_Permision_Detail where PER_ID ='{0}'",vaitro);
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadPhanQuyen(string vaitro,string form)
        {
            try
            {
                string sql = string.Format("select * from K_Permision_Detail where PER_ID ='{0}' and Object_ID ='{1}'"
                    , vaitro,form);
                return SelectTable.SelectQuery(sql);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}
