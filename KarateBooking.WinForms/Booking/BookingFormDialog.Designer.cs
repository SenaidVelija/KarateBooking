namespace KarateBooking.WinForms.Booking
{
    partial class BookingFormDialog
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
            cbEvent = new ComboBox();
            label1 = new Label();
            txtQuantity = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cbUser = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cbEvent
            // 
            cbEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEvent.FormattingEnabled = true;
            cbEvent.Location = new Point(12, 47);
            cbEvent.Name = "cbEvent";
            cbEvent.Size = new Size(269, 28);
            cbEvent.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 1;
            label1.Text = "Event";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(12, 126);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 3;
            label2.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(349, 24);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 5;
            label3.Text = "User";
            // 
            // cbUser
            // 
            cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUser.FormattingEnabled = true;
            cbUser.Location = new Point(349, 47);
            cbUser.Name = "cbUser";
            cbUser.Size = new Size(151, 28);
            cbUser.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(154, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // BookingFormDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(cbUser);
            Controls.Add(label2);
            Controls.Add(txtQuantity);
            Controls.Add(label1);
            Controls.Add(cbEvent);
            Name = "BookingFormDialog";
            Text = "BookingFormDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbEvent;
        private Label label1;
        private TextBox txtQuantity;
        private Label label2;
        private Label label3;
        private ComboBox cbUser;
        private Button btnSave;
        private Button btnCancel;
    }
}