using Sample.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;

namespace Sample.Dal
{
    public static class LoginDal
    {
        private static string _connectionString;
        static LoginDal()
        {
            _connectionString = @"server=PANKAJW-LP\SQLEXPRESS;database=Smaple;uid=pankaj;password=password;Integrated Security=True";
        }
        public static bool Login(string userName, string password)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();
                string query = $"Select * from [User] where UserName ='{userName}' and Password ='{password}'";
                return db.Query<EmployeeModel>(query).Any();
            }
        }
    }
}
