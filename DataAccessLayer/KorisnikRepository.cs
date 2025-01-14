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
    public class KorisnikRepository : IKorisnikRepository
    {
        public bool Add(Korisnik item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into Korisnik(NazivKorisnika,EmailKorisnika,LozinkaKorisnika,TipKorisnika,OpisKorisnika,VestineKorisnika, DatumRegistracije) values(@NazivKorisnika,@EmailKorisnika,@LozinkaKorisnika,@TipKorisnika,@OpisKorisnika,@VestineKorisnika,@DatumRegistracije)";
                sqlCommand.Parameters.AddWithValue("@NazivKorisnika", item.NazivKorisnika);
                sqlCommand.Parameters.AddWithValue("@EmailKorisnika", item.EmailKorisnika);
                sqlCommand.Parameters.AddWithValue("@LozinkaKorisnika", item.LozinkaKorisnika);
                sqlCommand.Parameters.AddWithValue("@TipKorisnika", item.TipKorisnika);
                sqlCommand.Parameters.AddWithValue("@OpisKorisnika", item.OpisKorisnika);
                sqlCommand.Parameters.AddWithValue("@VestineKorisnika", item.VestineKorisnika);
                sqlCommand.Parameters.AddWithValue("@DatumRegistracije", item.DatumRegistracije);

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public bool Delete(Korisnik item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Korisnik WHERE IdKorisnika=@IdKorisnika";
                sqlCommand.Parameters.AddWithValue("@IdKorisnika", item.IdKorisnika);


                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }

        public List<Korisnik> GetAll()
        {
            List<Korisnik> list = new List<Korisnik>();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Korisnik";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Korisnik korisnik = new Korisnik();
                    korisnik.IdKorisnika = sqlDataReader.GetInt32(0);
                    korisnik.NazivKorisnika = sqlDataReader.GetString(1);
                    korisnik.EmailKorisnika = sqlDataReader.GetString(2);
                    korisnik.LozinkaKorisnika = sqlDataReader.GetString(3);
                    korisnik.TipKorisnika = sqlDataReader.GetString(4);
                    korisnik.OpisKorisnika = sqlDataReader.GetString(5);
                    korisnik.VestineKorisnika = sqlDataReader.GetString(6);
                    korisnik.DatumRegistracije = sqlDataReader.GetDateTime(7);
                    list.Add(korisnik);

                }

            }
            return list;
        }

        public Korisnik GetByEmail(string email)
        {
            Korisnik korisnik1 = new Korisnik();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Korisnik where EmailKorisnika = @EmailKorisnika";
                sqlCommand.Parameters.AddWithValue("@EmailKorisnika", email);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {

                    korisnik1.IdKorisnika = sqlDataReader.GetInt32(0);
                    korisnik1.NazivKorisnika = sqlDataReader.GetString(1);
                    korisnik1.EmailKorisnika = sqlDataReader.GetString(2);
                    korisnik1.LozinkaKorisnika = sqlDataReader.GetString(3);
                    korisnik1.TipKorisnika = sqlDataReader.GetString(4);
                    korisnik1.OpisKorisnika = sqlDataReader.GetString(5);
                    korisnik1.VestineKorisnika = sqlDataReader.GetString(6);
                    korisnik1.DatumRegistracije = sqlDataReader.GetDateTime(7);

                }

            }
            return korisnik1;
        }

        public bool Update(Korisnik item)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConnectionBase.ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE Korisnik SET NazivKorisnika=@NazivKorisnika, EmailKorisnika=@EmailKorisnika, LozinkaKorisnika=@LozinkaKorisnika, TipKorisnika=@TipKorisnika, OpisKorisnika=@OpisKorisnika, VestineKorisnika=@VestineKorisnika, DatumRegistracije=@DatumRegistracije WHERE IdKorisnika=@IdKorisnika";
                sqlCommand.Parameters.AddWithValue("@NazivKorisnika", item.NazivKorisnika);
                sqlCommand.Parameters.AddWithValue("@EmailKorisnika", item.EmailKorisnika);
                sqlCommand.Parameters.AddWithValue("@LozinkaKorisnika", item.LozinkaKorisnika);
                sqlCommand.Parameters.AddWithValue("@TipKorisnika", item.TipKorisnika);
                sqlCommand.Parameters.AddWithValue("@OpisKorisnika", item.OpisKorisnika);
                sqlCommand.Parameters.AddWithValue("@VestineKorisnika", item.VestineKorisnika);
                sqlCommand.Parameters.AddWithValue("@DatumRegistracije", item.DatumRegistracije);
                sqlCommand.Parameters.AddWithValue("@IdKorisnika", item.IdKorisnika);
                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}