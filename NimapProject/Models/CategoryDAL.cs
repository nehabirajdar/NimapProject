using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NimapProject.Models
{
    public  class CategoryDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
       
        private readonly IConfiguration configuration;
        public CategoryDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration.GetConnectionString("defaultConnection");
            con = new SqlConnection(constr);

        }
       
        public List<Category> CategoryList()
        {
            List<Category> list = new List<Category>();
            string str = "select * from Category";
            cmd = new SqlCommand(str, con);
            con.Open();
            reader= cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                { 
                    Category c= new Category();
                    c.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    c.CategoryName = reader["CategoryName"].ToString();
                    list.Add(c);

                }
            }
            con.Close();
            return list;

        }

        public int AddCat(Category cat)
        {
            string str = "insert into Category values(@id,@name)";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", cat.CategoryId);
            cmd.Parameters.AddWithValue("@name", cat.CategoryName);
            con.Open();
            int res= cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int UpdateCat(Category cat)
        {
            string str = "update Category set CategoryName=@name where CategoryId=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id",cat.CategoryId);
            cmd.Parameters.AddWithValue("@name",cat.CategoryName);
            con.Open();
            int res= cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteCategory(int id)
        {
            string str = "delete from Category where CategoryId=@id";
            cmd=new SqlCommand(str, con);

            cmd.Parameters.AddWithValue("@id", id);
            con.Open();

            int res= cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Category GetCatById(int id)
        {
            Category c = new Category();
            string str = "select * from Category where CategoryId=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    c.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    c.CategoryName = reader["CategoryName"].ToString();


                }
            }
            con.Close();
            return c;

        }
    }
}
