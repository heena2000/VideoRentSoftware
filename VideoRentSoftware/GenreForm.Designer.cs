namespace VideoRentSoftware
{
    partial class GenreForm
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
            this.dgvGenreDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textGenreName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenreDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGenreDetails
            // 
            this.dgvGenreDetails.AllowUserToAddRows = false;
            this.dgvGenreDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGenreDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenreDetails.Location = new System.Drawing.Point(22, 12);
            this.dgvGenreDetails.Name = "dgvGenreDetails";
            this.dgvGenreDetails.RowHeadersWidth = 51;
            this.dgvGenreDetails.RowTemplate.Height = 24;
            this.dgvGenreDetails.Size = new System.Drawing.Size(688, 337);
            this.dgvGenreDetails.TabIndex = 0;
            this.dgvGenreDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGenreDetails_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Genre Name:";
            // 
            // textGenreName
            // 
            this.textGenreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGenreName.Location = new System.Drawing.Point(212, 392);
            this.textGenreName.Name = "textGenreName";
            this.textGenreName.Size = new System.Drawing.Size(498, 30);
            this.textGenreName.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(96, 446);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(538, 54);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add New Genre";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(96, 530);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(538, 54);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update Genre Details";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(96, 619);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(538, 54);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete Genre Details";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // GenreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 710);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textGenreName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGenreDetails);
            this.Name = "GenreForm";
            this.Text = "Genre Operations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenreForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenreDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGenreDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGenreName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}