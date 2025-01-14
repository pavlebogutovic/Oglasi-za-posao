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
    public class OglasRepository : IOglasRepository
    {
        public bool Add(Oglas item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    INSERT INTO Oglas (NazivPozicije, OpisPosla, DatumObjaveOglasa, DatumIstekaOglasa, Plata, StatusOglasa, IdPoslodavca, IdKategorijaPosla)
                    VALUES (@NazivPozicije, @OpisPosla, @DatumObjaveOglasa, @DatumIstekaOglasa, @Plata, @StatusOglasa, @IdPoslodavca, @IdKategorijaPosla)";
                sqlCommand.Parameters.AddWithValue("@NazivPozicije", item.NazivPozicije);
                sqlCommand.Parameters.AddWithValue("@OpisPosla", item.OpisPosla);
                sqlCommand.Parameters.AddWithValue("@DatumObjaveOglasa", item.DatumObjaveOglasa);
                sqlCommand.Parameters.AddWithValue("@DatumIstekaOglasa", item.DatumIstekaOglasa);
                sqlCommand.Parameters.AddWithValue("@Plata", item.Plata);
                sqlCommand.Parameters.AddWithValue("@StatusOglasa", item.StatusOglasa);
                sqlCommand.Parameters.AddWithValue("@IdPoslodavca", item.IdPoslodavca);
                sqlCommand.Parameters.AddWithValue("@IdKategorijaPosla", item.IdKategorijaPosla);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public bool Delete(Oglas item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Oglas WHERE IdOglasa = @IdOglasa";
                sqlCommand.Parameters.AddWithValue("@IdOglasa", item.IdOglasa);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public List<Oglas> GetAll()
        {
            List<Oglas> list = new List<Oglas>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Oglas";

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Oglas oglas = new Oglas
                    {
                        IdOglasa = reader.GetInt32(0),
                        NazivPozicije = reader.GetString(1),
                        OpisPosla = reader.GetString(2),
                        DatumObjaveOglasa = reader.GetDateTime(3),
                        DatumIstekaOglasa = reader.GetDateTime(4),
                        Plata = reader.GetDecimal(5),
                        StatusOglasa = reader.GetString(6),
                        IdPoslodavca = reader.GetInt32(7),
                        IdKategorijaPosla = reader.GetInt32(8)
                    };
                    list.Add(oglas);
                }
            }
            return list;
        }

        public Oglas GetById(int id)
        {
            Oglas oglas = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Oglas WHERE IdOglasa = @IdOglasa";
                sqlCommand.Parameters.AddWithValue("@IdOglasa", id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    oglas = new Oglas
                    {
                        IdOglasa = reader.GetInt32(0),
                        NazivPozicije = reader.GetString(1),
                        OpisPosla = reader.GetString(2),
                        DatumObjaveOglasa = reader.GetDateTime(3),
                        DatumIstekaOglasa = reader.GetDateTime(4),
                        Plata = reader.GetDecimal(5),
                        StatusOglasa = reader.GetString(6),
                        IdPoslodavca = reader.GetInt32(7),
                        IdKategorijaPosla = reader.GetInt32(8)
                    };
                }
            }
            return oglas;
        }

        public List<Oglas> GetByPoslodavacId(int poslodavacId)
        {
            List<Oglas> list = new List<Oglas>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Oglas WHERE IdPoslodavca = @IdPoslodavca";
                sqlCommand.Parameters.AddWithValue("@IdPoslodavca", poslodavacId);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Oglas oglas = new Oglas
                    {
                        IdOglasa = reader.GetInt32(0),
                        NazivPozicije = reader.GetString(1),
                        OpisPosla = reader.GetString(2),
                        DatumObjaveOglasa = reader.GetDateTime(3),
                        DatumIstekaOglasa = reader.GetDateTime(4),
                        Plata = reader.GetDecimal(5),
                        StatusOglasa = reader.GetString(6),
                        IdPoslodavca = reader.GetInt32(7),
                        IdKategorijaPosla = reader.GetInt32(8)
                    };
                    list.Add(oglas);
                }
            }
            return list;
        }

        public List<Oglas> GetByKategorijaId(int kategorijaId)
        {
            List<Oglas> list = new List<Oglas>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Oglas WHERE IdKategorijaPosla = @IdKategorijaPosla";
                sqlCommand.Parameters.AddWithValue("@IdKategorijaPosla", kategorijaId);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Oglas oglas = new Oglas
                    {
                        IdOglasa = reader.GetInt32(0),
                        NazivPozicije = reader.GetString(1),
                        OpisPosla = reader.GetString(2),
                        DatumObjaveOglasa = reader.GetDateTime(3),
                        DatumIstekaOglasa = reader.GetDateTime(4),
                        Plata = reader.GetDecimal(5),
                        StatusOglasa = reader.GetString(6),
                        IdPoslodavca = reader.GetInt32(7),
                        IdKategorijaPosla = reader.GetInt32(8)
                    };
                    list.Add(oglas);
                }
            }
            return list;
        }

        public bool Update(Oglas item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    UPDATE Oglas
                    SET NazivPozicije = @NazivPozicije,
                        OpisPosla = @OpisPosla,
                        DatumObjaveOglasa = @DatumObjaveOglasa,
                        DatumIstekaOglasa = @DatumIstekaOglasa,
                        Plata = @Plata,
                        StatusOglasa = @StatusOglasa,
                        IdPoslodavca = @IdPoslodavca,
                        IdKategorijaPosla = @IdKategorijaPosla
                    WHERE IdOglasa = @IdOglasa";
                sqlCommand.Parameters.AddWithValue("@NazivPozicije", item.NazivPozicije);
                sqlCommand.Parameters.AddWithValue("@OpisPosla", item.OpisPosla);
                sqlCommand.Parameters.AddWithValue("@DatumObjaveOglasa", item.DatumObjaveOglasa);
                sqlCommand.Parameters.AddWithValue("@DatumIstekaOglasa", item.DatumIstekaOglasa);
                sqlCommand.Parameters.AddWithValue("@Plata", item.Plata);
                sqlCommand.Parameters.AddWithValue("@StatusOglasa", item.StatusOglasa);
                sqlCommand.Parameters.AddWithValue("@IdPoslodavca", item.IdPoslodavca);
                sqlCommand.Parameters.AddWithValue("@IdKategorijaPosla", item.IdKategorijaPosla);
                sqlCommand.Parameters.AddWithValue("@IdOglasa", item.IdOglasa);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }
    }
}
