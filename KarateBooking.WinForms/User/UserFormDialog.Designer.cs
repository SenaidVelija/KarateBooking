namespace KarateBooking.WinForms.User
{
    partial class UserFormDialog
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
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPhoneNumber = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Full name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 84);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 158);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 6;
            label4.Text = "Phone number";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(12, 181);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(125, 27);
            txtPhoneNumber.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 256);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(164, 256);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // UserFormDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "UserFormDialog";
            Text = "UserFormDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPhoneNumber;
        private Button btnSave;
        private Button btnCancel;
    }
}