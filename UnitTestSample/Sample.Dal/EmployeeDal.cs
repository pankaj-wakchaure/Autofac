using Sample.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;

namespace Sample.Dal
{
    public interface IEmployeeDal
    {
        List<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        List<EmployeeModel> save(EmployeeModel emp);

    }
    public class EmployeeDal : IEmployeeDal
    {
        private readonly string _connectionString;

        public EmployeeDal(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> data = new List<EmployeeModel>();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();
                string query = "Select * from Employee";
                data = db.Query<EmployeeModel>(query).ToList();
            }
            return data;
        }

        public EmployeeModel GetById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();
                string query = $"Select * from Employee where Id ={id}";
                return db.Query<EmployeeModel>(query).First();
            }
        }

        public List<EmployeeModel> save(EmployeeModel emp)
        {
            throw new NotImplementedException();

            //    //save query here
            //    //empList.Add(emp);

            //    //return empList;

        }
    }
}
