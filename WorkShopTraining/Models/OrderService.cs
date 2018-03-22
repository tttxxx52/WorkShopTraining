using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WorkShopTraining.Models
{
    public class OrderService
    {
        /// <summary>
        /// 連結資料庫
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
        }


        /// <summary>
        /// 取得員工資料
        /// </summary>
        public List<Models.Order> GetEmployeeData()
        {
            DataTable dataTable = new DataTable();
            string sql = @"SELECT EmployeeID, FirstName + ' ' + LastName As EmployeeName
                         FROM HR.Employees";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dataTable);
                conn.Close();
            }
            return this.MapEmployeeDataToList(dataTable);
        }

        /// <summary>
        /// 取得員工資料變成List
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Order> MapEmployeeDataToList(DataTable dataTable)
        {
            List<Models.Order> result = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Order
                {
                    EmployeeID = (int)row["EmployeeID"],
                    EmployeeName = row["EmployeeName"].ToString()
                });
            }
            return result;
        }

        /// <summary>
        /// 取得供應商資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetShipperData()
        {
            DataTable dataTable = new DataTable();
            string sql = @"SELECT ShipperID, CompanyName As ShipperName
                           FROM Sales.Shippers";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dataTable);
                conn.Close();
            }
            return this.MapShipperDataToList(dataTable);
        }

        /// <summary>
        /// 取得供應商資料變成List
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Order> MapShipperDataToList(DataTable dataTable)
        {
            List<Models.Order> result = new List<Order>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Order
                {
                    ShipperID = (int)row["ShipperID"],
                    ShipperName = row["ShipperName"].ToString()
                });
            }
            return result;
        }


    }
}