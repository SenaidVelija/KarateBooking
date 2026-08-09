namespace KarateBooking.WinForms.Booking
{
    partial class BookingForm
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
            dataGridView1 = new DataGridView();
            Username = new DataGridViewTextBoxColumn();
            EventName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            BookingDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Update = new DataGridViewButtonColumn();
            Cancel = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Username, EventName, Quantity, BookingDate, Status, Update, Cancel });
            dataGridView1.Location = new Point(12, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(932, 263);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Username
            // 
            Username.DataPropertyName = "UserName";
            Username.HeaderText = "Username";
            Username.MinimumWidth = 6;
            Username.Name = "Username";
            Username.Width = 125;
            // 
            // EventName
            // 
            EventName.DataPropertyName = "EventName";
            EventName.HeaderText = "EventName";
            EventName.MinimumWidth = 6;
            EventName.Name = "EventName";
            EventName.Width = 125;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // BookingDate
            // 
            BookingDate.DataPropertyName = "BookingDate";
            BookingDate.HeaderText = "BookingDate";
            BookingDate.MinimumWidth = 6;
            BookingDate.Name = "BookingDate";
            BookingDate.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
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
            // Cancel
            // 
            Cancel.HeaderText = "Cancel";
            Cancel.MinimumWidth = 6;
            Cancel.Name = "Cancel";
            Cancel.Text = "Cancel";
            Cancel.UseColumnTextForButtonValue = true;
            Cancel.Width = 125;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 450);
            Controls.Add(dataGridView1);
            Name = "BookingForm";
            Text = "BookingForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn EventName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn BookingDate;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewButtonColumn Update;
        private DataGridViewButtonColumn Cancel;
    }
}