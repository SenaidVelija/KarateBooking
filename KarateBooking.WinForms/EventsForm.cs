using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Commands.Delete;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.DTO;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KarateBooking.WinForms
{
    public partial class EventsForm : Form
    {

        private readonly IQueryHandler<GetEventListQuery, List<EventDto>> _getEventList;
        private readonly ICommandHandler<DeleteEventCommand, bool> _deleteHandler;
        private readonly Func<EventDto?, EventFormDialog> _createEventForm;
        public EventsForm(IQueryHandler<GetEventListQuery, List<EventDto>> getEventList,
            ICommandHandler<DeleteEventCommand, bool> deleteHandler,
            Func<EventDto?, EventFormDialog> createEventForm)
        {
            InitializeComponent();
            _getEventList = getEventList;
            _deleteHandler = deleteHandler;
            _createEventForm = createEventForm;
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

        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var form = _createEventForm(null);
            if (form.ShowDialog() == DialogResult.OK)
                await LoadData();

        }
    }
}

