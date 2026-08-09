namespace KarateBooking.WinForms.User
{
    partial class UsersForm
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
            dgvUsers = new DataGridView();
            btnNewUser = new Button();
            FullName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Update = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { FullName, Email, PhoneNumber, Update, Delete });
            dgvUsers.Location = new Point(12, 46);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(776, 273);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick_1;
            // 
            // btnNewUser
            // 
            btnNewUser.Location = new Point(694, 344);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(94, 29);
            btnNewUser.TabIndex = 1;
            btnNewUser.Text = "New user";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += btnNewUser_Click_1;
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.DataPropertyName = "FullName";
            FullName.HeaderText = "FullName";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "PhoneNumber";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            // 
            // Update
            // 
            Update.HeaderText = "Update";
            Update.MinimumWidth = 6;
            Update.Name = "Update";
            Update.Text = "Update";
            Update.UseColumnTextForButtonValue = true;
            Update.Width = 125;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Text = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            Delete.Width = 125;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNewUser);
            Controls.Add(dgvUsers);
            Name = "UsersForm";
            Text = "UsersForm";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnNewUser;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewButtonColumn Update;
        private DataGridViewButtonColumn Delete;
    }
}