using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookSystemkendo.Models
{
    public class LoginService
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int UserLogin(Models.LoginData login)
        {
            string sql = @"SELECT USER_ID, USER_NAME, USER_PASSWORD 
                           FROM USER_LOGIN
                           WHERE USER_NAME=@Username AND 
                                 User_Password=@Password;";

            int UserID;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Username", login.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", login.Password));
                SqlTransaction Tran = conn.BeginTransaction();
                cmd.Transaction = Tran;

                try
                {
                    UserID = Convert.ToInt32(cmd.ExecuteScalar());
                    if (UserID != 0)
                    {
                        Tran.Commit();
                    }
                }
                catch (Exception)
                {
                    Tran.Rollback();
                    throw;
                }
                finally
                {
                    conn.Close();
                }

            }
            return UserID;
        }
    }
}