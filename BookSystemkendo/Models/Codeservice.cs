using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSystemkendo.Models
{
    public class CodeService
        { /// <summary>
          /// 取得DB連線字串
          /// </summary>
          /// <returns></returns>
            private string GetDBConnectionString()
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
            }

        /// <summary>
        /// 取得圖書類別
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetBookClassName()
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT BCL.BOOK_CLASS_NAME AS CodeName, 
                                   BCL.BOOK_CLASS_ID AS CodeID
                            FROM BOOK_CLASS AS BCL";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeName(dt);
        }


        /// <summary>
        /// 取得借閱人全名
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetUserName()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT MM.USER_ENAME+'-'+MM.USER_CNAME AS CodeName, 
                                  MM.USER_ID AS CodeID
                           FROM MEMBER_M AS MM ";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeName(dt);
        }

        ///CodeType
        /// <summary>
        /// 取得借閱狀態
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCodeName()
        {
            DataTable dt = new DataTable();
            string sql = @" SELECT BC.CODE_ID AS CodeID,
                                   BC.CODE_NAME AS CodeName
                            FROM BOOK_CODE AS BC
                            WHERE BC.CODE_TYPE='BOOK_STATUS'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeName(dt);
        }

        /// <summary>
        /// Maping 代碼資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeName(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeID"].ToString()
                });
            }
            return result;
        }
    }
}