using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentSoftware
{
    public class DataOperation
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=moviezone;Integrated Security=True;";
        
        private SqlConnection conn;

        public DataOperation()
        {
            if (!CheckDatabaseExist())
            {
                GenerateDatabase();
            }
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        private void GenerateDatabase()
        {
            SqlConnection cn;
            SqlCommand cm;
            try
            {
                //Application.StartupPath is the location where the application is Installed
                //Here File Path Can Be Provided Via OpenFileDialog
                string script = null;
                script = VideoRentSoftware.Properties.Resources.MovieZoneScript;
                string[] ScriptSplitter = script.Split(new string[] { "GO" }, StringSplitOptions.None);
                using (cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True"))
                {
                    cn.Open();
                    foreach (string str in ScriptSplitter)
                    {
                        using (cm = cn.CreateCommand())
                        {
                            cm.CommandText = str;
                            cm.ExecuteNonQuery();
                        }
                    }
                }
                cn.Close();
            }
            catch
            {

            }

        }

        private bool CheckDatabaseExist()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckConnectionState()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        public void CloseConnection()
        {
            if (CheckConnectionState())
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public bool InsertGenre(string genre_name)
        {
            try
            {
                string query = "insert into genres(genre_name) values(@genre_name)";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@genre_name", genre_name));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateGenre(int genre_id, string genre_name)
        {
            try
            {
                string query = "update genres set genre_name=@genre_name where genre_id = @genre_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@genre_name", genre_name));
                cmd.Parameters.Add(new SqlParameter("@genre_id", genre_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGenre(int genre_id)
        {
            try
            {
                string query = "delete from genres where genre_id = @genre_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@genre_id", genre_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetAllGenres()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from genres";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }

        public DataTable GetGenres()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from genres ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Genre" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public bool InsertMovie(string title, float rating, int release_year, int genre_id, float rental_cost)
        {
            try
            {
                string query = "insert into movies(title,rating,release_year,genre_id,rental_cost) values(@title,@rating,@release_year,@genre_id,@rental_cost)";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@rating", rating));
                cmd.Parameters.Add(new SqlParameter("@release_year", release_year));
                cmd.Parameters.Add(new SqlParameter("@genre_id", genre_id));
                cmd.Parameters.Add(new SqlParameter("@rental_cost", rental_cost));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMovie(int movie_id, string title, float rating, int release_year, int genre_id, float rental_cost)
        {
            try
            {
                string query = "update movies set title=@title,rating=@rating,release_year=@release_year,genre_id=@genre_id,rental_cost=@rental_cost where movie_id = @movie_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@rating", rating));
                cmd.Parameters.Add(new SqlParameter("@release_year", release_year));
                cmd.Parameters.Add(new SqlParameter("@genre_id", genre_id));
                cmd.Parameters.Add(new SqlParameter("@rental_cost", rental_cost));
                cmd.Parameters.Add(new SqlParameter("@movie_id", movie_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMovie(int movie_id)
        {
            try
            {
                string query = "delete from movies where movie_id = @movie_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@movie_id", movie_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetAllMovies()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "select movie_id,title,rating,rental_cost,release_year,copies,plot,genre_name from movies m join genres g ";
                query += " on m.genre_id = g.genre_id";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }


        public int GetGenreIDUsingMovieID(int movie_id)
        {
            int genre_id = 0;
            try
            {
                string query = "select genre_id from movies where movie_id = @movie_id";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@movie_id", movie_id));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                genre_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
            }
            return genre_id;
        }
        public float GetMovieRent(int movie_id)
        {
            float rental_cost = 0;
            try
            {
                string query = "select rental_cost from movies where movie_id = @movie_id";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@movie_id", movie_id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rental_cost = float.Parse(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            return rental_cost;
        }

        public bool InsertCustomer(string first_name, string last_name, string address, string phone_no)
        {
            try
            {
                string query = "insert into customer(first_name,last_name,address,phone_no) values(@first_name,@last_name,@address,@phone_no)";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@first_name", first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", last_name));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@phone_no", phone_no));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCustomer(int cust_id, string first_name, string last_name, string address, string phone_no)
        {
            try
            {
                string query = "update customer set first_name=@first_name,last_name=@last_name,address=@address,phone_no=@phone_no  where cust_id = @cust_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@first_name", first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", last_name));
                cmd.Parameters.Add(new SqlParameter("@address", address));
                cmd.Parameters.Add(new SqlParameter("@phone_no", phone_no));
                cmd.Parameters.Add(new SqlParameter("@cust_id", cust_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int cust_id)
        {
            try
            {
                string query = "delete from customer where cust_id = @cust_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@cust_id", cust_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetAllCustomer()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "select * from customer";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }

        public DataTable ViewAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from viewAllCustomer ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Customer" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable ViewAllMovie()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from viewAllMovie ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "Select Movie" };
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public bool IssueMovieToCustomer(int movie_id, int cust_id, float rented_cost, DateTime date_rented)
        {
            try
            {
                string query = "insert into rented_movies(movie_id,cust_id,rented_cost,date_rented,date_returned) values(@movie_id,@cust_id,@rented_cost,@date_rented,null)";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@movie_id", movie_id));
                cmd.Parameters.Add(new SqlParameter("@cust_id", cust_id));
                cmd.Parameters.Add(new SqlParameter("@rented_cost", rented_cost));
                cmd.Parameters.Add(new SqlParameter("@date_rented", date_rented));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetRentedMovieDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "procDisplayRentedMovies";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }

        public DataSet GetRentedOutMovieDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = "procDisplayRentedOutMovies";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
        
        public bool ReturnMovie(int rent_id, DateTime date_returned)
        {
            try
            {
                string query = "update rented_movies set date_returned = @date_returned where rent_id = @rent_id";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@date_returned", date_returned));
                cmd.Parameters.Add(new SqlParameter("@rent_id", rent_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool DeleteRentedDetails(int rent_id)
        {
            try
            {
                string query = "delete from rented_movies where rent_id = @rent_id ";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@rent_id", rent_id));
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
