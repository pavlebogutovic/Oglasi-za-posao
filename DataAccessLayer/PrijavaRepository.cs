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
    public class PrijavaRepository : IPrijavaRepository
    {
        public bool Add(Prijava item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    INSERT INTO Prijava (DatumPrijave, StatusPrijave, KomentarNaPrijavi, IdKandidata, IdOglasa)
                    VALUES (@DatumPrijave, @StatusPrijave, @KomentarNaPrijavi, @IdKandidata, @IdOglasa)";
                sqlCommand.Parameters.AddWithValue("@DatumPrijave", item.DatumPrijave);
                sqlCommand.Parameters.AddWithValue("@StatusPrijave", item.StatusPrijave);
                sqlCommand.Parameters.AddWithValue("@KomentarNaPrijavi", item.KomentarNaPrijavi);
                sqlCommand.Parameters.AddWithValue("@IdKandidata", item.IdKandidata);
                sqlCommand.Parameters.AddWithValue("@IdOglasa", item.IdOglasa);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public bool Delete(Prijava item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Prijava WHERE IdPrijave = @IdPrijave";
                sqlCommand.Parameters.AddWithValue("@IdPrijave", item.IdPrijave);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }

        public List<Prijava> GetAll()
        {
            List<Prijava> list = new List<Prijava>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Prijava";

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Prijava prijava = new Prijava
                    {
                        IdPrijave = reader.GetInt32(0),
                        DatumPrijave = reader.GetDateTime(1),
                        StatusPrijave = reader.GetString(2),
                        KomentarNaPrijavi = reader.GetString(3),
                        IdKandidata = reader.GetInt32(4),
                        IdOglasa = reader.GetInt32(5)
                    };
                    list.Add(prijava);
                }
            }
            return list;
        }

        public List<Prijava> GetByKandidataId(int kandidataId)
        {
            List<Prijava> list = new List<Prijava>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Prijava WHERE IdKandidata = @IdKandidata";
                sqlCommand.Parameters.AddWithValue("@IdKandidata", kandidataId);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Prijava prijava = new Prijava
                    {
                        IdPrijave = reader.GetInt32(0),
                        DatumPrijave = reader.GetDateTime(1),
                        StatusPrijave = reader.GetString(2),
                        KomentarNaPrijavi = reader.GetString(3),
                        IdKandidata = reader.GetInt32(4),
                        IdOglasa = reader.GetInt32(5)
                    };
                    list.Add(prijava);
                }
            }
            return list;
        }

        public List<Prijava> GetByOglasId(int oglasId)
        {
            List<Prijava> list = new List<Prijava>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Prijava WHERE IdOglasa = @IdOglasa";
                sqlCommand.Parameters.AddWithValue("@IdOglasa", oglasId);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Prijava prijava = new Prijava
                    {
                        IdPrijave = reader.GetInt32(0),
                        DatumPrijave = reader.GetDateTime(1),
                        StatusPrijave = reader.GetString(2),
                        KomentarNaPrijavi = reader.GetString(3),
                        IdKandidata = reader.GetInt32(4),
                        IdOglasa = reader.GetInt32(5)
                    };
                    list.Add(prijava);
                }
            }
            return list;
        }

        public bool Update(Prijava item)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionBase.ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    UPDATE Prijava
                    SET DatumPrijave = @DatumPrijave,
                        StatusPrijave = @StatusPrijave,
                        KomentarNaPrijavi = @KomentarNaPrijavi,
                        IdKandidata = @IdKandidata,
                        IdOglasa = @IdOglasa
                    WHERE IdPrijave = @IdPrijave";
                sqlCommand.Parameters.AddWithValue("@DatumPrijave", item.DatumPrijave);
                sqlCommand.Parameters.AddWithValue("@StatusPrijave", item.StatusPrijave);
                sqlCommand.Parameters.AddWithValue("@KomentarNaPrijavi", item.KomentarNaPrijavi);
                sqlCommand.Parameters.AddWithValue("@IdKandidata", item.IdKandidata);
                sqlCommand.Parameters.AddWithValue("@IdOglasa", item.IdOglasa);
                sqlCommand.Parameters.AddWithValue("@IdPrijave", item.IdPrijave);

                int res = sqlCommand.ExecuteNonQuery();
                return res > 0;
            }
        }
    }
}