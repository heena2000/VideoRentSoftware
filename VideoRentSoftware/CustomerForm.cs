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
    public partial class CustomerForm : Form
    {
        public DataOperation operation;
        DataTable customerTable;
        int cust_id;

        public CustomerForm()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            operation = new DataOperation();
            customerTable = new DataTable();
            customerTable.Columns.Add("Customer ID");
            customerTable.Columns.Add("First Name");
            customerTable.Columns.Add("Last Name");
            customerTable.Columns.Add("Address");
            customerTable.Columns.Add("Phone No");
            LoadGrid();
        }

        private void LoadGrid()
        {
            customerTable.Clear();
            DataSet dataset = operation.GetAllCustomer();
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                customerTable.Rows.Add(row["cust_id"], row["first_name"], row["last_name"], row["address"], row["phone_no"]);
            }
            dgvCustomerGrid.DataSource = customerTable;
        }

        private void DataTableColumns()
        {
            
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            operation.CloseConnection();
        }

        private void dgvCustomerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cust_id = int.Parse(dgvCustomerGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                textFirstName.Text = dgvCustomerGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                textLastName.Text = dgvCustomerGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                textAddress.Text = dgvCustomerGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                textPhoneNo.Text = dgvCustomerGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string message = "";
            bool all_valid = true;
            string first_name = textFirstName.Text.Trim();
            string last_name = textLastName.Text.Trim();
            string address = textAddress.Text.Trim();
            string phone_no = textPhoneNo.Text.Trim();

            if (Validator.CheckEmpty(first_name))
            {
                all_valid = false;
                message += "Please Enter Some Value in First Name\n\n";
            }

            if (Validator.CheckEmpty(last_name))
            {
                all_valid = false;
                message += "Please Enter Some Value in Last Name\n\n";
            }

            if (Validator.CheckEmpty(address))
            {
                all_valid = false;
                message += "Please Enter Some Value in Address\n\n";
            }

            if (Validator.CheckEmpty(phone_no))
            {
                all_valid = false;
                message += "Please Enter Some Value in Phone No\n\n";
            }
            else if(!Validator.CheckPhone(phone_no))
            {
                all_valid = false;
                message += "Phone No Only Contains Digit\n\n";

            }
            if (all_valid)
            {
                if (operation.InsertCustomer(first_name,last_name,address,phone_no))
                {
                    message = "New Customer Details are Saved in Database";
                    LoadGrid();
                }
                else
                {
                    message = "There are some failure in Saving Customer Details in Database";
                }
            }
            MessageBox.Show(message);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cust_id != 0)
            {
                string message = "";
                bool all_valid = true;
                string first_name = textFirstName.Text.Trim();
                string last_name = textLastName.Text.Trim();
                string address = textAddress.Text.Trim();
                string phone_no = textPhoneNo.Text.Trim();

                if (Validator.CheckEmpty(first_name))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in First Name\n\n";
                }

                if (Validator.CheckEmpty(last_name))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Last Name\n\n";
                }

                if (Validator.CheckEmpty(address))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Address\n\n";
                }

                if (Validator.CheckEmpty(phone_no))
                {
                    all_valid = false;
                    message += "Please Enter Some Value in Phone No\n\n";
                }
                else if (!Validator.CheckPhone(phone_no))
                {
                    all_valid = false;
                    message += "Phone No Only Contains Digit\n\n";

                }
                if (all_valid)
                {
                    if (operation.UpdateCustomer(cust_id,first_name, last_name, address, phone_no))
                    {
                        message = "Customer Details are Updated in Database";
                        LoadGrid();
                    }
                    else
                    {
                        message = "There are some failure in Saving Customer Details in Database";
                    }
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    textFirstName.Text = "";
                    textLastName.Text = "";
                    cust_id = 0;
                    textAddress.Text = "";
                    textPhoneNo.Text = "";
                }
                MessageBox.Show(message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cust_id != 0)
            {
                DialogResult result = MessageBox.Show("Are You Sure To Remove Record From Database?", "Video Rental Software", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string message = "";
                    if (operation.DeleteCustomer(cust_id))
                    {
                        message = "Customer Details are Removed from Database";
                        cust_id = 0;
                        LoadGrid();
                    }
                    else
                    {
                        message = "There are some failure in removing Customer Details in Database";
                    }
                    MessageBox.Show(message);
                }
            }
        }
    }
}
