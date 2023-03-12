using easyui.Dao;
using easyui.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace easyui.Daoimpl
{
    public class UserDaoimpl : User
    {
        public bool add(username user)
        {
            SqlConnection con = Database.DaoConnection.getConnection();
            SqlCommand command = new SqlCommand();
            con.Open();
            command.CommandText = "insert into userlogin values('" + user.userName + "','" + user.passWord + "','" + user.phone + "')";
            command.Connection = con;
            int result = 0;
            result = command.ExecuteNonQuery();
            con.Close();
            if (result >= 0)
                return true;
            else
                return false;
            return true;
        }

        public bool Query(username user)
        {
            SqlConnection con = Database.DaoConnection.getConnection();
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from userlogin where username='" + user.userName + "'and password='" + user.passWord + "'";
            command.Connection = con;
            SqlDataReader sdr = command.ExecuteReader();
            if (sdr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
            return true;
        }
    
    }
}