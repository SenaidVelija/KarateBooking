using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Booking.Commands.Cancel;
using KarateBooking.Application.CQRS.Booking.Queries.GetList;
using KarateBooking.Application.DTO;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class BookingForm : Form
    {
        private readonly IQueryHandler<GetBookingListQuery, List<BookingDto>> _getBookingList;
        private readonly ICommandHandler<CancelBookingCommand, bool> _cancelHandler;
        private readonly Func<BookingDto?, BookingFormDialog> _createBookingForm;
        public BookingForm(IQueryHandler<GetBookingListQuery, List<BookingDto>> getBookingList,
            ICommandHandler<CancelBookingCommand, bool> cancelHandler,
            Func<BookingDto?, BookingFormDialog> createBookingForm)
        {
            InitializeComponent();
            _getBookingList = getBookingList;
            _cancelHandler = cancelHandler;
            _createBookingForm = createBookingForm;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;

            this.Load += BookingsForm_Load;
        }

        private async void BookingsForm_Load(object? sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var bookings = await _getBookingList.Handle(new GetBookingListQuery());
                dataGridView1.DataSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var clickedBooking = (BookingDto)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName == "Update")
            {
                using var form = _createBookingForm(clickedBooking);

                if (form.ShowDialog() == DialogResult.OK)
                    await LoadData();
            }
            else if (columnName == "Cancel")
            {
                var confirm = MessageBox.Show(
                    $"Otkazati rezervaciju za '{clickedBooking.UserName}' na dogadjaju '{clickedBooking.EventName}'?",
                    "Potvrda",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                try
                {
                    await _cancelHandler.Handle(new CancelBookingCommand { Id = clickedBooking.Id });
                    await LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
