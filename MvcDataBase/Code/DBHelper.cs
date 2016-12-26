using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using MvcDataBase.Models;

namespace MvcDataBase.Code
{
    public class DBHelper
    {
        private SqlConnection conn;
        private SqlCommand comm;
        private List<Table3> result;
        
        public DBHelper(string ConStr)
        {
            conn = new SqlConnection(ConStr);
        }
        
        public List<Table3> GetAllRecord()
        {
            conn.Open();
            string sql = "select * from Table_3";
            comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            result= new List<Table3>();

            while (reader.Read())
            {
                Table3 item = new Table3();
                item.id = reader.GetInt32(reader.GetOrdinal("id"));
                item.column1 = reader.GetString(reader.GetOrdinal("列1"));
                item.column2 = reader.GetString(reader.GetOrdinal("列2"));
                result.Add(item);
            }
            reader.Close();
            conn.Close();
            
            return result;
        }

        public int DeleteRecord(int id)
        {
            conn.Open();
            string sql = "delete from Table_3 where id=" + id;
            comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        public int AddRecord(Table3 table)
        {

            conn.Open();
            string sql = "insert into Table_3 values('" + table.column1 + "','" + table.column2 + "')";
            comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();

            conn.Close();

            return result;
        }
        public Table3 SearchRecordByID(int id)
        {
            conn.Open();
            string sql = "select * from Table_3 where(id=" + id + ")";
            comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            Table3 item = new Table3();
            if (reader.Read())
            {
                item.id = reader.GetInt32(reader.GetOrdinal("id"));
                item.column1 = reader.GetString(reader.GetOrdinal("列1"));
                item.column2 = reader.GetString(reader.GetOrdinal("列2"));
            }
            reader.Close();
            conn.Close();

            return item;
        }
        public int UpdateRecord(Table3 record,int id)
        {
            string sql = "UPDATE Table_3 SET 列1 = '" + record.column1 + "',列2='" + record.column2 + "' WHERE id = " + Convert.ToInt32(id) + "";

            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            int result = comm.ExecuteNonQuery();

            conn.Close();
            return result;
        }
    }
}