using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Booking.Commands.Create;
using KarateBooking.Application.CQRS.Booking.Commands.Update;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.CQRS.User.Queries.GetList;
using KarateBooking.Application.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateBooking.WinForms.Booking
{
    public partial class BookingFormDialog : Form
    {
        private readonly ICommandHandler<CreateBookingCommand, BookingDto> _createHandler;
        private readonly ICommandHandler<UpdateBookingCommand, BookingDto> _updateHandler;
        private readonly IQueryHandler<GetEventListQuery, List<EventDto>> _getEventList;
        private readonly IQueryHandler<GetUserListQuery, List<UserDto>> _getUserList;
        private readonly int? _bookingId;
        private readonly BookingDto? _existingBooking;
        private readonly int? _preselectedEventId;
        public BookingFormDialog(ICommandHandler<CreateBookingCommand, BookingDto> createHandler,
            ICommandHandler<UpdateBookingCommand, BookingDto> updateHandler,
            IQueryHandler<GetEventListQuery, List<EventDto>> getEventList,
            IQueryHandler<GetUserListQuery, List<UserDto>> getUserList,
            BookingDto? existingBooking = null,
            int? preselectedEventId = null)
        {
            InitializeComponent();
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _getEventList = getEventList;
            _getUserList = getUserList;
            _existingBooking = existingBooking;
            _preselectedEventId = preselectedEventId;
            if (existingBooking != null)
            {
                _bookingId = existingBooking.Id;
                Text = "Izmjena rezervacije";
            }
            else
            {
                Text = "Nova rezervacija";
            }

            this.Load += BookingFormDialog_Load;
           
            btnCancel.Click += (s, e) => Close();
        }

        private async void BookingFormDialog_Load(object? sender, EventArgs e)
        {
            try
            {
                var events = await _getEventList.Handle(new GetEventListQuery());
                cbEvent.DataSource = events;
                cbEvent.DisplayMember = "Name";
                cbEvent.ValueMember = "Id";

                var users = await _getUserList.Handle(new GetUserListQuery());
                cbUser.DataSource = users;
                cbUser.DisplayMember = "FullName";
                cbUser.ValueMember = "Id";

                if (_existingBooking != null)
                {
                    
                    cbEvent.SelectedValue = _existingBooking.EventId;
                    cbUser.SelectedValue = _existingBooking.UserId;
                    txtQuantity.Text = _existingBooking.Quantity.ToString();

                    cbEvent.Enabled = false;
                    cbUser.Enabled = false;
                }
                else if (_preselectedEventId != null)
                {
                    
                    cbEvent.SelectedValue = _preselectedEventId.Value;
                    cbEvent.Enabled = false;   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_bookingId == null)
                {
                    await _createHandler.Handle(new CreateBookingCommand
                    {
                        EventId = (int)cbEvent.SelectedValue!,
                        UserId = (int)cbUser.SelectedValue!,
                        Quantity = int.Parse(txtQuantity.Text)
                    });
                    MessageBox.Show("Uspjesno kreirana rezervacija.");
                }
                else
                {
                    await _updateHandler.Handle(new UpdateBookingCommand
                    {
                        Id = _bookingId.Value,
                        NewQuantity = int.Parse(txtQuantity.Text)
                    });
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                var fullMessage = ex.Message;
                var inner = ex.InnerException;
                while (inner != null)
                {
                    fullMessage += "\n\n--- Inner ---\n" + inner.Message;
                    inner = inner.InnerException;
                }
                MessageBox.Show(fullMessage, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
