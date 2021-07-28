using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoRentSoftware
{
    public partial class MovieForm : Form
    {
        public Form HomeForm { get; set; }
        public DataOperation operation;
        DataTable MovieTable;
        int movie_id;

        public MovieForm()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            operation = new DataOperation();
            BindCombo();
            MovieTable = new DataTable();
            MovieTable.Columns.Add("Movie ID");
            MovieTable.Columns.Add("Movie Title");
            MovieTable.Columns.Add("Genre");
            MovieTable.Columns.Add("Rating");
            MovieTable.Columns.Add("Rental Cost");
            MovieTable.Columns.Add("Release Year");
            LoadDB();
        }

        private void LoadDB()
        {
            MovieTable.Clear();
            DataSet dataset = operation.GetAllMovies();
            foreach(DataRow row in dataset.Tables[0].Rows)
            {
                MovieTable.Rows.Add(row["movie_id"], row["title"], row["genre_name"], row["rating"], row["rental_cost"], row["release_year"]);
            }
            dgvMovieGrid.DataSource = MovieTable;
        }

        public void BindCombo()
        {
            DataTable tableGenre = operation.GetGenres();
            comboGenre.ValueMember = "genre_id";
            comboGenre.DisplayMember = "genre_name";
            comboGenre.DataSource = tableGenre;
        }

        private void MovieForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            operation.CloseConnection();            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = "";
            bool all_valid = true;
            string title = textMovieTitle.Text.Trim();
            string year = textReleaseYear.Text.Trim();
        
            float rating = (float)numericRating.Value;
            if(Validator.CheckEmpty(title))
            {
                all_valid = false;
                message += "Please Enter Some Value in Title\n\n";
            }

            if (Validator.CheckEmpty(year))
            {
                all_valid = false;
                message += "Please Enter Some Value in Release Year\n\n";
            }
            else if( year.Length != 4 )
            {
                all_valid = false;
                message += "Please Enter Four Digit in Release Year\n\n";
            }
            else if(!Validator.CheckNumber(year))
            {
                all_valid = false;
                message += "Please Enter Number in Release Year\n\n";
            }

            if (comboGenre.SelectedIndex == 0)
            {
                all_valid = false;
                message += "Please Choose Any Genre\n\n";
            }
            if(all_valid)
            {
                int release_year = int.Parse(year);
                float rental_cost = 5;
                int genre_id = int.Parse(comboGenre.SelectedValue.ToString());
                if(release_year < DateTime.Now.Year - 5 )
                {
                    rental_cost = 2;
                }
                if(operation.InsertMovie(title,rating,release_year,genre_id,rental_cost))
                {
                    message = "New Movie Details are Saved in Database";
                    LoadDB();
                }
                else
                {
                    message = "There are some failure in saveing Movie Details in Database";
                }
            }
            MessageBox.Show(message);
        }

        private void dgvMovieGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                try
                {
                    movie_id = int.Parse(dgvMovieGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textMovieTitle.Text = dgvMovieGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textReleaseYear.Text = dgvMovieGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    numericRating.Value = int.Parse(dgvMovieGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
                    int genre_id = operation.GetGenreIDUsingMovieID(movie_id);
                    if(genre_id!=0)
                    {
                        int selected_index = 0;
                        for(int index = 1; index < comboGenre.Items.Count; index++ )
                        {
                            comboGenre.SelectedIndex = index;
                            int gid = int.Parse(comboGenre.SelectedValue.ToString());
                            if(genre_id == gid)
                            {
                                selected_index = index;
                                break;
                            }
                        }
                        comboGenre.SelectedIndex = selected_index;
                    }
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                catch (Exception ex)
                {

                }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(movie_id != 0)
            {
                string message = "";
                bool all_valid = true;
                string title = textMovieTitle.Text.Trim();
                string year = textReleaseYear.Text.Trim();
                
                float rating = (float)numericRating.Value;
                if (Validator.CheckEmpty(title))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Title\n\n";
                }

                if (Validator.CheckEmpty(year))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Release Year\n\n";
                }
                else if (year.Length != 4)
                {
                    all_valid = false;
                    message += "Please Enter Four Digit in Release Year\n\n";
                }
                else if (!Validator.CheckNumber(year))
                {
                    all_valid = false;
                    message += "Please Enter Number in Release Year\n\n";
                }

                if (comboGenre.SelectedIndex == 0)
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Genre\n\n";
                }
                if (all_valid)
                {
                    int release_year = int.Parse(year);
                    float rental_cost = 5;
                    if (release_year < DateTime.Now.Year - 5)
                    {
                        rental_cost = 2;
                    }
                    int genre_id = int.Parse(comboGenre.SelectedValue.ToString());
                    if (operation.UpdateMovie(movie_id, title, rating, release_year, genre_id, rental_cost))
                    {
                        message = "Movie Details are Updated in Database";
                        LoadDB();
                    }
                    else
                    {
                        message = "There are some failure in saving Movie Details in Database";
                    }
                }
                MessageBox.Show(message);
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                movie_id = 0;
                textMovieTitle.Text = "";
                textReleaseYear.Text = "";
                numericRating.Value = 0;
                comboGenre.SelectedIndex = 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (movie_id != 0)
            {
                DialogResult result = MessageBox.Show("Are You Sure To Remove Record From Database?", "Movie System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result==DialogResult.Yes)
                {
                    string message = "";
                    if (operation.DeleteMovie(movie_id))
                    {
                        message = "Movie Details are Removed from Database";
                        LoadDB();
                    }
                    else
                    {
                        message = "There are some failure in removing Movie Details in Database";
                    }
                    MessageBox.Show(message);
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    movie_id = 0;
                    textMovieTitle.Text = "";
                    textReleaseYear.Text = "";
                    numericRating.Value = 0;
                    comboGenre.SelectedIndex = 0;
                }
            }
        }
    }
}
