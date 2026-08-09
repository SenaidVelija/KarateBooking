namespace KarateBooking.WinForms
{
    partial class MainForm
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
            btnEvents = new Button();
            label1 = new Label();
            btnUsers = new Button();
            btnBookings = new Button();
            SuspendLayout();
            // 
            // btnEvents
            // 
            btnEvents.Location = new Point(130, 202);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(136, 95);
            btnEvents.TabIndex = 0;
            btnEvents.Text = "Events";
            btnEvents.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(332, 83);
            label1.Name = "label1";
            label1.Size = new Size(157, 41);
            label1.TabIndex = 1;
            label1.Text = "WELCOME";
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(343, 202);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(136, 95);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            
            // 
            // btnBookings
            // 
            btnBookings.Location = new Point(551, 202);
            btnBookings.Name = "btnBookings";
            btnBookings.Size = new Size(136, 95);
            btnBookings.TabIndex = 3;
            btnBookings.Text = "Bookings";
            btnBookings.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBookings);
            Controls.Add(btnUsers);
            Controls.Add(label1);
            Controls.Add(btnEvents);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEvents;
        private Label label1;
        private Button btnUsers;
        private Button btnBookings;
    }
}