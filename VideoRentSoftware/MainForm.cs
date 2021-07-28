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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void genresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenreForm form = new GenreForm();
            form.MdiParent = this;
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form frm in this.MdiChildren)
            {
                frm.Dispose();
            }
            Application.Exit();
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieForm form = new MovieForm();
            form.MdiParent = this;
            form.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.MdiParent = this;
            form.Show();
        }

        private void movieRentOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieRentForm form = new MovieRentForm();
            form.MdiParent = this;
            form.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
