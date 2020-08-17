using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruYumPortal.Models;

namespace TruYumPortal.Helper
{
    public class AdminDataAccessLayer : IAdminInterface
    {
        string connectionString = "Data Source=DESKTOP-KJSLJO5\\SQLEXPRESS; User ID=sa;password=sravani;Initial Catalog = TruYum; Integrated Security = True; Trusted_Connection=True;";
        public void AddItem(Items item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Items(ItemName, Price,Category,FreeDelivery,Active) VALUES(@ItemName, @Price,@Category,@FreeDelivery,@Active)", con);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@Price", item.Price);
                command.Parameters.AddWithValue("@Category", item.Category);
                command.Parameters.AddWithValue("@FreeDelivery", item.FreeDelivery);
                command.Parameters.AddWithValue("@Active", item.Active);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE ItemId=@ItemId", con);
                

                cmd.Parameters.AddWithValue("@ItemId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Items> GetAllItems()
        {
            List<Items> listItem = new List<Items>();
            using(SqlConnection con=new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from Items", con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Items item = new Items();
                    item.ItemId = Convert.ToInt32(reader["ItemId"]);
                    item.ItemName = reader["ItemName"].ToString();
                    item.Price = reader["Price"].ToString();
                    item.Category = reader["Category"].ToString();
                    item.FreeDelivery = reader["FreeDelivery"].ToString();
                    item.Active = reader["Active"].ToString();

                    listItem.Add(item);
                }
                con.Close();
            }
            return listItem;
        }

        public Items GetItemById(int? id)
        {

           Items item = new Items();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Items WHERE ItemId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    item.ItemId = Convert.ToInt32(rdr["ItemId"]);
                    item.ItemName = rdr["ItemName"].ToString();
                    item.Price = rdr["Price"].ToString();
                    item.Category = rdr["Category"].ToString();
                    item.FreeDelivery = rdr["FreeDelivery"].ToString();
                    item.Active = rdr["Active"].ToString();
                }
            }
            return item;

        }

        public void UpdateItem(Items item)
        {
            using(SqlConnection con =new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Items SET ItemName=@ItemName, Price=@Price,Category=@Category, FreeDelivery=@FreeDelivery, Active=@Active Where ItemId=@ItemId", con);
                command.Parameters.AddWithValue("@ItemId",item.ItemId);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@Price", item.Price);
                command.Parameters.AddWithValue("@Category", item.Category);
                command.Parameters.AddWithValue("@FreeDelivery", item.FreeDelivery);
                command.Parameters.AddWithValue("@Active", item.Active);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
