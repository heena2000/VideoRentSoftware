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
    public partial class GenreForm : Form
    {
        private DataOperation operation;
        DataTable genreTable;
        int genre_id;

        public GenreForm()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            operation = new DataOperation();
            genreTable = new DataTable();
            genreTable.Columns.Add("Genre ID");
            genreTable.Columns.Add("Genre Name");
            LoadGrid();
        }

        private void LoadGrid()
        {
            genreTable.Clear();            
            DataSet dataset = operation.GetAllGenres();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                genreTable.Rows.Add(row["genre_id"], row["genre_name"]);
            }
            dgvGenreDetails.DataSource = genreTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = "";
            string genre_name = textGenreName.Text.Trim();

            if (Validator.CheckEmpty(genre_name))
            {                
                message = "Please Enter Some Value in Genre Name";
            }
            else
            {
                if (operation.InsertGenre(genre_name))
                {
                    message = "New Genre Details are Saved in Database";
                    LoadGrid();
                }
                else
                {
                    message = "There are some failure in Saving Genre Details in Database";
                }
            }
            MessageBox.Show(message);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (genre_id != 0)
            {
                string message = "";
                string genre_name = textGenreName.Text.Trim();

                if (Validator.CheckEmpty(genre_name))
                {
                    message = "Please Enter Some Value in Genre Name";
                }
                else
                {
                    if (operation.UpdateGenre(genre_id,genre_name))
                    {
                        message = "Genre Details are Updated in Database";
                        LoadGrid();                                                     
                    }
                    else
                    {
                        message = "There are some failure in Updating Genre Details in Database";
                    }
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    textGenreName.Text = "";
                }
                MessageBox.Show(message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (genre_id != 0)
            {
                DialogResult result = MessageBox.Show("Are You Sure To Remove Record From Database?", "Video Rental Software", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string message = "";
                    if (operation.DeleteGenre(genre_id))
                    {
                        message = "Genre Details are Removed from Database";
                        genre_id = 0;
                        LoadGrid();
                    }
                    else
                    {
                        message = "There are some failure in removing Genre Details in Database";
                    }
                    MessageBox.Show(message);
                }
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                textGenreName.Text = "";
            }
        }

        private void GenreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            operation.CloseConnection();
        }

        private void dgvGenreDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                genre_id = int.Parse(dgvGenreDetails.Rows[e.RowIndex].Cells[0].Value.ToString());
                textGenreName.Text = dgvGenreDetails.Rows[e.RowIndex].Cells[1].Value.ToString();
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
