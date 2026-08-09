using KarateBooking.WinForms.Booking;
using KarateBooking.WinForms.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateBooking.WinForms
{
    public partial class MainForm : Form
    {
        private readonly Func<EventsForm> _createEventsForm;
        private readonly Func<UsersForm> _createUsersForm;
        private readonly Func<BookingForm> _createBookingForm;
        public MainForm(Func<EventsForm> createEventsForm,Func<UsersForm> createUsersForm, Func<BookingForm> createBookingForm)
        {
            InitializeComponent();
            _createEventsForm = createEventsForm;
            _createUsersForm=createUsersForm;
            _createBookingForm = createBookingForm;
            btnEvents.Click += (s, e) => OpenChildForm(_createEventsForm());
            btnUsers.Click += (s, e) => OpenChildForm(_createUsersForm());
            btnBookings.Click += (s, e) => OpenChildForm(_createBookingForm());
        }
        private void OpenChildForm(Form childForm)
        {
            childForm.ShowDialog();
        }

      
    }
}
