using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Commands.Create;
using KarateBooking.Application.CQRS.Event.Commands.Update;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Enums.Event;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KarateBooking.WinForms
{
    public partial class EventFormDialog : Form
    {
        private readonly ICommandHandler<CreateEventCommand, EventDto> _createHandler;
        private readonly ICommandHandler<UpdateEventCommand, EventDto> _updateHandler;
        private readonly int? _eventId;
        public EventFormDialog(ICommandHandler<CreateEventCommand, EventDto> createHandler,
            ICommandHandler<UpdateEventCommand, EventDto> updateHandler, EventDto? existingEvent = null)
        {
            InitializeComponent();
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            cmbEventType.DataSource = Enum.GetValues(typeof(EventType));

            if (existingEvent != null)
            {
                _eventId = existingEvent.Id;
                Text = "Izmjena događaja";
                txtName.Text = existingEvent.Name;
                txtDescription.Text = existingEvent.Description;
                dtpStartDate.Value = existingEvent.StartDate;
                dtpEndDate.Value = existingEvent.EndDate;
                cmbEventType.SelectedItem = Enum.Parse<EventType>(existingEvent.EventType);
                txtPrice.Text=existingEvent.Price.ToString();
                txtCapacity.Text=existingEvent.Capacity.ToString();
            }
            else
            {
                Text = "Novi događaj";
            }

            btnSave.Click += btnSave_Click!;
            btnCancel.Click += (s, e) => Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedType = (EventType)cmbEventType.SelectedItem!;
                if (_eventId == null)
                {
                    await _createHandler.Handle(new CreateEventCommand
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        EventType = selectedType,
                        Price = int.Parse(txtPrice.Text),
                        Capacity = int.Parse(txtCapacity.Text)
                    });
                }
                else
                {
                    await _updateHandler.Handle(new UpdateEventCommand 
                    {
                        Id=_eventId.Value,
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        EventType = selectedType,
                        Price=int.Parse(txtPrice.Text),
                        Capacity=int.Parse(txtCapacity.Text)
                        

                    });
                   
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
