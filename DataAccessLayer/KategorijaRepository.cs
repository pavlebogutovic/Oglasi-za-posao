using DataAccessLayer.Constat;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KategorijaRepository : IKategorijaRepository
    {
        public bool Add(Kategorija item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Kategorija (NazivKategorije) VALUES (@NazivKategorije)";
                sqlCommand.Parameters.AddWithValue("@NazivKategorije", item.NazivKategorije);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public bool Delete(Kategorija item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Kategorija WHERE IdKategorije=@IdKategorije";
                sqlCommand.Parameters.AddWithValue("@IdKategorije", item.IdKategorije);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public List<Kategorija> GetAll()
        {
            List<Kategorija> list = new List<Kategorija>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Kategorija";

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Kategorija kategorija = new Kategorija
                    {
                        IdKategorije = reader.GetInt32(0),
                        NazivKategorije = reader.GetString(1)
                    };
                    list.Add(kategorija);
                }
            }
            return list;
        }

        public Kategorija GetByNaziv(string naziv)
        {
            Kategorija kategorija = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Kategorija WHERE NazivKategorije = @NazivKategorije";
                sqlCommand.Parameters.AddWithValue("@NazivKategorije", naziv);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    kategorija = new Kategorija
                    {
                        IdKategorije = reader.GetInt32(0),
                        NazivKategorije = reader.GetString(1)
                    };
                }
            }
            return kategorija;
        }

        public bool Update(Kategorija item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Kategorija SET NazivKategorije=@NazivKategorije WHERE IdKategorije=@IdKategorije";
                sqlCommand.Parameters.AddWithValue("@NazivKategorije", item.NazivKategorije);
                sqlCommand.Parameters.AddWithValue("@IdKategorije", item.IdKategorije);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }
    }
}