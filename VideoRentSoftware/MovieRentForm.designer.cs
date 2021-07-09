namespace VideoRentSoftware
{
    partial class MovieRentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRentGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOut = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCustomer = new System.Windows.Forms.ComboBox();
            this.comboMovie = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRent = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRentGrid
            // 
            this.dgvRentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentGrid.Location = new System.Drawing.Point(12, 12);
            this.dgvRentGrid.Name = "dgvRentGrid";
            this.dgvRentGrid.RowHeadersWidth = 51;
            this.dgvRentGrid.RowTemplate.Height = 24;
            this.dgvRentGrid.Size = new System.Drawing.Size(1480, 467);
            this.dgvRentGrid.TabIndex = 14;
            this.dgvRentGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRentGrid_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioOut);
            this.groupBox1.Controls.Add(this.radioAll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 497);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 163);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // radioOut
            // 
            this.radioOut.AutoSize = true;
            this.radioOut.Location = new System.Drawing.Point(17, 104);
            this.radioOut.Name = "radioOut";
            this.radioOut.Size = new System.Drawing.Size(142, 29);
            this.radioOut.TabIndex = 1;
            this.radioOut.TabStop = true;
            this.radioOut.Text = "Out Rented";
            this.radioOut.UseVisualStyleBackColor = true;
            this.radioOut.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(17, 48);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(132, 29);
            this.radioAll.TabIndex = 0;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All Rented";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Choose Customer :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Choose Movie :";
            // 
            // comboCustomer
            // 
            this.comboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCustomer.FormattingEnabled = true;
            this.comboCustomer.Location = new System.Drawing.Point(455, 512);
            this.comboCustomer.Name = "comboCustomer";
            this.comboCustomer.Size = new System.Drawing.Size(446, 33);
            this.comboCustomer.TabIndex = 18;
            // 
            // comboMovie
            // 
            this.comboMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMovie.FormattingEnabled = true;
            this.comboMovie.Location = new System.Drawing.Point(455, 600);
            this.comboMovie.Name = "comboMovie";
            this.comboMovie.Size = new System.Drawing.Size(446, 33);
            this.comboMovie.TabIndex = 19;
            this.comboMovie.SelectedIndexChanged += new System.EventHandler(this.comboMovie_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(1149, 512);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(267, 30);
            this.dtpDate.TabIndex = 20;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(928, 515);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(203, 25);
            this.labelDate.TabIndex = 21;
            this.labelDate.Text = "Choose Issue Date:";
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(29, 684);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(473, 44);
            this.btnIssue.TabIndex = 22;
            this.btnIssue.Text = "Issue Movie";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(938, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Movie Rental Cost $";
            // 
            // labelRent
            // 
            this.labelRent.AutoSize = true;
            this.labelRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRent.Location = new System.Drawing.Point(1171, 601);
            this.labelRent.Name = "labelRent";
            this.labelRent.Size = new System.Drawing.Size(63, 25);
            this.labelRent.TabIndex = 24;
            this.labelRent.Text = "None";
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(560, 684);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(473, 44);
            this.btnReturn.TabIndex = 25;
            this.btnReturn.Text = "Return Movie";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(1074, 684);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(368, 44);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MovieRentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 749);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.labelRent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.comboMovie);
            this.Controls.Add(this.comboCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRentGrid);
            this.MaximizeBox = false;
            this.Name = "MovieRentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Rent Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MovieRentForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRentGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioOut;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCustomer;
        private System.Windows.Forms.ComboBox comboMovie;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDelete;
    }
}