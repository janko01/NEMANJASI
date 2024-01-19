using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AlbumsRepository
    {
        public string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public List<Album> GetAllAlbums()
        {
            List<Album> list = new List<Album>();

            using(SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;

                cmd.CommandText = "SELECT * FROM Albums";

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Album album = new Album();
                    album.Id = reader.GetInt32(0);
                    album.Title = reader.GetString(1);
                    album.Artist = reader.GetString(2);
                    album.Price = reader.GetDecimal(3);

                    list.Add(album);
                }
            }
            return list;
        }

        public int InsertAlbum(Album album)
        {
            using(SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;

                cmd.CommandText = string.Format("INSERT INTO Albums VALUES ('{0}', '{1}', '{2}')",
                    album.Title, album.Artist, album.Price);

                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteAlbum(int id)
        {
            using(SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sql;
                sqlCommand.CommandText = "DELETE FROM Albums WHERE Id=" + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateAlbum(Album album)
        {
            using(SqlConnection sql = new SqlConnection(con))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandText = "UPDATE Albums SET Title=@Title, Artist=@Artist, Price=@Price WHERE Id=" + album.Id;

                cmd.Parameters.AddWithValue("@Id", album.Id);
                cmd.Parameters.AddWithValue("@Title", album.Title);
                cmd.Parameters.AddWithValue("@Artist", album.Artist);
                cmd.Parameters.AddWithValue("@Price", album.Price);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
