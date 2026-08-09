using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.DTO;

namespace KarateBooking.WinForms
{
    partial class EventsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EventsDgv = new DataGridView();
            EventName = new DataGridViewTextBoxColumn();
            EventDescription = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            EventStatus = new DataGridViewTextBoxColumn();
            EventType = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Capacity = new DataGridViewTextBoxColumn();
            CancelEvent = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            Update = new DataGridViewButtonColumn();
            btnNew = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)EventsDgv).BeginInit();
            SuspendLayout();
            // 
            // EventsDgv
            // 
            EventsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EventsDgv.Columns.AddRange(new DataGridViewColumn[] { EventName, EventDescription, StartDate, EndDate, EventStatus, EventType, Price, Capacity, CancelEvent, Delete, Update });
            EventsDgv.Location = new Point(12, 41);
            EventsDgv.Name = "EventsDgv";
            EventsDgv.RowHeadersWidth = 51;
            EventsDgv.Size = new Size(1351, 333);
            EventsDgv.TabIndex = 0;
            EventsDgv.CellContentClick += EventsDgv_CellContentClick;
            EventsDgv.CellContentDoubleClick += EventsDgv_CellContentDoubleClick_1;
            // 
            // EventName
            // 
            EventName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EventName.DataPropertyName = "Name";
            EventName.HeaderText = "Name";
            EventName.MinimumWidth = 6;
            EventName.Name = "EventName";
            // 
            // EventDescription
            // 
            EventDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EventDescription.DataPropertyName = "Description";
            EventDescription.HeaderText = "Description";
            EventDescription.MinimumWidth = 6;
            EventDescription.Name = "EventDescription";
            // 
            // StartDate
            // 
            StartDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StartDate.DataPropertyName = "StartDate";
            StartDate.HeaderText = "Start date";
            StartDate.MinimumWidth = 6;
            StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            EndDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EndDate.DataPropertyName = "EndDate";
            EndDate.HeaderText = "End date";
            EndDate.MinimumWidth = 6;
            EndDate.Name = "EndDate";
            // 
            // EventStatus
            // 
            EventStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EventStatus.DataPropertyName = "EventStatus";
            EventStatus.HeaderText = "Status";
            EventStatus.MinimumWidth = 6;
            EventStatus.Name = "EventStatus";
            // 
            // EventType
            // 
            EventType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EventType.DataPropertyName = "EventType";
            EventType.HeaderText = "Type";
            EventType.MinimumWidth = 6;
            EventType.Name = "EventType";
            // 
            // Price
            // 
            Price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            // 
            // Capacity
            // 
            Capacity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Capacity.DataPropertyName = "Capacity";
            Capacity.HeaderText = "Capacity";
            Capacity.MinimumWidth = 6;
            Capacity.Name = "Capacity";
            // 
            // CancelEvent
            // 
            CancelEvent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CancelEvent.HeaderText = "Cancel Event";
            CancelEvent.MinimumWidth = 6;
            CancelEvent.Name = "CancelEvent";
            CancelEvent.Text = "Cancel";
            CancelEvent.ToolTipText = "Cancel";
            CancelEvent.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Text = "Delete";
            Delete.ToolTipText = "Delete";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // Update
            // 
            Update.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Update.HeaderText = "Update";
            Update.MinimumWidth = 6;
            Update.Name = "Update";
            Update.Text = "Update";
            Update.ToolTipText = "Update";
            Update.UseColumnTextForButtonValue = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(1269, 380);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 1;
            btnNew.Text = "New event";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(283, 20);
            label1.TabIndex = 2;
            label1.Text = "Double click an event to make a booking.";
            // 
            // EventsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1375, 450);
            Controls.Add(label1);
            Controls.Add(btnNew);
            Controls.Add(EventsDgv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EventsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)EventsDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView EventsDgv;
        private Button btnNew;
        private DataGridViewTextBoxColumn EventName;
        private DataGridViewTextBoxColumn EventDescription;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn EventStatus;
        private DataGridViewTextBoxColumn EventType;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Capacity;
        private DataGridViewButtonColumn CancelEvent;
        private DataGridViewButtonColumn Delete;
        private DataGridViewButtonColumn Update;
        private Label label1;
    }
}
