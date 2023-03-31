using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office2010.Excel;
using Nest;

namespace NimapProject.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        private readonly IConfiguration configuration;

        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Product> ProductList()
        {
            List<Product> list = new List<Product>();
            string str = "select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(reader["ProductId"]);
                    p.ProductName = reader["ProductName"].ToString();
                    p.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    list.Add(p);

                }
            }
            con.Close();
            return list;
        }
       
        

        public int AddProd(Product p)
        {
            string str = "insert into Product values(@id,@name,@catid)";
            cmd=new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", p.ProductId);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@catid", p.CategoryId);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateProd(Product p) {
            string str = "update Product set ProductName=@name,CategoryId=@catid where ProductId=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", p.ProductId);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@catid", p.CategoryId);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

                }
        public int DeleteProduct(int id)
        {
            string str = "delete from Product where ProductId=@id";
            cmd= new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Product GetProdById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where ProductId=@id";
            cmd = new SqlCommand(str, con);

            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    p.ProductId = Convert.ToInt32(reader["ProductId"]);
                    p.ProductName = reader["ProductName"].ToString();
                    p.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                }
            }
            con.Close();
            return p;
        }

        internal int DeleteProd(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
