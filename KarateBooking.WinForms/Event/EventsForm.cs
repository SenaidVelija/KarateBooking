using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Commands.Cancel;
using KarateBooking.Application.CQRS.Event.Commands.Delete;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.DTO;
using KarateBooking.WinForms.Booking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KarateBooking.WinForms
{
    public partial class EventsForm : Form
    {

        private readonly IQueryHandler<GetEventListQuery, List<EventDto>> _getEventList;
        private readonly ICommandHandler<DeleteEventCommand, bool> _deleteHandler;
        private readonly ICommandHandler<CancelEventCommand, bool> _cancelHandler;
        private readonly Func<EventDto?, EventFormDialog> _createEventForm;
        private readonly Func<BookingDto?, int?, BookingFormDialog> _createBookingForm;
        public EventsForm(IQueryHandler<GetEventListQuery, List<EventDto>> getEventList,
            ICommandHandler<DeleteEventCommand, bool> deleteHandler, ICommandHandler<CancelEventCommand, bool> cancelHandler,
            Func<EventDto?, EventFormDialog> createEventForm, Func<BookingDto?, int?, BookingFormDialog> createBookingForm)
        {
            InitializeComponent();
            _getEventList = getEventList;
            _deleteHandler = deleteHandler;
            _cancelHandler = cancelHandler;
            _createEventForm = createEventForm;
            _createBookingForm= createBookingForm;
            EventsDgv.AutoGenerateColumns = false;
            EventsDgv.MultiSelect = false;
            this.Load += EventsLoad;

        }

        private async void EventsLoad(object sender, EventArgs e)
        {


            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var events = await _getEventList.Handle(new GetEventListQuery());

                EventsDgv.DataSource = events;
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message, "greska", MessageBoxButtons.OK);
                }
            }
        }
        private async void EventsDgv_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var clickedEvent = (EventDto)EventsDgv.Rows[e.RowIndex].DataBoundItem;

            using var form = _createBookingForm(null, clickedEvent.Id);

            if (form.ShowDialog() == DialogResult.OK)
                await LoadData();   
        }

        private async void EventsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex == 0)
            {
                return;
            }
            var clickedEvent = (EventDto)EventsDgv.Rows[e.RowIndex].DataBoundItem;
            if (EventsDgv.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Da li ste sigurni da zelite izbrisati ovaj dogadjaj"
                    , "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    await _deleteHandler.Handle(new DeleteEventCommand { Id = clickedEvent.Id });
                    await LoadData();

                }

            }
            else if (EventsDgv.Columns[e.ColumnIndex].Name == "Update")
            {
                var form = _createEventForm(clickedEvent);
                if (form.ShowDialog() == DialogResult.OK)
                    await LoadData();
            }
            else if (EventsDgv.Columns[e.ColumnIndex].Name == "CancelEvent")
            {
                var confirm = MessageBox.Show("Da li ste sigurni da zelite promijeniti status za ovaj dogadjaj u OTKAZANO"
                     , "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    await _cancelHandler.Handle(new CancelEventCommand { Id = clickedEvent.Id });
                    await LoadData();

                }
            }

        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var form = _createEventForm(null);
            if (form.ShowDialog() == DialogResult.OK)
                await LoadData();

        }
    }
}

